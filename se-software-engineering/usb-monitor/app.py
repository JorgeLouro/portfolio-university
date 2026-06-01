from flask import Flask, jsonify, request
from flask_cors import CORS
from usbmon import USBMonitor
from logger import log_event
import threading
import os

app = Flask(__name__)

# Configuração específica do CORS
CORS(app, resources={
    r"/api/*": {
        "origins": ["*"],
        "methods": ["GET", "POST", "OPTIONS"],
        "allow_headers": ["Content-Type"]
    }
})

# Inicializa o monitor USB
monitor = USBMonitor()

@app.route('/')
def index():
    """Rota principal que retorna a página inicial."""
    return jsonify({"status": "ok", "message": "USB Monitor API está rodando"})

@app.route('/api/status', methods=['GET'])
def get_status():
    """Retorna o status atual do monitoramento."""
    try:
        status = monitor.is_monitoring()
        return jsonify({
            "status": "success",
            "monitoring": status,
            "message": "Monitoramento ativo" if status else "Monitoramento inativo"
        })
    except Exception as e:
        log_event("ERRO", f"Erro ao obter status: {e}")
        return jsonify({"status": "error", "message": str(e)}), 500

@app.route('/api/devices', methods=['GET'])
def get_devices():
    """Retorna a lista de dispositivos USB conectados."""
    try:
        devices = monitor.get_devices()
        return jsonify({
            "status": "success",
            "devices": devices
        })
    except Exception as e:
        log_event("ERRO", f"Erro ao obter dispositivos: {e}")
        return jsonify({"status": "error", "message": str(e)}), 500

@app.route('/api/start_monitoring', methods=['POST'])
def start_monitoring():
    """Inicia o monitoramento de dispositivos USB."""
    try:
        if not monitor.is_monitoring():
            monitor.start()
            return jsonify({
                "status": "success",
                "message": "Monitoramento iniciado com sucesso"
            })
        return jsonify({
            "status": "info",
            "message": "Monitoramento já está em execução"
        })
    except Exception as e:
        log_event("ERRO", f"Erro ao iniciar monitoramento: {e}")
        return jsonify({"status": "error", "message": str(e)}), 500

@app.route('/api/stop_monitoring', methods=['POST'])
def stop_monitoring():
    """Para o monitoramento de dispositivos USB."""
    try:
        if monitor.is_monitoring():
            monitor.stop()
            return jsonify({
                "status": "success",
                "message": "Monitoramento parado com sucesso"
            })
        return jsonify({
            "status": "info",
            "message": "Monitoramento já está parado"
        })
    except Exception as e:
        log_event("ERRO", f"Erro ao parar monitoramento: {e}")
        return jsonify({"status": "error", "message": str(e)}), 500

@app.route('/api/check_devices', methods=['POST'])
def check_devices():
    """Verifica os dispositivos USB conectados e bloqueia os não autorizados."""
    try:
        monitor.check_devices()
        return jsonify({
            "status": "success",
            "message": "Verificação de dispositivos concluída"
        })
    except Exception as e:
        log_event("ERRO", f"Erro ao verificar dispositivos: {e}")
        return jsonify({"status": "error", "message": str(e)}), 500

if __name__ == '__main__':
    # Configura o host e porta
    host = '0.0.0.0'
    port = int(os.environ.get('PORT', 5000))
    
    # Inicia o servidor Flask
    app.run(host=host, port=port, debug=True) 