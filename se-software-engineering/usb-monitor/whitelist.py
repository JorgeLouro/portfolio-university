import json
from logger import log_event

class WhitelistManager:
    def __init__(self, config_file="config.json"):
        self.config_file = config_file
        self.load_config()

    def load_config(self):
        """Carrega a configuração do ficheiro."""
        try:
            with open(self.config_file, "r") as file:
                data = json.load(file)
                usb_monitor_config = data.get("usb_monitor", {})
                self.whitelist = set(usb_monitor_config.get("allowed_devices", []))
                self.settings = usb_monitor_config.get("settings", {})
                self.system_settings = data.get("system_settings", {})
        except (FileNotFoundError, json.JSONDecodeError) as e:
            log_event("ERRO", f"Erro ao carregar configuração: {str(e)}")
            self.whitelist = set()
            self.settings = {
                "email_notifications": True,
                "email_recipient": "",
                "check_interval": 5,
                "log_level": "INFO"
            }
            self.system_settings = {
                "network": {
                    "proxy_enabled": False,
                    "proxy_server": "",
                    "proxy_port": 0
                },
                "security": {
                    "auto_block_unauthorized": True,
                    "block_system_devices": False
                },
                "ui": {
                    "theme": "dark",
                    "language": "pt-BR"
                }
            }
            self.save_config()

    def save_config(self):
        """Guarda a configuração no ficheiro."""
        with open(self.config_file, "w") as file:
            json.dump({
                "usb_monitor": {
                    "allowed_devices": list(self.whitelist),
                    "settings": self.settings
                },
                "system_settings": self.system_settings
            }, file, indent=4)

    def add_device(self, device_id):
        """Adiciona um dispositivo à whitelist."""
        self.whitelist.add(device_id)
        self.save_config()

    def remove_device(self, device_id):
        """Remove um dispositivo da whitelist."""
        self.whitelist.discard(device_id)
        self.save_config()

    def is_device_allowed(self, device_id):
        """Verifica se um dispositivo está na whitelist."""
        # Normaliza o ID do dispositivo
        normalized_device_id = device_id.upper().strip()
        
        # Normaliza a whitelist
        whitelist_normalized = [wid.upper().strip() for wid in self.whitelist]
        
        # Verifica correspondência exata
        is_allowed = normalized_device_id in whitelist_normalized
        
        return is_allowed

    def get_allowed_devices(self):
        """Retorna a lista de dispositivos autorizados."""
        return list(self.whitelist)

    def get_settings(self):
        """Retorna as configurações do monitor USB."""
        return self.settings

    def get_system_settings(self):
        """Retorna as configurações do sistema."""
        return self.system_settings

    def update_settings(self, new_settings):
        """Atualiza as configurações do monitor USB."""
        self.settings.update(new_settings)
        self.save_config()

    def update_system_settings(self, new_settings):
        """Atualiza as configurações do sistema."""
        self.system_settings.update(new_settings)
        self.save_config()
