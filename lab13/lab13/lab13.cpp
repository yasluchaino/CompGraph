#pragma once
#include <gl/glew.h>
#include <gl/GL.h>
#include <gl/GLU.h>
#include <SFML/Graphics.hpp>
#include <SFML/OpenGL.hpp>

#include <iostream>
#include <vector>
#include <corecrt_math_defines.h>

#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

#include <stdio.h>
#include <string>
#include <cstring>
#include <sstream>
#include <fstream>

using namespace std;

int VERTICES;

GLuint VBO;

GLuint Program;

GLint Unif_mvp;

// ID 
GLint Unif_offsets;

vector<glm::vec4> offsets;

sf::Image img;
GLuint texture;

struct Vertex
{
	//coords
	GLfloat x;
	GLfloat y;
	GLfloat z;

	// texture coords
	GLfloat s;
	GLfloat t;
};

	
void load_obj(const char* filename, vector<Vertex>& out)
{
	vector<glm::vec3> vertices;
	vector<glm::vec3> normals;
	vector<glm::vec2> uvs;

	ifstream in(filename, ios::in);
	if (!in)
	{
		cerr << "Can't open obj " << filename << endl;
		return;
	}

	string line;
	while (getline(in, line))
	{
		string s = line.substr(0, 2);
		if (s == "v ")
		{
			istringstream s(line.substr(2));
			glm::vec3 v;
			s >> v.x;
			s >> v.y;
			s >> v.z;
			vertices.push_back(v);
		}
		else if (s == "vt")
		{
			istringstream s(line.substr(3));
			glm::vec2 uv;
			s >> uv.x;
			s >> uv.y;
			uvs.push_back(uv);
		}
		else if (s == "vn")
		{
			istringstream s(line.substr(3));
			glm::vec3 n;
			s >> n.x;
			s >> n.y;
			s >> n.z;
			normals.push_back(n);
		}
		else if (s == "f ")
		{
			istringstream s(line.substr(2));
			string s1, s2, s3;
			s >> s1;
			s >> s2;
			s >> s3;
			unsigned int v1, v2, v3, uv1, uv2, uv3, n1, n2, n3;
			sscanf_s(s1.c_str(), "%d/%d/%d", &v1, &uv1, &n1);
			sscanf_s(s2.c_str(), "%d/%d/%d", &v2, &uv2, &n2);
			sscanf_s(s3.c_str(), "%d/%d/%d", &v3, &uv3, &n3);
			Vertex ve1 = { vertices[v1 - 1].x, vertices[v1 - 1].y, vertices[v1 - 1].z, uvs[uv1 - 1].x, uvs[uv1 - 1].y };
			Vertex ve2 = { vertices[v2 - 1].x, vertices[v2 - 1].y, vertices[v2 - 1].z, uvs[uv2 - 1].x, uvs[uv2 - 1].y };
			Vertex ve3 = { vertices[v3 - 1].x, vertices[v3 - 1].y, vertices[v3 - 1].z, uvs[uv3 - 1].x, uvs[uv3 - 1].y };
			out.push_back(ve1);
			out.push_back(ve2);
			out.push_back(ve3);
		}
	}
}

const char* VertexShaderSource = R"(
#version 330 core
layout (location = 0) in vec3 coord;
layout (location = 1) in vec2 textCoord;
out vec2 texcoord;

uniform vec4 offsets[6];

void main() {
	float offset = offsets[gl_InstanceID].x;
	vec4 pos = vec4(coord, 1.0);
    pos = (pos + vec4(offset, 0.0, 0.0, 0.0));
    gl_Position = pos;
    texcoord =  vec2(textCoord.x, 1.0f - textCoord.y);
})";

const char* FragShaderSource = R"(
#version 330 core
in vec2 texcoord;
out vec4 FragColor;
uniform sampler2D tex;

void main() {
    FragColor = texture(tex, texcoord);
})";


void ShaderLog(unsigned int shader)
{
	int infologLen = 0;
	glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
	if (infologLen > 1)
	{
		int charsWritten = 0;
		std::vector<char> infoLog(infologLen);
		glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog.data());
		std::cout << "InfoLog: " << infoLog.data() << std::endl;
		exit(1);
	}
}

void checkOpenGLerror()
{
	GLenum errCode;
	const GLubyte* errString;
	if ((errCode = glGetError()) != GL_NO_ERROR)
	{
		errString = gluErrorString(errCode);
		std::cout << "OpenGL error: " << errString << std::endl;
	}
}


