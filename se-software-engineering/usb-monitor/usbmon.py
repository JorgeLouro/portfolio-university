import win32gui
import win32con
import logging
import win32com.client
import time
from logger import log_event
from whitelist import WhitelistManager
from blocker import disable_usb_device
from notifier import send_email_alert, reset_alert
import uuid
from datetime import datetime

class BaseMonitor:
    def __init__(self, config_file="config.json"):
        self.whitelist_manager = WhitelistManager(config_file)
        self.alerted_devices = {}  # Dispositivos alertados recentemente
        self._devices = set()  # Conjunto de dispositivos conectados
        self._running = True
        
        # Lista de dispositivos do sistema para ignorar
        self.system_devices = [
            "ROOT_HUB",      # Hubs USB
            "VID_8086",      # Intel
            "COMPOSITE",     # Dispositivos compostos
            "ACPI",         # Dispositivos ACPI
            "PCI",          # Dispositivos PCI
            "SCSI",         # Dispositivos SCSI
            "STORAGE",      # Controladores de armazenamento
            "VID_0BDA&PID_B00C",  # Realtek Bluetooth interno
            "VID_0408&PID_5365"   # Webcam SunplusIT interna
        ]
        
        try:
            self.wmi = win32com.client.GetObject("winmgmts:")
        except Exception as e:
            print(f"[ERRO] Falha ao inicializar WMI: {e}")
            log_event("ERRO", f"Falha ao inicializar WMI: {e}")
            try:
                self.wmi = win32com.client.Dispatch("WbemScripting.SWbemLocator").ConnectServer(".", "root\\cimv2")
                print("[INFO] WMI inicializado usando método alternativo")
            except Exception as e2:
                print(f"[ERRO] Falha ao inicializar WMI (método alternativo): {e2}")
                log_event("ERRO", f"Falha ao inicializar WMI (método alternativo): {e2}")
                self.wmi = None

    def get_devices(self):
        devices_info = []
        for device_id in self._devices:
            device_info = {
                "id": device_id,
                "authorized": self.whitelist_manager.is_device_allowed(device_id)
            }
            devices_info.append(device_info)
        return devices_info

    def get_device_info(self, device):
        """Extrai informações de um dispositivo."""
        try:
            # Tenta obter o DeviceID primeiro
            device_id = None
            for id_attr in ["PNPDeviceID", "DeviceID", "Name"]:
                device_id = getattr(device, id_attr, None)
                if device_id:
                    break
            if not device_id:
                device_id = str(uuid.uuid4())

            # Tenta obter o nome/descrição
            description = None
            for attr in ["Caption", "Description", "Name", "DeviceID"]:
                description = getattr(device, attr, None)
                if description and description != "<unknown>":
                    break
            if not description:
                description = "Desconhecido"

            # Tenta obter o fabricante
            manufacturer = getattr(device, "Manufacturer", None)
            if not manufacturer or manufacturer == "<unknown>":
                manufacturer = getattr(device, "Caption", "Desconhecido").split()[0]

            # Tenta obter informações adicionais
            model = getattr(device, "Model", "")
            size = getattr(device, "Size", 0)
            if size:
                size = int(size) / (1024 * 1024 * 1024)  # Converte para GB
                size_str = f"{size:.1f}GB"
            else:
                size_str = ""

            device_info = {
                "device_id": device_id,
                "description": f"{description} {size_str}".strip(),
                "manufacturer": manufacturer,
                "model": model,
                "timestamp": datetime.now().strftime("%Y-%m-%d %H:%M:%S")
            }

            return device_info

        except Exception as e:
            log_event("ERRO", f"Erro ao obter informações do dispositivo: {e}")
            return {
                "device_id": str(uuid.uuid4()),
                "description": "Erro ao obter informações",
                "manufacturer": "Erro",
                "model": "",
                "timestamp": datetime.now().strftime("%Y-%m-%d %H:%M:%S")
            }

    def get_usb_device_info(self):
        """Obtém informações detalhadas do dispositivo USB."""
        usb_devices = []
        try:
            # Primeiro procura dispositivos de armazenamento USB
            for device in self.wmi.InstancesOf("Win32_DiskDrive"):
                try:
                    if hasattr(device, 'InterfaceType') and device.InterfaceType == "USB":
                        device_info = self.get_device_info(device)
                        # Verifica se não é um dispositivo do sistema
                        if not self.is_system_device(device_info['device_id']):
                            device_info['type'] = "Storage"
                            usb_devices.append(device_info)
                            log_event("INFO", f"Dispositivo de armazenamento USB detectado: {device_info['description']}")
                except Exception as e:
                    log_event("AVISO", f"Erro ao processar dispositivo de armazenamento: {e}")

            # Depois procura outros dispositivos USB via PnPEntity
            for device in self.wmi.InstancesOf("Win32_PnPEntity"):
                try:
                    if hasattr(device, 'PNPDeviceID'):
                        device_id = device.PNPDeviceID
                        # Verifica se é um dispositivo USB e não foi já detectado como armazenamento
                        if ('USB' in device_id or 'USBSTOR' in device_id) and ('VID_' in device_id or 'PID_' in device_id):
                            # Verifica se já não temos este dispositivo e se não é um dispositivo do sistema
                            if not any(d['device_id'] == device_id for d in usb_devices) and not self.is_system_device(device_id):
                                device_info = self.get_device_info(device)
                                device_info['type'] = "Generic"
                                usb_devices.append(device_info)
                except Exception as e:
                    log_event("AVISO", f"Erro ao processar dispositivo PnP: {e}")

            # Por fim, tenta Win32_USBHub para dispositivos que possam ter sido perdidos
            if not usb_devices:
                for device in self.wmi.InstancesOf("Win32_USBHub"):
                    try:
                        device_info = self.get_device_info(device)
                        # Verifica se não é um dispositivo do sistema
                        if not self.is_system_device(device_info['device_id']):
                            device_info['type'] = "Hub"
                            if not any(d['device_id'] == device_info['device_id'] for d in usb_devices):
                                usb_devices.append(device_info)
                    except Exception as e:
                        log_event("AVISO", f"Erro ao processar USB Hub: {e}")

            return usb_devices

        except Exception as e:
            log_event("ERRO", f"Erro ao obter informações USB: {e}")
            return []

    def is_system_device(self, device_id):
        """Verifica se o dispositivo é um dispositivo do sistema."""
        return any(sys_dev in device_id.upper() for sys_dev in self.system_devices)

