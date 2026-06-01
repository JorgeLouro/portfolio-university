document.addEventListener("DOMContentLoaded", function () {
    updateDeviceList();
    updateWhitelist();
    updateMonitorStatus();

    document.getElementById("start-monitor").addEventListener("click", startMonitoring);
    document.getElementById("stop-monitor").addEventListener("click", stopMonitoring);
    document.getElementById("add-whitelist").addEventListener("click", addToWhitelist);
    document.getElementById("download-logs").addEventListener("click", downloadLogs);
    document.getElementById("filter-devices").addEventListener("input", filterDevices);
    document.getElementById("clear-whitelist").addEventListener("click", clearWhitelist);
    document.getElementById("refresh-devices").addEventListener("click", updateDeviceList);
});

function updateDeviceList() {
    fetch("/api/devices")
        .then(response => response.json())
        .then(data => {
            const list = document.getElementById("device-list");
            list.innerHTML = "";
            if (data.connected_devices && data.connected_devices.length > 0) {
                data.connected_devices.forEach(device => {
                    const li = document.createElement("li");
                    const status = device.authorized ? "✅" : "❌";
                    li.textContent = `${status} ${device.id}`;
                    li.className = device.authorized ? "authorized" : "unauthorized";
                    if (!device.authorized) {
                        const btn = document.createElement("button");
                        btn.textContent = "Autorizar";
                        btn.className = "authorize-btn";
                        btn.onclick = function() {
                            fetch("/api/whitelist", {
                                method: "POST",
                                headers: { "Content-Type": "application/json" },
                                body: JSON.stringify({ device_id: device.id })
                            })
                                .then(response => response.json())
                                .then(data => {
                                    alert(data.message || "Dispositivo autorizado!");
                                    updateWhitelist();
                                    updateDeviceList();
                                })
                                .catch(error => {
                                    alert("Erro ao autorizar dispositivo.");
                                });
                        };
                        li.appendChild(document.createTextNode(" "));
                        li.appendChild(btn);
                    }
                    list.appendChild(li);
                });
            } else {
                const li = document.createElement("li");
                li.textContent = "Nenhum dispositivo conectado";
                list.appendChild(li);
            }
        })
        .catch(error => {
            console.error("Erro ao atualizar lista de dispositivos:", error);
        });
}

function updateWhitelist() {
    fetch("/api/whitelist")
        .then(response => response.json())
        .then(data => {
            const list = document.getElementById("whitelist");
            list.innerHTML = "";
            if (data.whitelist && data.whitelist.length > 0) {
                data.whitelist.forEach(device => {
                    const li = document.createElement("li");
                    li.textContent = device;
                    list.appendChild(li);
                });
            } else {
                const li = document.createElement("li");
                li.textContent = "Nenhum dispositivo na whitelist";
                list.appendChild(li);
            }
        })
        .catch(error => {
            console.error("Erro ao atualizar whitelist:", error);
        });
}

function startMonitoring() {
    const startButton = document.getElementById("start-monitor");
    const stopButton = document.getElementById("stop-monitor");
    
    startButton.disabled = true;
    stopButton.disabled = true;
    
    fetch("/api/start_monitoring", { method: "POST" })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            updateMonitorStatus();
            alert(data.message);
        })
        .catch(error => {
            console.error("Erro ao iniciar monitor:", error);
            alert("Erro ao iniciar monitor. Verifique o console para mais detalhes.");
        })
        .finally(() => {
            startButton.disabled = false;
            stopButton.disabled = false;
        });
}

function stopMonitoring() {
    const startButton = document.getElementById("start-monitor");
    const stopButton = document.getElementById("stop-monitor");
    
    startButton.disabled = true;
    stopButton.disabled = true;
    
    fetch("/api/stop_monitoring", { method: "POST" })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            updateMonitorStatus();
            alert(data.message);
        })
        .catch(error => {
            console.error("Erro ao parar monitor:", error);
            alert("Erro ao parar monitor. Verifique o console para mais detalhes.");
        })
        .finally(() => {
            startButton.disabled = false;
            stopButton.disabled = false;
        });
}

function updateMonitorStatus() {
    fetch("/api/status")
        .then(response => response.json())
        .then(data => {
            const statusElement = document.getElementById("monitor-status");
            const isActive = data.status === "ativo";
            
            statusElement.textContent = isActive ? "Ativo" : "Parado";
            statusElement.className = isActive ? "running" : "stopped";
            
            // Atualiza o estado dos botões
            document.getElementById("start-monitor").disabled = isActive;
            document.getElementById("stop-monitor").disabled = !isActive;
        })
        .catch(error => {
            console.error("Erro ao atualizar status:", error);
        });
}

function addToWhitelist() {
    const deviceId = document.getElementById("whitelist-input").value.trim();
    if (!deviceId) {
        alert("Por favor, insira um ID de dispositivo.");
        return;
    }

    // Valida o formato do ID
    const upperDeviceId = deviceId.toUpperCase();
    if (!upperDeviceId.includes("VID_") || !upperDeviceId.includes("PID_")) {
        alert("Formato de ID inválido. O ID deve conter VID e PID (exemplo: USB\\VID_1234&PID_5678)");
        return;
    }
    
    fetch("/api/whitelist", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ device_id: deviceId })
    })
        .then(response => {
            if (!response.ok) {
                return response.json().then(data => {
                    throw new Error(data.error || "Erro ao adicionar dispositivo");
                });
            }
            return response.json();
        })
        .then(data => {
            alert(data.message);
            document.getElementById("whitelist-input").value = "";
            updateWhitelist();
        })
        .catch(error => {
            console.error("Erro ao adicionar à whitelist:", error);
            alert(error.message || "Erro ao adicionar dispositivo à whitelist.");
        });
}

function downloadLogs() {
    window.location.href = "/api/download_logs";
}

function filterDevices() {
    const filter = document.getElementById("filter-devices").value.toLowerCase();
    document.querySelectorAll("#device-list li").forEach(li => {
        li.style.display = li.textContent.toLowerCase().includes(filter) ? "block" : "none";
    });
}

function clearWhitelist() {
    if (!confirm("Tem certeza que deseja limpar toda a whitelist?")) return;
    fetch("/api/whitelist", {
        method: "DELETE",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({})
    })
        .then(response => response.json())
        .then(data => {
            alert(data.message || "Whitelist limpa!");
            updateWhitelist();
        })
        .catch(error => {
            alert("Erro ao limpar whitelist.");
        });
}