#pragma once
const char* VertexShaderSource = R"(
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
        pos = vec3(model * vec4(coord, 1.0)); //pos = coord;
	    texcoord = vec2(texCoord.x, 1.0f - texCoord.y);
        norm = mat3(transpose(inverse(model))) * normal; //normal;
    }
)";

const char* FragShaderSource = R"(
#version 330 core



uniform struct PointLight {
    vec3 pos;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    float constant_attenuation;
	float linear_attenuation;
	float quadratic_attenuation;
} pointl;

uniform struct DirLight {
    vec3 pos;
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
    float constant_attenuation;
	float linear_attenuation;
	float quadratic_attenuation;
} spotl;

uniform struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
    vec3 emission;
    float shininess;
} material;

uniform vec3 viewPos;
uniform sampler2D tex;
uniform int light_ind;

in vec3 pos;
in vec2 texcoord;
in vec3 norm;

out vec4 FragColor;

void main() {




    //Для простого направленного света :(
    vec3 normal = normalize(norm);

    vec3 lightDir = normalize(-dirl.direction);

    vec3 ambient = dirl.ambient * texture(tex, texcoord).rgb;

    float diff = max(dot(normal, lightDir), 0.0);

    vec3 diffuse = dirl.diffuse * (diff * texture(tex, texcoord).rgb);

    vec3 viewDir = normalize(viewPos - pos);

    vec3 reflectDir = reflect(-lightDir, norm);

    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);

    vec3 specular = dirl.specular * (spec * texture(tex, texcoord).rgb);

    vec3 result = (ambient + diffuse + specular);
	vec4 res1 = vec4(result, 1.0);




    //Для света точки
    lightDir = normalize(pointl.pos - pos);
     
    ambient = pointl.ambient * texture(tex, texcoord).rgb;

    diff = max(dot(normal, lightDir), 0.0);

    diffuse = pointl.diffuse * (diff * texture(tex, texcoord).rgb);

    viewDir = normalize(viewPos - pos);

    reflectDir = reflect(-lightDir, norm);

    spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);

    specular = pointl.specular * (spec * texture(tex, texcoord).rgb);

    float distance = length(pointl.pos - pos);
    
    float attenuation = 1.0 / (pointl.constant_attenuation + pointl.linear_attenuation * distance + pointl.quadratic_attenuation * (distance * distance));

    ambient *= attenuation;

    diffuse *= attenuation;

	specular *= attenuation;
   
    result = (ambient + diffuse + specular);

    vec4 res2 = vec4(result, 1.0);




    //Для света прожектора
    lightDir = normalize(spotl.pos - pos);
     
    ambient = spotl.ambient * texture(tex, texcoord).rgb;

    diff = max(dot(normal, lightDir), 0.0);

    diffuse = spotl.diffuse * (diff * texture(tex, texcoord).rgb);

    viewDir = normalize(viewPos - pos);

    reflectDir = reflect(-lightDir, norm);

    spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);

    specular = spotl.specular * (spec * texture(tex, texcoord).rgb);

    distance = length(spotl.pos - pos);
    
    attenuation = 1.0 / (spotl.constant_attenuation + spotl.linear_attenuation * distance + spotl.quadratic_attenuation * (distance * distance));

    diffuse *= attenuation;

	specular *= attenuation;

    float alpha = dot(lightDir, normalize(-spotl.direction));

    if (alpha > spotl.cutoff)
	{
        diffuse *= alpha;
        specular *= alpha;
    }
    else
    {
        diffuse *= ambient;
		specular *= ambient;
		ambient *= ambient;
    }

    result = (ambient + diffuse + specular);

    vec4 res3 = vec4(result, 1.0);





    FragColor = res1 + res2 + res3;


})";
