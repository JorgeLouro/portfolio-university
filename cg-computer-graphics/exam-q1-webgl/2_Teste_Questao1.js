var gl;
var program;

window.onload = function init() {
    var canvas = document.getElementById("canvas-webgl");
    gl = canvas.getContext("webgl");
    if (!gl) {   
        alert("WebGL não está disponível");    
        return;   
    }

   
    var vertices1 = [
        vec2(-0.8, -0.2),
        vec2(-0.1, -0.2),
        vec2(-0.1, 0.5),
        vec2(-0.8, 0.5)
    ];

  
    var vertices2 = [
        vec2(-1, -0.5),
        vec2(1, -0.5),
        vec2(-1, -1),
        vec2(1, -1)
    ];

    
    var cores = [
        vec4(1.0, 0.0, 0.0, 1.0), 
        vec4(0.0, 0.0, 1.0, 1.0), 
        vec4(0.0, 1.0, 0.0, 1.0), 
        vec4(0.0, 0.0, 0.0, 1.0)  
    ];

    
    var cor = vec4(1.0, 1.0, 0.0, 1.0);

    gl.viewport(0, 0, canvas.width, canvas.height);
    gl.clearColor(0.0, 0.5, 0.5, 0.0);

    program = initShaders(gl, "shader-vs", "shader-fs");
    gl.useProgram(program);

    
    var BufferId1 = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, BufferId1);
    gl.bufferData(gl.ARRAY_BUFFER, flatten(vertices1), gl.STATIC_DRAW);

    var vPosition = gl.getAttribLocation(program, "aVertexPosition");
    gl.vertexAttribPointer(vPosition, 2, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vPosition);

    
    var corBufferId1 = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, corBufferId1);
    gl.bufferData(gl.ARRAY_BUFFER, flatten(cores), gl.STATIC_DRAW);

    var vColor = gl.getAttribLocation(program, "aVertexColor");
    gl.vertexAttribPointer(vColor, 4, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vColor);

    render(vertices2, cor, corBufferId1);
}


function createCircleVertices(centerX, centerY, radius, numSegments) {
    let vertices = [];
    let angleStep = Math.PI * 2 / numSegments;
    for (let i = 0; i <= numSegments; i++) {
        let angle = i * angleStep;
        let x = centerX + radius * Math.cos(angle);
        let y = centerY + radius * Math.sin(angle);
        vertices.push(vec2(x, y));
    }
    return vertices;
}

function render(vertices2, cor, corBufferId1) {
    gl.clear(gl.COLOR_BUFFER_BIT);

    
    gl.drawArrays(gl.TRIANGLE_FAN, 0, 4);

   
    var BufferId2 = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, BufferId2);
    gl.bufferData(gl.ARRAY_BUFFER, flatten(vertices2), gl.STATIC_DRAW);

    var vPosition = gl.getAttribLocation(program, "aVertexPosition");
    gl.vertexAttribPointer(vPosition, 2, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vPosition);

   
    var cors = [ cor, cor, cor, cor ];
    var vColor = gl.getAttribLocation(program, "aVertexColor");
    gl.bindBuffer(gl.ARRAY_BUFFER, corBufferId1);
    gl.vertexAttribPointer(vColor, 4, gl.FLOAT, false, 0, 0);
    gl.bufferData(gl.ARRAY_BUFFER, flatten(cors), gl.STATIC_DRAW);

    
    gl.drawArrays(gl.TRIANGLE_STRIP, 0, 4);

    
    var circleVertices = createCircleVertices(0.7, 0.7, 0.3, 50);
    var circleBufferId = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, circleBufferId);
    gl.bufferData(gl.ARRAY_BUFFER, flatten(circleVertices), gl.STATIC_DRAW);

    var vPosition = gl.getAttribLocation(program, "aVertexPosition");
    gl.vertexAttribPointer(vPosition, 2, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vPosition);

    var blueColor = vec4(0.0, 0.0, 1.0, 1.0); 
    var circleColors = Array(circleVertices.length).fill(blueColor);

    var circleColorBufferId = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, circleColorBufferId);
    gl.bufferData(gl.ARRAY_BUFFER, flatten(circleColors), gl.STATIC_DRAW);

    var vColor = gl.getAttribLocation(program, "aVertexColor");
    gl.vertexAttribPointer(vColor, 4, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vColor);

    gl.drawArrays(gl.TRIANGLE_FAN, 0, circleVertices.length);
}
