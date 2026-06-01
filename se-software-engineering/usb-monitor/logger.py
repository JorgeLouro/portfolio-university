import logging
from datetime import datetime

# Configuração do logger
LOG_FILE = "usb_monitor.log"

logging.basicConfig(
    filename=LOG_FILE,
    level=logging.DEBUG,  # Agora captura mais detalhes, incluindo debug
    format="%(asctime)s - %(levelname)s - %(message)s",
    datefmt="%Y-%m-%d %H:%M:%S"
)

def log_event(event_type, device_id):
    """
    Regista eventos de dispositivos USB no ficheiro de log.

    :param event_type: Tipo de evento (Conectado, Removido, Alerta)
    :param device_id: Identificador do dispositivo USB
    """
    log_message = f"{event_type} - {device_id}"
    
    if event_type == "ALERTA":
        logging.warning(log_message)  # Se for um alerta, regista como WARNING
    else:
        logging.info(log_message)  # Caso contrário, regista como INFO

    print(f"[LOG] {log_message}")  # Exibe também no terminal
