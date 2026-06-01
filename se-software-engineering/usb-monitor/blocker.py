import winreg
import win32com.client
import os

def format_device_id(vid_pid):
    """Formata o ID do dispositivo para diferentes padrões de busca."""
    # Remove caracteres especiais e espaços e normaliza barras invertidas
    vid_pid = vid_pid.strip().upper().replace('\\\\', '\\')
    
    # Extrai VID e PID se presentes
    vid = pid = None
    if 'VID_' in vid_pid and 'PID_' in vid_pid:
        try:
            vid = vid_pid.split('VID_')[1].split('&')[0]
            pid = vid_pid.split('PID_')[1].split('\\')[0]
        except:
            pass
    
    patterns = [vid_pid]  # Padrão original
    
    if vid and pid:
        # Adiciona variações comuns do formato
        patterns.extend([
            f"VID_{vid}&PID_{pid}",
            f"USB\\VID_{vid}&PID_{pid}",
            f"USB\\VID_{vid}&PID_{pid}\\",
            f"*VID_{vid}*PID_{pid}*"
        ])
    
    return patterns

def find_device_in_registry(key, patterns):
    """Procura recursivamente por um dispositivo no registro."""
    try:
        for i in range(0, winreg.QueryInfoKey(key)[0]):
            try:
                subkey_name = winreg.EnumKey(key, i)
                
                # Verifica se o nome da chave corresponde a algum dos padrões
                if any(pattern.upper() in subkey_name.upper() for pattern in patterns):
                    return subkey_name
                
                # Tenta abrir a subchave
                try:
                    with winreg.OpenKey(key, subkey_name, 0, winreg.KEY_READ) as subkey:
                        result = find_device_in_registry(subkey, patterns)
                        if result:
                            return f"{subkey_name}\\{result}"
                except:
                    continue
                    
            except WindowsError:
                continue
    except WindowsError:
        pass
    return None

def disable_usb_device(vid_pid):
    """Desativa o dispositivo USB ou HID com o VID/PID especificado."""
    try:
        # Gera padrões de busca para o dispositivo
        patterns = format_device_id(vid_pid)
        
        # Lista de caminhos do registro para procurar
        registry_paths = [
            (winreg.HKEY_LOCAL_MACHINE, r"SYSTEM\CurrentControlSet\Enum\USB"),
            (winreg.HKEY_LOCAL_MACHINE, r"SYSTEM\CurrentControlSet\Enum\USBSTOR"),
            (winreg.HKEY_LOCAL_MACHINE, r"SYSTEM\CurrentControlSet\Control\Class\{36FC9E60-C465-11CF-8056-444553540000}"),
            (winreg.HKEY_LOCAL_MACHINE, r"SYSTEM\CurrentControlSet\Control\DeviceClasses"),
            (winreg.HKEY_LOCAL_MACHINE, r"SYSTEM\CurrentControlSet\Services\USBSTOR"),
            (winreg.HKEY_LOCAL_MACHINE, r"SYSTEM\CurrentControlSet\Control\usbflags"),
        ]
        
        device_found = False
        
        for root_key, path in registry_paths:
            try:
                with winreg.OpenKey(root_key, path, 0, winreg.KEY_READ | winreg.KEY_WRITE) as key:
                    device_path = find_device_in_registry(key, patterns)
                    if device_path:
                        device_found = True
                        full_path = f"{path}\\{device_path}"
                        
                        try:
                            # Tenta bloquear via Device Parameters
                            try:
                                with winreg.OpenKey(root_key, full_path + "\\Device Parameters", 0, winreg.KEY_SET_VALUE) as device_params:
                                    winreg.SetValueEx(device_params, "EnhancedPowerManagementEnabled", 0, winreg.REG_DWORD, 1)
                            except FileNotFoundError:
                                pass
                            
                            # Bloqueia via ConfigFlags
                            with winreg.OpenKey(root_key, full_path, 0, winreg.KEY_SET_VALUE) as subkey:
                                winreg.SetValueEx(subkey, "ConfigFlags", 0, winreg.REG_DWORD, 1)
                                print(f"[SUCESSO] Dispositivo {vid_pid} bloqueado com sucesso.")
                                return True
                                
                        except PermissionError:
                            print(f"[ERRO] Permissão negada. Execute como administrador.")
                            return False
                        except Exception as e:
                            continue
                            
            except Exception:
                continue
        
        if not device_found:
            print(f"[ERRO] Dispositivo {vid_pid} não encontrado.")
            return False
            
    except Exception as e:
        print(f"[ERRO] Falha ao bloquear dispositivo: {e}")
        return False

def eject_usb_drives(vid_pid):
    """Ejeta drives USB associadas a determinado VID/PID."""
    try:
        # Isto apenas afeta unidades de armazenamento
        wmi = win32com.client.GetObject("winmgmts:")
        for disk in wmi.InstancesOf("Win32_DiskDrive"):
            pnp_id = getattr(disk, "PNPDeviceID", "")
            if vid_pid in pnp_id:
                for partition in disk.Associators("Win32_DiskDriveToDiskPartition"):
                    for logical_disk in partition.Associators("Win32_LogicalDiskToPartition"):
                        os.system(f"mountvol {logical_disk.DeviceID} /p")
                        print(f"[EJECTADO] Volume USB ejetado: {logical_disk.DeviceID}")
    except Exception as e:
        print(f"[ERRO] Falha ao ejetar volume USB: {e}")

def get_connected_usb_device_ids():
    """Obtém a lista de IDs de dispositivos USB e HID conectados."""
    ids = set()
    wmi = win32com.client.GetObject("winmgmts:")
    for device in wmi.InstancesOf("Win32_PnPEntity"):
        device_id = getattr(device, "DeviceID", "")
        if ("VID_" in device_id and "PID_" in device_id) and ("USB" in device_id or "HID" in device_id):
            ids.add(device_id.upper())
    return list(ids)