void InitVBO() {

	glGenBuffers(1, &VBO); // Генерируем вершинный буфер
	vector<Vertex> data;
	load_obj("gun.obj", data);
	VERTICES = data.size();
	glBindBuffer(GL_ARRAY_BUFFER, VBO); // Привязываем вершинный буфер
	glBufferData(GL_ARRAY_BUFFER, VERTICES * sizeof(Vertex), data.data(), GL_STATIC_DRAW);
	glBindBuffer(GL_ARRAY_BUFFER, 0); // Отвязываем вершинный буфер
	checkOpenGLerror();
}
// Функция для инициализации ресурсов
void InitTextures()
{	if (!img.loadFromFile("gun.png"))
	{
		std::cout << "could not load texture " << std::endl;
		return;
	}
	glGenTextures(1, &texture); // Генерируем текстуру
	/*glActiveTexture(GL_TEXTURE0);*/
	glBindTexture(GL_TEXTURE_2D, texture); // Привязываем текстуру
	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, img.getSize().x, img.getSize().y, 0, GL_RGBA, GL_UNSIGNED_BYTE, img.getPixelsPtr());
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT); // Устанавливаем параметры текстуры
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	checkOpenGLerror();
}

void InitShader()
{
	GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
	glShaderSource(vShader, 1, &VertexShaderSource, NULL);
	glCompileShader(vShader);
	std::cout << "vertex shader \n";
	ShaderLog(vShader);

	GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
	glShaderSource(fShader, 1, &FragShaderSource, NULL);
	glCompileShader(fShader);
	std::cout << "fragment shader \n";
	ShaderLog(fShader);

	// Создаем шейдерную программу
	Program = glCreateProgram();

	// Прикрепляем шейдеры к программе
	glAttachShader(Program, vShader);
	glAttachShader(Program, fShader);

	// Линкуем шейдерную программу
	glLinkProgram(Program);

	int link;
	glGetProgramiv(Program, GL_LINK_STATUS, &link);

	// Проверяем на ошибки
	if (!link)
	{
		std::cout << "error attach shaders \n";
		return;
	}

	const char* unif_off = "offsets";

	Unif_offsets = glGetUniformLocation(Program, unif_off);
	if (Unif_offsets == -1)
	{
		std::cout << "could not bind uniform " << std::endl;
		return;
	}

	checkOpenGLerror();
}



void Init() {

	offsets = {
	{0, 1.0, 0, 0}, 
	{3, 0.5, 0, 0}, 
	{4, 0.008691, 0, 0},
	{5, 0.009149, 0, 0}, 
	{6, 0.004868, 0, 0},
	};
	InitVBO();
	InitShader();
	InitTextures();
	
	glEnable(GL_DEPTH_TEST);
}


void Draw() {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glUseProgram(Program);

	glUniform4fv(glGetUniformLocation(Program, "offsets"), 6, glm::value_ptr(offsets[0]));

	
	glBindBuffer(GL_ARRAY_BUFFER, VBO);

	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 5 * sizeof(GLfloat), (void*)0);
	glEnableVertexAttribArray(0);

	// Атрибуты текстурных координат
	glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, 5 * sizeof(GLfloat), (void*)(3 * sizeof(GLfloat)));
	glEnableVertexAttribArray(1);

	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArraysInstanced(GL_TRIANGLES, 0, VERTICES, 6);


	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);

	glUseProgram(0);

}

void ReleaseShader() {

	glUseProgram(0);

	glDeleteProgram(Program);
}


void ReleaseVBO() {
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDeleteBuffers(1, &VBO);
}

void Release() {
	ReleaseShader();
	ReleaseVBO();
}
int main() {
	setlocale(LC_ALL, "Russian");
	sf::Window window(sf::VideoMode(800, 800), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
	window.setVerticalSyncEnabled(true);
	window.setActive(true);
	glewInit();
	Init();
	while (window.isOpen()) {
		sf::Event event;
		while (window.pollEvent(event)) {
			if (event.type == sf::Event::Closed) { window.close(); }
			else if (event.type == sf::Event::Resized) { glViewport(0, 0, event.size.width, event.size.height); }
		}
		Draw();
		window.display();
	}
	Release();
	return 0;
}