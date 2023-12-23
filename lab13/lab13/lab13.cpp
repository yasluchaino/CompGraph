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

glm::mat4 model = glm::mat4(1.0f);
GLuint Program;

// ID 
GLint Unif_offsets;
GLint Unif_model;

vector<glm::vec4> offsets;

vector<float> speed_around_axis;

vector<float> speed_around_center;


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
vector <string> split(string str, char separator) {
	vector < string > strings;
	int startIndex = 0, endIndex = 0;
	for (int i = 0; i <= str.size(); i++) {

		if (str[i] == separator || i == str.size()) {
			endIndex = i;
			string temp;
			temp.append(str, startIndex, endIndex - startIndex);
			strings.push_back(temp);
			startIndex = endIndex + 1;
		}
	}
	return strings;
}

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
			s >> uv.s;
			s >> uv.t;
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
			string s1, s2, s3, s4;
			s >> s1;
			s >> s2;
			s >> s3;
			s >> s4;
			unsigned int v1, v2, v3, v4, uv1, uv2, uv3, uv4, n1, n2, n3, n4;
			sscanf_s(s1.c_str(), "%d/%d/%d", &v1, &uv1, &n1);
			sscanf_s(s2.c_str(), "%d/%d/%d", &v2, &uv2, &n2);
			sscanf_s(s3.c_str(), "%d/%d/%d", &v3, &uv3, &n3);
			sscanf_s(s4.c_str(), "%d/%d/%d", &v4, &uv4, &n4);
			Vertex ve1 = { vertices[v1 - 1].x, vertices[v1 - 1].y, vertices[v1 - 1].z, uvs[uv1 - 1].s, uvs[uv1 - 1].t };
			Vertex ve2 = { vertices[v2 - 1].x, vertices[v2 - 1].y, vertices[v2 - 1].z, uvs[uv2 - 1].s, uvs[uv2 - 1].t };
			Vertex ve3 = { vertices[v3 - 1].x, vertices[v3 - 1].y, vertices[v3 - 1].z, uvs[uv3 - 1].s, uvs[uv3 - 1].t };
			Vertex ve4 = { vertices[v4 - 1].x, vertices[v4 - 1].y, vertices[v4 - 1].z, uvs[uv4 - 1].s, uvs[uv4 - 1].t };
			out.push_back(ve1);
			out.push_back(ve2);
			out.push_back(ve3);
			out.push_back(ve4);
		}
	}
}

const char* VertexShaderSource = R"(
    #version 330 core
    layout (location = 0) in vec3 coord;
    layout (location = 1) in vec2 textCoord;
    out vec2 texcoord;

    uniform vec4 offsets[6];
	uniform mat4 model;

	mat4 rotateY( in float angle ) {
	return mat4(	cos(angle),		0,		sin(angle),	0,
			 				0,		1.0,			 0,	0,
					-sin(angle),	0,		cos(angle),	0,
							0, 		0,				0,	1);
	}
    void main() {
        float offset = offsets[gl_InstanceID].x;
		float rot_axis = offsets[gl_InstanceID].z;
		float rot_center = offsets[gl_InstanceID].w;

        vec4 pos = rotateY(rot_axis) * vec4(coord, 1.0);//вокруг оси
		pos = rotateY(rot_center) * (pos + vec4(offset, 0.0, 0.0, 0.0));//вокруг центрального объекта
        gl_Position = model* pos;
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
{
	if (!img.loadFromFile("gun.png"))
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

	Unif_model = glGetUniformLocation(Program, "model");
	if (Unif_offsets == -1)
	{
		std::cout << "could not bind uniform " << std::endl;
		return;
	}

	checkOpenGLerror();
}


void Rotate()
{
	for (int i = 0; i < offsets.size(); i++)
	{
		offsets[i].z = fmod(offsets[i].z + speed_around_axis[i], 2 * M_PI);
		offsets[i].w = fmod(offsets[i].w + speed_around_center[i], 2 * M_PI);
	}
}

void Init() {

	speed_around_axis = {
		0.05, 0.01, 0.02, 0.015, 0.023, 0.016
	};
	speed_around_center = {
		0.0, 0.1, 0.025, 0.012, 0.015, 0.0116
	};
	offsets = {
	{0, 1.0, 0, 0},
	{1, 0.9, 0, 0},
	{2, 0.008691, 0, 0},
	{3, 0.009149, 0, 0},
	{4, 0.004868, 0, 0},
	{5, 0.003, 0, 0},

	};

	InitVBO();
	InitShader();
	InitTextures();

	glEnable(GL_DEPTH_TEST);
}

float angle = 0.0f;

void Draw() {

	glClearColor(0.5f, 0.7f, 1.0f, 1.0f);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glUseProgram(Program);

	glUniform4fv(glGetUniformLocation(Program, "offsets"), 6, glm::value_ptr(offsets[0]));
	angle += 0.01f;

	
	//пока нет какмеры
	glm::mat4 model = glm::mat4(1.0f);

	model = glm::rotate(model, angle, glm::vec3(0.0f, 1.0f, 0.0f));
	glm::mat4 projection = glm::perspective(glm::radians(45.0f), (float)800 / (float)800, 0.1f, 100.0f);
	glm::mat4 view = glm::lookAt(glm::vec3(0.0f, 0.0f, 5.0f),  // позиция камеры
		glm::vec3(0.0f, 0.0f, 0.0f),  
		glm::vec3(0.0f, 1.0f, 0.0f));
	glm::mat4  mvp = projection * view * model;

	glUniformMatrix4fv(Unif_model, 1, GL_FALSE, glm::value_ptr(mvp));

	glBindBuffer(GL_ARRAY_BUFFER, VBO);

	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 5 * sizeof(GLfloat), (void*)0);
	glEnableVertexAttribArray(0);

	// Атрибуты текстурных координат
	glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, 5 * sizeof(GLfloat), (void*)(3 * sizeof(GLfloat)));
	glEnableVertexAttribArray(1);

	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArraysInstanced(GL_QUADS, 0, VERTICES, 6);


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
		
		Rotate();
		
		Draw();
		
		window.display();
	}
	Release();
	return 0;
}