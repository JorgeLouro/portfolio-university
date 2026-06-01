window.onload = function () {
    var canvas = document.getElementById("glCanvas");
    var gl = WebGLUtils.setupWebGL(canvas);
    if (!gl) {
        alert("WebGL não está disponível");
        return;
    }

    var program = initShaders(gl, "vertex-shader", "fragment-shader");
    gl.useProgram(program);

    // Definir os vértices do semáforo
    var vertices = [
        // Caixa do semáforo (frente)
        -0.1, -0.3,  0.1,
         0.1, -0.3,  0.1,
         0.1,  0.3,  0.1,
        -0.1,  0.3,  0.1,
        // Caixa do semáforo (trás)
        -0.2, -0.3, -0.1,
        -0.2,  0.3, -0.1,
         0.1,  0.3, -0.1,
         0.1, -0.3, -0.1,
        // Suporte (base)
        -0.05, -0.5,  0.05,
         0.05, -0.5,  0.05,
         0.05, -0.3,  0.05,
        -0.05, -0.3,  0.05,
        // Suporte (trás)
        -0.1, -0.51, -0.05,
        -0.1, -0.3, -0.05,
         0.05, -0.3, -0.05,
         0.05, -0.5, -0.05,
        // Triângulo (pirâmide) no topo da caixa
         -0.03,  0.4,  0.0,  // Vértice superior
        -0.1,  0.3,  0.1,  // Vértice inferior esquerdo (frente)
         0.1,  0.3,  0.1,  // Vértice inferior direito (frente)
         -0.2,  0.3, -0.1,  // Vértice inferior direito (trás)
        -0.1,  0.3, -0.1,  // Vértice inferior esquerdo (trás)
    ];

    // Função para adicionar vértices dos círculos
    function createCircleVertices(centerX, centerY, centerZ, radius, numSegments) {
        let vertices = [];
        let angleStep = Math.PI * 2 / numSegments;
        for (let i = 0; i <= numSegments; i++) {
            let angle = i * angleStep;
            let x = centerX + radius * Math.cos(angle);
            let y = centerY + radius * Math.sin(angle);
            let z = centerZ;
            vertices.push(x, y, z);
        }
        return vertices;
    }

    let numSegments = 20;  // Número de segmentos para formar cada círculo
    let circleRadius = 0.05;
    let circleDistance = 0.15; // Distância vertical entre os centros dos círculos

    // Criar vértices para os círculos
    let redCircleVertices = createCircleVertices(0, 0.15, 0.11, circleRadius, numSegments);
    let yellowCircleVertices = createCircleVertices(0, 0, 0.11, circleRadius, numSegments);
    let greenCircleVertices = createCircleVertices(0, -0.15, 0.11, circleRadius, numSegments);

    vertices.push(...redCircleVertices, ...yellowCircleVertices, ...greenCircleVertices);

    var indices = [
        // Frente da caixa
        0,  1,  2,      0,  2,  3,
        // Trás da caixa
        4,  5,  6,      4,  6,  7,
        // Laterais da caixa
        0,  3,  5,      0,  5,  4,
        1,  2,  6,      1,  6,  7,
        // Topo e base da caixa
        3,  2,  6,      3,  6,  5,
        0,  1,  7,      0,  7,  4,
        // Frente do suporte
        8,  9,  10,     8,  10, 11,
        // Trás do suporte
        12, 13, 14,     12, 14, 15,
        // Laterais do suporte
        8, 11, 13,      8, 13, 12,
        9, 10, 14,      9, 14, 15,
        // Topo e base do suporte
        11, 10, 14,     11, 14, 13,
        8,  9, 15,      8, 15, 12,
        // Triângulo (pirâmide) no topo
        16, 17, 18,     // Frente
        16, 18, 19,     // Direita
        16, 19, 20,     // Trás
        16, 20, 17,     // Esquerda
        17, 18, 19,     // Base frente-direita
        17, 19, 20,     // Base trás
    ];

    var colors = [
        [0.8, 0.8, 0.8, 1.0], // Cor para a caixa
        [0.3, 0.3, 0.3, 1.0], // Cor para o suporte
    ];

    var vertexColors = [];
    for (var i = 0; i < 8; i++) {
        vertexColors = vertexColors.concat(colors[0]); // Cor para a caixa
    }
    for (var i = 0; i < 8; i++) {
        vertexColors = vertexColors.concat(colors[1]); // Cor para o suporte
    }

    // Cor do triângulo
    var triangleColor = [0.3, 0.3, 0.3, 1.0]; // Azul

    for (var i = 0; i < 5; i++) {
        vertexColors = vertexColors.concat(triangleColor); // Cor para o triângulo
    }

    // Adicionando cores dos círculos
    var redColor = [1.0, 0.0, 0.0, 1.0];
    var yellowColor = [1.0, 1.0, 0.0, 1.0];
    var greenColor = [0.0, 1.0, 0.0, 1.0];

    function createCircleColors(color, numVertices) {
        var colors = [];
        for (let i = 0; i < numVertices; i++) {
            colors.push(color[0], color[1], color[2], color[3]);
        }
        return colors;
    }

    vertexColors.push(...createCircleColors(redColor, numSegments + 1));
    vertexColors.push(...createCircleColors(yellowColor, numSegments + 1));
    vertexColors.push(...createCircleColors(greenColor, numSegments + 1));

    var vertexBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, vertexBuffer);
    gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(vertices), gl.STATIC_DRAW);

    var colorBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, colorBuffer);
    gl.bufferData(gl.ARRAY_BUFFER, new Float32Array(vertexColors), gl.STATIC_DRAW);

    var indexBuffer = gl.createBuffer();
    gl.bindBuffer(gl.ELEMENT_ARRAY_BUFFER, indexBuffer);
    gl.bufferData(gl.ELEMENT_ARRAY_BUFFER, new Uint16Array(indices), gl.STATIC_DRAW);

    var aPosition = gl.getAttribLocation(program, "a_position");
    gl.bindBuffer(gl.ARRAY_BUFFER, vertexBuffer);
    gl.vertexAttribPointer(aPosition, 3, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(aPosition);

    var aColor = gl.getAttribLocation(program, "a_color");
    gl.bindBuffer(gl.ARRAY_BUFFER, colorBuffer);
    gl.vertexAttribPointer(aColor, 4, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(aColor);

    var uModelViewMatrix = gl.getUniformLocation(program, "u_modelViewMatrix");
    var uProjectionMatrix = gl.getUniformLocation(program, "u_projectionMatrix");

    var modelViewMatrix = mat4();
    var projectionMatrix = perspective(45, canvas.width / canvas.height, 0.1, 100.0);

    modelViewMatrix = mult(modelViewMatrix, translate(0.0, 0.0, -1.5));

    function render() {
        let phase = parseInt(document.getElementById('phaseControl').value);

        gl.clear(gl.COLOR_BUFFER_BIT | gl.DEPTH_BUFFER_BIT);
        gl.uniformMatrix4fv(uModelViewMatrix, false, flatten(modelViewMatrix));
        gl.uniformMatrix4fv(uProjectionMatrix, false, flatten(projectionMatrix));
        gl.drawElements(gl.TRIANGLES, indices.length, gl.UNSIGNED_SHORT, 0);
        // Desenhar os círculos
        let baseIndex = vertices.length / 3 - (3 * (numSegments + 1)); // Índice de início dos círculos
        for (let i = 0; i < 3; i++) {
            if (i === phase) {
                gl.drawArrays(gl.TRIANGLE_FAN, baseIndex + (numSegments + 1) * i, numSegments + 1);
            }
        }

        requestAnimFrame(render);
    }

    gl.enable(gl.DEPTH_TEST);
    gl.clearColor(1.0, 1.0, 1.0, 1.0);
    render();
};
