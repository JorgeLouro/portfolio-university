import sys
import os
import ctypes
from flask import Flask, render_template, jsonify, request, send_file
import threading
import webbrowser
from logger import log_event

def is_admin():
    try:
        return ctypes.windll.shell32.IsUserAnAdmin()
    except:
        return False

def run_as_admin():
    if not is_admin():
        print("[INFO] Solicitando privilégios de administrador...")
        ctypes.windll.shell32.ShellExecuteW(None, "runas", sys.executable, " ".join(sys.argv), None, 1)
        sys.exit()

# Verifica e solicita privilégios de administrador
run_as_admin()

# Adiciona o diretório atual ao path para garantir que os módulos sejam encontrados
sys.path.append(os.path.dirname(os.path.abspath(__file__)))

from usbmon import USBMonitor
from whitelist import WhitelistManager

app = Flask(__name__)
monitor = None
whitelist_manager = WhitelistManager("config.json")
monitor_thread = None
running = False

@app.route("/")
def home():
    """Renderiza a página principal da interface web."""
    return render_template("index.html")

@app.route("/api/status", methods=["GET"])
def get_status():
    """Retorna o status atual do monitor."""
    global running
    return jsonify({"status": "ativo" if running else "parado"})

@app.route("/api/devices", methods=["GET"])
def get_devices():
    """Retorna a lista de dispositivos USB conectados."""
    global monitor, running
    try:
        if not running or not monitor:
            return jsonify({"connected_devices": [], "message": "Monitor não está ativo"})
        devices = monitor.get_devices()
        return jsonify({"connected_devices": devices})
    except Exception as e:
        print(f"[ERRO] Erro ao obter dispositivos: {e}")
        return jsonify({"connected_devices": [], "error": str(e)})

@app.route("/api/whitelist", methods=["GET", "POST", "DELETE"])
def manage_whitelist():
    """Gere a whitelist - listar, adicionar ou remover dispositivos."""
    if request.method == "GET":
        return jsonify({"whitelist": list(whitelist_manager.whitelist)})
    
    try:
        data = request.get_json()
        # Se DELETE e não há device_id, limpa toda a whitelist
        if request.method == "DELETE" and (not data or not data.get("device_id")):
            whitelist_manager.whitelist.clear()
            whitelist_manager.save_config()
            return jsonify({"message": "Whitelist limpa com sucesso."}), 200
        if not data:
            return jsonify({"error": "Dados JSON inválidos"}), 400
        
        device_id = data.get("device_id")
        if not device_id:
            return jsonify({"error": "ID do dispositivo não fornecido"}), 400
        
        # Valida o formato do device_id (deve conter VID e PID)
        if not ("VID_" in device_id.upper() and "PID_" in device_id.upper()):
            return jsonify({"error": "Formato de ID inválido. Deve conter VID e PID"}), 400

        if request.method == "POST":
            whitelist_manager.add_device(device_id)
            return jsonify({"message": f"{device_id} adicionado à whitelist"}), 201
        
        if request.method == "DELETE":
            if device_id not in whitelist_manager.whitelist:
                return jsonify({"error": "Dispositivo não encontrado na whitelist"}), 404
            whitelist_manager.remove_device(device_id)
            return jsonify({"message": f"{device_id} removido da whitelist"}), 200
            
    except Exception as e:
        print(f"[ERRO] Erro ao gerenciar whitelist: {e}")
        return jsonify({"error": "Erro interno ao processar requisição"}), 500

@app.route("/api/start_monitoring", methods=["POST"])
def start_monitoring():
    """Inicia a monitorização USB em uma thread separada."""
    global monitor_thread, running, monitor

    if running:
        return jsonify({"message": "Monitor já está em execução"}), 400

    try:
        from datetime import datetime
        log_event("SESSAO", f"=== INICIO SESSAO: {datetime.now().strftime('%Y-%m-%d %H:%M:%S')} ===")
        monitor = USBMonitor()
        # Tenta inicializar o monitor primeiro
        try:
            monitor.initialize_monitor()
        except Exception as init_error:
            error_msg = f"Erro ao inicializar monitor: {str(init_error)}"
            print(f"[ERRO] {error_msg}")
            return jsonify({"error": error_msg}), 500

        running = True
        monitor_thread = threading.Thread(target=monitor.start_monitoring, daemon=True)
        monitor_thread.start()
        return jsonify({"message": "Monitor de USB iniciado"}), 200
    except Exception as e:
        error_msg = f"Falha ao iniciar monitor: {str(e)}"
        print(f"[ERRO] {error_msg}")
        running = False
        monitor = None
        return jsonify({"error": error_msg}), 500

@app.route("/api/stop_monitoring", methods=["POST"])
def stop_monitoring():
    """Para a monitorização USB."""
    global running, monitor
    if running:
        running = False
        if monitor:
            monitor.stop_monitoring()
            monitor = None
        return jsonify({"message": "Monitor de USB parado"}), 200
    return jsonify({"message": "Monitor já está parado"}), 400

@app.route("/api/download_logs", methods=["GET"])
def download_logs():
    try:
        session_marker = "=== INICIO SESSAO:"
        with open("usb_monitor.log", "r", encoding="latin1") as f:
            lines = f.readlines()
        # Encontrar o índice da última linha de início de sessão
        last_session_idx = None
        for idx, line in enumerate(lines):
            if session_marker in line:
                last_session_idx = idx
        # Se encontrou, pega só os logs dessa sessão
        if last_session_idx is not None:
            session_lines = lines[last_session_idx:]
        else:
            session_lines = lines
        # Escreve em um arquivo temporário
        temp_path = "usb_monitor_session.log"
        with open(temp_path, "w", encoding="latin1") as f:
            f.writelines(session_lines)
        return send_file(temp_path, as_attachment=True)
    except Exception as e:
        print(f"[ERRO] Erro ao baixar logs: {e}")
        return jsonify({"error": "Erro ao baixar logs."}), 500

def open_browser():
    """Abre o navegador após um pequeno delay para garantir que o servidor está rodando."""
    import time
    time.sleep(1.5)  # Espera 1.5 segundos
    webbrowser.open('http://127.0.0.1:5000/')

if __name__ == "__main__":
    # Inicia o navegador em uma thread separada
    threading.Thread(target=open_browser, daemon=True).start()
    
    # Inicia o servidor Flask
    app.run(debug=True, use_reloader=False, host='127.0.0.1', port=5000)
