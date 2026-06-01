var gl;
var programa;
var bufferColor;
var bufferCircle;
var numSegments = 50;
var circleVertices = [];
var circleColors = [];

window.onload = function init() {
    var canvas = document.getElementById("gl-canvas");
    gl = WebGLUtils.setupWebGL(canvas);
    if (!gl) { alert("WebGL não está disponível"); return; }

    
    circleVertices = createCircleVertices(0.0, 0.0, 0.5, numSegments);
    
    gl.viewport(0, 0, canvas.width, canvas.height);
    gl.clearColor(1.0, 1.0, 1.0, 1.0);

    programa = initShaders(gl, "vertex-shader", "fragment-shader");
    gl.useProgram(programa);

    
    bufferCircle = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, bufferCircle);
    gl.bufferData(gl.ARRAY_BUFFER, flatten(circleVertices), gl.STATIC_DRAW);

    var vPosition = gl.getAttribLocation(programa, "vPosition");
    gl.vertexAttribPointer(vPosition, 2, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vPosition);

    
    bufferColor = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, bufferColor);
    circleColors = Array(circleVertices.length).fill(vec4(0.5, 0.5, 0.5, 1.0));
    gl.bufferData(gl.ARRAY_BUFFER, flatten(circleColors), gl.STATIC_DRAW);

    var vColor = gl.getAttribLocation(programa, "vColor");
    gl.vertexAttribPointer(vColor, 4, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vColor);

    document.getElementById("sliderCor").oninput = function() {
        updateCircleColor(this.value);
        render();
    };

    render();
};


function createCircleVertices(centerX, centerY, radius, numSegments) {
    let vertices = [];
    let angleStep = Math.PI * 2 / numSegments;
    vertices.push(vec2(centerX, centerY)); 
    for (let i = 0; i <= numSegments; i++) {
        let angle = i * angleStep;
        let x = centerX + radius * Math.cos(angle);
        let y = centerY + radius * Math.sin(angle);
        vertices.push(vec2(x, y));
    }
    return vertices;
}

function updateCircleColor(cor) {
    var t = parseFloat(cor);
    var updatedColor = vec4(t, 0.0, 1.0 - t, 1.0);
    circleColors = Array(circleVertices.length).fill(updatedColor);
    gl.bindBuffer(gl.ARRAY_BUFFER, bufferColor);
    gl.bufferSubData(gl.ARRAY_BUFFER, 0, flatten(circleColors));
}

function render() {
    gl.clear(gl.COLOR_BUFFER_BIT);

    gl.bindBuffer(gl.ARRAY_BUFFER, bufferCircle);
    var vPosition = gl.getAttribLocation(programa, "vPosition");
    gl.vertexAttribPointer(vPosition, 2, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vPosition);

    gl.bindBuffer(gl.ARRAY_BUFFER, bufferColor);
    var vColor = gl.getAttribLocation(programa, "vColor");
    gl.vertexAttribPointer(vColor, 4, gl.FLOAT, false, 0, 0);
    gl.enableVertexAttribArray(vColor);

    gl.drawArrays(gl.TRIANGLE_FAN, 0, circleVertices.length);
}
