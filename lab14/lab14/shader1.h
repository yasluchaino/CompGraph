#pragma once
const char* VertexShaderSource = R"(
    #version 330 core
    layout (location = 0) in vec3 coord;
    layout (location = 1) in vec2 textCoord;
    out vec2 texcoord;

    uniform mat4 model;
	
    void main() {

        vec4 pos =vec4(coord, 1.0);//вокруг оси
        gl_Position =  model * pos;
        texcoord = vec2(textCoord.x, 1.0f - textCoord.y);
    }
)";

const char* FragShaderSource = R"(
#version 330 core
in vec2 texcoord;
out vec4 FragColor;
uniform sampler2D tex;

void main() {
    FragColor = texture(tex, texcoord);
})";
