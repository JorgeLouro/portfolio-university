import smtplib
import ssl
import logging
from email.message import EmailMessage
from datetime import datetime

# Configurações do e-mail
EMAIL_SENDER = "duartemartinsribeiro@gmail.com"  # Substituir pelo teu e-mail
EMAIL_PASSWORD = "left gnba rtxs mygf"  # Criar uma App Password se usares Gmail
EMAIL_RECEIVER = "duartemartinsribeiro@gmail.com"  # E-mail para onde os alertas serão enviados

# Lista de dispositivos que já receberam alerta
alerted_devices = {}

def send_email_alert(device_id):
    """
    Envia um e-mail de alerta quando um dispositivo USB não autorizado é detectado.
    Garante que um e-mail é enviado **apenas uma vez a cada 30 minutos por dispositivo**.
    
    :param device_id: O ID do dispositivo USB suspeito
    """
    try:
        agora = datetime.now()
        tempo_limite = alerted_devices.get(device_id, None)
        
        if tempo_limite and (agora - tempo_limite).total_seconds() < 1800:
            return  # Se o último alerta foi enviado há menos de 30 minutos, não envia outro e-mail

        subject = "⚠️ Alerta de Segurança - USB Não Autorizado Detectado!"
        body = f"""
        Um dispositivo USB desconhecido foi conectado ao sistema.
        
        🔍 **Detalhes do dispositivo:**  
        📌 ID: {device_id}
        
        🚨 Verifica este evento imediatamente para garantir a segurança do sistema.
        """

        msg = EmailMessage()
        msg.set_content(body)
        msg["Subject"] = subject
        msg["From"] = EMAIL_SENDER
        msg["To"] = EMAIL_RECEIVER

        # Conectar ao servidor SMTP
        context = ssl.create_default_context()
        with smtplib.SMTP_SSL("smtp.gmail.com", 465, context=context) as server:
            server.login(EMAIL_SENDER, EMAIL_PASSWORD)
            server.send_message(msg)

        print(f"[EMAIL] Alerta enviado para {EMAIL_RECEIVER} sobre o dispositivo: {device_id}")
        logging.info(f"[EMAIL] Alerta enviado para {EMAIL_RECEIVER} sobre o dispositivo: {device_id}")
        alerted_devices[device_id] = agora  # Atualiza o tempo do último alerta

    except Exception as e:
        logging.error(f"[ERRO] Falha ao enviar e-mail: {e}", exc_info=True)

def reset_alert(device_id):
    """
    Remove um dispositivo da lista de alertados quando ele for desconectado.
    
    :param device_id: O ID do dispositivo USB removido
    """
    if device_id in alerted_devices:
        del alerted_devices[device_id]
        logging.info(f"[INFO] Alerta resetado para {device_id}")
