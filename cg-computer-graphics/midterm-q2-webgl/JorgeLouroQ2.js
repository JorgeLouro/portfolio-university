var gl;
var program;

window.onload = function init() {
    var canvas = document.getElementById("canvas-webgl");
    gl = canvas.getContext("webgl");
    if (!gl) {   
        alert("WebGL não está disponível");    
        return;   
    }

    var verticesBase = [
        vec2(-0.8, -0.8),   
        vec2(0.8, -0.8),    
        vec2(-0.8, -0.6),   
        vec2(0.8, -0.6)    
    ];

    
    var verticesCorpo = [
        vec2(-0.2, -0.6),   
        vec2(0.2, -0.6),   
        vec2(-0.2, 0.2),    
        vec2(0.2, 0.2)      
    ];

    
    var numSegments = 50;
    var radius = 0.3;
    var circleVertices = [];
    for (var i = 0; i < numSegments; i++) {
        var theta = (i / numSegments) * 2 * Math.PI;
        var x = 0 + radius * Math.cos(theta);
        var y = 0.5 + radius * Math.sin(theta);
        circleVertices.push(vec2(x, y));
    }

    
    var verticesBraços = [
        vec2(-0.2, 0.0), 
        vec2(-0.5, -0.3),  
        vec2(-0.2, -0.3), 

        vec2(0.2, 0.0),   
        vec2(0.5, -0.3),   
        vec2(0.2, -0.3)  
    ];

    var eyeRadius = 0.05;
    var leftEyeVertices = [];
    var rightEyeVertices = [];
    for (var i = 0; i < numSegments; i++) {
        var theta = (i / numSegments) * 2 * Math.PI;
        var x1 = -0.1 + eyeRadius * Math.cos(theta);
        var y1 = 0.57 + eyeRadius * Math.sin(theta);
        leftEyeVertices.push(vec2(x1, y1));

        var x2 = 0.1 + eyeRadius * Math.cos(theta);
        var y2 = 0.57 + eyeRadius * Math.sin(theta);
        rightEyeVertices.push(vec2(x2, y2));
    }

    var verticesMouth = [
        vec2(-0.05, 0.35),   
        vec2(0.05, 0.35),    
        vec2(-0.05, 0.4),  
        vec2(0.05, 0.4)    
    ];


    var coresBase = [
        vec4(0.0, 0.5, 0.0, 1.0),  
        vec4(0.0, 0.5, 0.0, 1.0),
        vec4(0.0, 0.5, 0.0, 1.0),
        vec4(0.0, 0.5, 0.0, 1.0)
    ];

    var corCorpo = vec4(1.0, 0.0, 1.0, 1.0);  
    var corCabeça = vec4(1.0, 0.8, 0.6, 1.0); 
    var corBraços = corCabeça;                
    var corOlhos = vec4(0.0, 0.0, 1.0, 1.0);  
    var corBoca = vec4(1.0, 0.0, 0.0, 1.0);   

    gl.viewport(0, 0, canvas.width, canvas.height);
    gl.clearColor(0.0, 0.5, 0.5, 0.2);
    program = initShaders(gl, "shader-vs", "shader-fs");
    gl.useProgram(program);

    setupAndDraw(verticesBase, coresBase);

    setupAndDraw(verticesCorpo, [corCorpo, corCorpo, corCorpo, corCorpo]);

    setupAndDraw(circleVertices, Array(numSegments).fill(corCabeça), gl.TRIANGLE_FAN);

    setupAndDraw(verticesBraços, Array(6).fill(corBraços), gl.TRIANGLES);

    setupAndDraw(leftEyeVertices, Array(numSegments).fill(corOlhos), gl.TRIANGLE_FAN);

    setupAndDraw(rightEyeVertices, Array(numSegments).fill(corOlhos), gl.TRIANGLE_FAN);

    setupAndDraw(verticesMouth, [corBoca, corBoca, corBoca, corBoca]);
}

function setupAndDraw(vertices, colors, mode = gl.TRIANGLE_STRIP) {
    var bufferId = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, bufferId);
    gl.bufferData(gl.ARRAY_BUFFER, flatten(vertices), gl.STATIC_DRAW);

    var vPosition = gl.getAttribLocation(program, "aVertexPosition");
    gl.vertexAttribPointer(vPosition, 2, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vPosition);

    var colorBufferId = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, colorBufferId);
    gl.bufferData(gl.ARRAY_BUFFER, flatten(colors), gl.STATIC_DRAW);

    var vColor = gl.getAttribLocation(program, "aVertexColor");
    gl.vertexAttribPointer(vColor, 4, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vColor);

    gl.drawArrays(mode, 0, vertices.length);
}