class USBMonitor(BaseMonitor):
    def __init__(self, config_file="config.json"):
        super().__init__(config_file)
        self._window_handle = None
        self._window_class = None
        self._class_name = f"USBMonitorWindow_{uuid.uuid4().hex}"
        self._running = False
        self._last_devices = set()
        self._device_change_pending = False
        self._last_check_time = 0

    def cleanup(self):
        """Limpa recursos do monitor."""
        try:
            # Primeiro para o monitoramento
            self._running = False
            time.sleep(0.2)  # Espera o loop terminar

            # Tenta destruir a janela se existir
            if self._window_handle:
                try:
                    if win32gui.IsWindow(self._window_handle):
                        win32gui.SendMessage(self._window_handle, win32con.WM_CLOSE, 0, 0)
                        time.sleep(0.1)  # Espera a mensagem ser processada
                        if win32gui.IsWindow(self._window_handle):
                            win32gui.DestroyWindow(self._window_handle)
                except:
                    pass
                self._window_handle = None

            # Tenta desregistrar a classe
            if self._window_class:
                try:
                    hinstance = win32gui.GetModuleHandle(None)
                    # Tenta várias vezes desregistrar a classe
                    for _ in range(3):
                        try:
                            win32gui.UnregisterClass(self._class_name, hinstance)
                            break
                        except:
                            time.sleep(0.1)
                except:
                    pass
                self._window_class = None

        except:
            pass
        finally:
            self._window_handle = None
            self._window_class = None
            self._running = False

    def initialize_monitor(self):
        """Inicializa o monitor, registrando a classe de janela."""
        try:
            # Garante que tudo está limpo
            self.cleanup()
            time.sleep(0.2)  # Espera a limpeza completar

            # Cria uma nova classe com nome único
            wc = win32gui.WNDCLASS()
            wc.lpfnWndProc = self._window_proc
            wc.lpszClassName = self._class_name
            wc.hInstance = win32gui.GetModuleHandle(None)

            # Registra a classe
            self._window_class = win32gui.RegisterClass(wc)

            # Cria a janela
            style = win32con.WS_OVERLAPPED
            self._window_handle = win32gui.CreateWindowEx(
                0,
                self._window_class,
                "USB Monitor",
                style,
                0, 0, 1, 1,  # x, y, width, height
                0,  # parent
                0,  # menu
                wc.hInstance,
                None
            )

            if not self._window_handle or not win32gui.IsWindow(self._window_handle):
                raise Exception("Falha ao criar janela de monitoramento")

            # Inicializa a lista de dispositivos
            self._last_devices = {device['device_id'] for device in self.get_usb_device_info()}
            self._devices = self._last_devices.copy()
            self._running = True

            return True

        except Exception as e:
            log_event("ERRO", f"Falha na inicialização do monitor: {e}")
            self.cleanup()
            raise Exception(f"Erro ao iniciar monitor: {e}")

    def _window_proc(self, hwnd, msg, wparam, lparam):
        """Procedimento de janela para processar mensagens do Windows."""
        if msg == win32con.WM_DEVICECHANGE:
            # Marca que houve mudança e agenda uma verificação
            self._device_change_pending = True
            return True
        return win32gui.DefWindowProc(hwnd, msg, wparam, lparam)

    def _check_devices(self):
        """Verifica mudanças nos dispositivos conectados."""
        try:
            current_time = time.time()
            # Limita verificações a cada 1 segundo
            if current_time - self._last_check_time < 1:
                return
            
            self._last_check_time = current_time
            current_devices = set()
            
            # Verifica dispositivos de armazenamento primeiro
            for device in self.wmi.InstancesOf("Win32_DiskDrive"):
                try:
                    if hasattr(device, 'InterfaceType') and device.InterfaceType == "USB":
                        device_info = self.get_device_info(device)
                        current_devices.add(device_info['device_id'])
                        if device_info['device_id'] not in self._last_devices:
                            self.handle_usb_event("conectado", device_info)
                except Exception as e:
                    log_event("AVISO", f"Erro ao verificar dispositivo de armazenamento: {e}")
            
            # Verifica outros dispositivos USB
            for device in self.wmi.InstancesOf("Win32_PnPEntity"):
                try:
                    if hasattr(device, 'PNPDeviceID'):
                        device_id = device.PNPDeviceID
                        if ('USB' in device_id or 'USBSTOR' in device_id) and not any(d == device_id for d in current_devices):
                            device_info = self.get_device_info(device)
                            current_devices.add(device_info['device_id'])
                            if device_info['device_id'] not in self._last_devices:
                                self.handle_usb_event("conectado", device_info)
                except Exception as e:
                    log_event("AVISO", f"Erro ao verificar dispositivo PnP: {e}")
            
            # Verifica dispositivos removidos
            removed_devices = self._last_devices - current_devices
            for device_id in removed_devices:
                self.handle_usb_event("removido", {"device_id": device_id})
            
            self._last_devices = current_devices
            self._device_change_pending = False
            
        except Exception as e:
            log_event("ERRO", f"Erro ao verificar dispositivos: {e}")

    def handle_usb_event(self, event_type, device_info):
        """Gerencia eventos USB (conexão/remoção)."""
        try:
            if event_type == "conectado":
                # Ignora dispositivos do sistema
                if self.is_system_device(device_info['device_id']):
                    return

                info_str = f"ID: {device_info['device_id']}\nDescrição: {device_info.get('description', 'N/A')}\nFabricante: {device_info.get('manufacturer', 'N/A')}"
                
                # Verifica whitelist primeiro
                device_id = device_info['device_id']
                is_allowed = self.whitelist_manager.is_device_allowed(device_id)
                log_event("DEBUG", f"Verificando dispositivo {device_id} - Autorizado: {is_allowed}")
                
                if not is_allowed:
                    log_event("ALERTA", f"USB NÃO AUTORIZADO: {info_str}")
                    disable_usb_device(device_id)
                    send_email_alert(device_id)
                else:
                    log_event("INFO", f"Dispositivo autorizado conectado: {info_str}")
                
                self._devices.add(device_id)
            
            elif event_type == "removido":
                # Não processa remoção de dispositivos do sistema
                if not self.is_system_device(device_info['device_id']):
                    log_event("INFO", f"Dispositivo removido: {device_info['device_id']}")
                    self._devices.discard(device_info['device_id'])
                    reset_alert(device_info['device_id'])
                
        except Exception as e:
            log_event("ERRO", f"Erro ao processar evento USB: {e}")

    def check_usb_device(self, device_id):
        """Verifica se um USB está autorizado."""
        is_allowed = self.whitelist_manager.is_device_allowed(device_id)
        log_event("DEBUG", f"Verificando autorização do dispositivo {device_id} - Resultado: {is_allowed}")
        return is_allowed

    def start_monitoring(self):
        """Inicia o monitoramento baseado em eventos."""
        try:
            if not self.initialize_monitor():
                raise Exception("Falha na inicialização do monitor")

            log_event("INFO", "Monitoramento USB iniciado.")
            
            # Faz uma verificação inicial dos dispositivos
            self._check_devices()

            while self._running:
                try:
                    # Processa mensagens
                    win32gui.PumpWaitingMessages()
                    
                    # Se houver mudança pendente, verifica os dispositivos
                    if self._device_change_pending:
                        self._check_devices()
                    
                    # Verifica se a janela ainda existe
                    if not win32gui.IsWindow(self._window_handle):
                        log_event("ERRO", "Janela do monitor foi fechada")
                        break
                        
                    time.sleep(0.1)  # Pequena pausa para não sobrecarregar a CPU

                except Exception as e:
                    if "invalid window handle" in str(e).lower():
                        break
                    log_event("ERRO", f"Erro no loop de mensagens: {str(e)}")
                    time.sleep(1)

        except Exception as e:
            log_event("ERRO", f"Erro fatal no monitoramento: {e}")
            raise
        finally:
            self.cleanup()

    def stop_monitoring(self):
        """Para o monitoramento USB."""
        try:
            self._running = False
            time.sleep(0.2)  # Espera o loop terminar
            self.cleanup()
            log_event("INFO", "Monitoramento parado com sucesso")
        except Exception as e:
            log_event("ERRO", f"Erro ao parar monitoramento: {e}")
            raise

    def check_devices(self):
        """Verifica os dispositivos USB conectados e bloqueia os não autorizados."""
        try:
            print("\n[INFO] Verificando dispositivos USB conectados...")
            devices = self.get_usb_device_info()
            
            if not devices:
                print("[INFO] Nenhum dispositivo USB encontrado.")
                return
            
            print("\n[INFO] Dispositivos USB encontrados:")
            for device in devices:
                print(f"  - {device['description']} (VID/PID: {device['device_id']})")
            
            # Verifica se há dispositivos não autorizados
            unauthorized = [d for d in devices if d['device_id'] not in self.whitelist_manager.get_allowed_devices()]
            
            if unauthorized:
                print("\n[ALERTA] Dispositivos não autorizados encontrados:")
                for device in unauthorized:
                    print(f"  - {device['description']} (VID/PID: {device['device_id']})")
                    print(f"  [INFO] Tentando bloquear dispositivo...")
                    if disable_usb_device(device['device_id']):
                        print(f"  [SUCESSO] Dispositivo {device['device_id']} bloqueado com sucesso!")
                    else:
                        print(f"  [ERRO] Falha ao bloquear dispositivo {device['device_id']}")
            else:
                print("\n[INFO] Todos os dispositivos USB são autorizados.")
            
        except Exception as e:
            print(f"[ERRO] Falha ao verificar dispositivos: {e}") 