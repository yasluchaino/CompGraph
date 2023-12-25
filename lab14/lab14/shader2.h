#pragma once

const char* ToonVertexShaderSource = R"(
   #version 330 core
 layout (location = 0) in vec3 coord;
layout (location = 1) in vec2 texCoord;
    layout (location = 2) in vec3 normal;

out vec3 pos;
out vec2 texcoord;
out vec3 norm;

uniform mat4 model;

void main() {
    gl_Position = model * vec4(coord, 1.0);
    pos = coord;
	texcoord = vec2(texCoord.x, 1.0f - texCoord.y);
    norm = normal;
    }
)";

const char* ToonFragShaderSource = R"(
#version 330 core
in vec3 pos;
in vec2 texcoord;
in vec3 norm;

uniform struct PointLight {
    vec3 pos;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    vec3 atten;
} pointl;

uniform struct DirLight {
    vec3 direction;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
} dirl;

uniform struct SpotLight {
    vec3 pos;
    vec3 direction;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    float cutoff;
    vec3 atten;
} spotl;

uniform struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    vec3 emission;
    float shininess;
} material;

uniform sampler2D tex;

void main()
{
    vec3 viewDir = normalize( pos);
    vec3 norm2 = normalize(norm);

    vec3 lightDir = normalize(pointl.pos - pos);
    float diff = max(dot(lightDir, norm2), 0.0);
    vec3 r1;
    if (diff < 0.4)
        r1 = vec3(0.3);
    else if (diff < 0.7)
        r1 = vec3(1.0);
    else
        r1 = vec3(1.1);

    vec3 lightDir2 = normalize(dirl.direction);
    float diff2 = max(dot(lightDir2, norm2), 0.0);
    vec3 r2;

    if (diff2 < 0.4)
        r2 = vec3(0.3);
    else if (diff2 < 0.7)
        r2 = vec3(1.0);
    else
        r2 = vec3(1.1);

    vec3 lightDir3 = normalize(spotl.pos - pos);
    float diff3 = max(dot(-lightDir3, norm2), 0.0);
    float theta = dot(lightDir3, -normalize(spotl.direction));
    vec3 r3 = vec3(0.1);
    if (theta > cos(radians(spotl.cutoff))) {
        if (diff3 < 0.4)
            r3 = vec3(0.3);
        else if (diff3 < 0.7)
            r3 = vec3(1.0);
        else
            r3 = vec3(1.1);
    }

    vec3 res = r1 + r2 + r3;
    res *= vec3(texture(tex, texcoord));
    gl_FragColor = vec4(min(res, 1.0f), 1.0);
})";
