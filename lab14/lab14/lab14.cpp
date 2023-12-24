#include <iostream>
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
#include <array>
#include <locale>

using namespace std;

int VERTICES[5];

GLuint VBO[5];
GLuint texture[5];

GLuint Program;

// ID 
GLint Unif_offsets;
GLint Unif_model;
GLint Unif_view;
GLint Unif_projection;

glm::vec3 cameraPos = glm::vec3(2.0f, 2.0f, 20.0f);  //позиция камеры
glm::vec3 cameraFront = glm::vec3(0.0f, 0.0f, -1.0f); //направление
glm::vec3 cameraUp = glm::vec3(0.0f, 0.5f, 0.0f);  // верх камеры

glm::mat4 model = glm::mat4(1.0f);

float yaw = -90.0f;
float pitch = 0.0f;

vector<glm::vec4> offsets;

vector<float> speed_around_axis;

vector<float> speed_around_center;


sf::Image img;

struct Vertex
{
	//coords
	GLfloat x;
	GLfloat y;
	GLfloat z;

	// texture coords
	GLfloat s;
	GLfloat t;

	//normals
	GLfloat nx;
	GLfloat ny;
	GLfloat nz;
};

int load_obj(const char* filename, vector<Vertex>& out)
{
	vector<glm::vec3> vertices;
	vector<glm::vec3> normals;
	vector<glm::vec2> uvs;

	ifstream in(filename, ios::in);
	if (!in)
	{
		cerr << "Can't open obj " << filename << endl;
		return -1;
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
			Vertex ve1 = { vertices[v1 - 1].x, vertices[v1 - 1].y, vertices[v1 - 1].z, uvs[uv1 - 1].x, uvs[uv1 - 1].y, normals[n1 - 1].x, normals[n1 - 1].y, normals[n1 - 1].z };
			Vertex ve2 = { vertices[v2 - 1].x, vertices[v2 - 1].y, vertices[v2 - 1].z, uvs[uv2 - 1].x, uvs[uv2 - 1].y, normals[n2 - 1].x, normals[n2 - 1].y, normals[n2 - 1].z };
			Vertex ve3 = { vertices[v3 - 1].x, vertices[v3 - 1].y, vertices[v3 - 1].z, uvs[uv3 - 1].x, uvs[uv3 - 1].y, normals[n3 - 1].x, normals[n3 - 1].y, normals[n3 - 1].z };
			Vertex ve4 = { vertices[v4 - 1].x, vertices[v4 - 1].y, vertices[v4 - 1].z, uvs[uv4 - 1].x, uvs[uv4 - 1].y, normals[n4 - 1].x, normals[n4 - 1].y, normals[n4 - 1].z };
			out.push_back(ve1);
			out.push_back(ve2);
			out.push_back(ve3);
			out.push_back(ve4);
		}
	}
	return out.size();
}

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


void LoadObject(int i, const char* path)
{
	glGenBuffers(1, &VBO[i]);
	vector<Vertex> data;
	VERTICES[i] = load_obj(path, data);
	glBindBuffer(GL_ARRAY_BUFFER, VBO[i]); 
	glBufferData(GL_ARRAY_BUFFER, VERTICES[i] * sizeof(Vertex), data.data(), GL_STATIC_DRAW);
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	checkOpenGLerror();
}

void InitVBO()
{
	LoadObject(0, "models/drawer.obj");
	LoadObject(1, "models/table.obj");
	LoadObject(2, "models/stool.obj");
	LoadObject(3, "models/drawer.obj");
	LoadObject(4, "models/drawer.obj");
	LoadObject(5, "models/drawer.obj");
}
// Функция для инициализации ресурсов
void InitTextures()
{
	if (!img.loadFromFile("Textures\\Drawer.jpg"))
	{
		std::cout << "could not load texture " << std::endl;
		return;
	}
	glGenTextures(1, &texture[0]); // Генерируем текстуру
	glActiveTexture(GL_TEXTURE0);
	glBindTexture(GL_TEXTURE_2D, texture[0]); // Привязываем текстуру
	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, img.getSize().x, img.getSize().y, 0, GL_RGBA, GL_UNSIGNED_BYTE, img.getPixelsPtr());
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT); // Устанавливаем параметры текстуры
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

	if (!img.loadFromFile("Textures\\table.png"))
	{
		std::cout << "could not load texture " << std::endl;
		return;
	}
	glGenTextures(1, &texture[1]); // Генерируем текстуру
	glActiveTexture(GL_TEXTURE1);
	glBindTexture(GL_TEXTURE_2D, texture[1]); // Привязываем текстуру
	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, img.getSize().x, img.getSize().y, 0, GL_RGBA, GL_UNSIGNED_BYTE, img.getPixelsPtr());
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT); // Устанавливаем параметры текстуры
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

	if (!img.loadFromFile("Textures\\stool.png"))
	{
		std::cout << "could not load texture " << std::endl;
		return;
	}
	glGenTextures(1, &texture[2]); // Генерируем текстуру
	glActiveTexture(GL_TEXTURE2);
	glBindTexture(GL_TEXTURE_2D, texture[2]); // Привязываем текстуру
	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, img.getSize().x, img.getSize().y, 0, GL_RGBA, GL_UNSIGNED_BYTE, img.getPixelsPtr());
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT); // Устанавливаем параметры текстуры
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

	if (!img.loadFromFile("Textures\\Drawer.jpg"))
	{
		std::cout << "could not load texture " << std::endl;
		return;
	}
	glGenTextures(1, &texture[3]); // Генерируем текстуру
	glActiveTexture(GL_TEXTURE3);
	glBindTexture(GL_TEXTURE_2D, texture[3]); // Привязываем текстуру
	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, img.getSize().x, img.getSize().y, 0, GL_RGBA, GL_UNSIGNED_BYTE, img.getPixelsPtr());
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT); // Устанавливаем параметры текстуры
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

	if (!img.loadFromFile("Textures\\Drawer.jpg"))
	{
		std::cout << "could not load texture " << std::endl;
		return;
	}
	glGenTextures(1, &texture[4]); // Генерируем текстуру
	glActiveTexture(GL_TEXTURE4);
	glBindTexture(GL_TEXTURE_2D, texture[4]); // Привязываем текстуру
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

	Unif_model = glGetUniformLocation(Program, "model");
	if (Unif_offsets == -1)
	{
		std::cout << "could not bind uniform " << std::endl;
		return;
	}

	checkOpenGLerror();
}




void Init() {

	InitVBO();
	InitShader();
	InitTextures();

	glEnable(GL_DEPTH_TEST);
}


void Draw() {

	GLuint tex_loc;
	glClearColor(0.5f, 0.7f, 1.0f, 1.0f);
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glUseProgram(Program);
	tex_loc = glGetUniformLocation(Program, "tex");

	glm::mat4 projection = glm::perspective(glm::radians(45.0f), 800.0f / 600.0f, 0.1f, 100.0f);
	glm::mat4 view = glm::lookAt(cameraPos, cameraPos + cameraFront, cameraUp);

	glm::mat4 model = glm::mat4(1.0f);
	float offsetX = 1.0f;
	float offsetY = 0.0f;
	float offsetZ = 0.0f;
	model = glm::translate(model, glm::vec3(offsetX, offsetY, offsetZ));
	glm::mat4  mvp = projection * view * model;

	glUniformMatrix4fv(Unif_model, 1, GL_FALSE, glm::value_ptr(mvp));
	glUniform1i(tex_loc, 0);
	glBindBuffer(GL_ARRAY_BUFFER, VBO[0]);

	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (void*)0);
	glEnableVertexAttribArray(0);

	// Атрибуты текстурных координат
	glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (void*)(3 * sizeof(GLfloat)));
	glEnableVertexAttribArray(1);

	glVertexAttribPointer(2, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(5 * sizeof(GLfloat)));
	glEnableVertexAttribArray(2);

	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArrays(GL_QUADS, 0, VERTICES[0]);


	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
	glDisableVertexAttribArray(2);

	glUseProgram(0);


	glUseProgram(Program);
	tex_loc = glGetUniformLocation(Program, "tex");
	model = glm::translate(model, glm::vec3(2.0f, offsetY, offsetZ));
	  mvp = projection * view * model;

	glUniformMatrix4fv(Unif_model, 1, GL_FALSE, glm::value_ptr(mvp));
	glUniform1i(tex_loc, 1);
	glBindBuffer(GL_ARRAY_BUFFER, VBO[1]);

	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (void*)0);
	glEnableVertexAttribArray(0);

	// Атрибуты текстурных координат
	glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (void*)(3 * sizeof(GLfloat)));
	glEnableVertexAttribArray(1);

	glVertexAttribPointer(2, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(5 * sizeof(GLfloat)));
	glEnableVertexAttribArray(2);

	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArrays(GL_QUADS, 0, VERTICES[1]);


	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
	glDisableVertexAttribArray(2);

	glUseProgram(0);



	glUseProgram(Program);
	tex_loc = glGetUniformLocation(Program, "tex");
	model = glm::translate(model, glm::vec3(3.0f, offsetY, offsetZ));
	mvp = projection * view * model;
	glUniformMatrix4fv(Unif_model, 1, GL_FALSE, glm::value_ptr(mvp));
	glUniform1i(tex_loc, 2);
	glBindBuffer(GL_ARRAY_BUFFER, VBO[2]);

	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (void*)0);
	glEnableVertexAttribArray(0);

	// Атрибуты текстурных координат
	glVertexAttribPointer(1, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (void*)(3 * sizeof(GLfloat)));
	glEnableVertexAttribArray(1);

	glVertexAttribPointer(2, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(5 * sizeof(GLfloat)));
	glEnableVertexAttribArray(2);

	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDrawArrays(GL_QUADS, 0, VERTICES[2]);


	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
	glDisableVertexAttribArray(2);

	glUseProgram(0);

}

void ReleaseShader() {

	glUseProgram(0);

	glDeleteProgram(Program);
}


void ReleaseVBO() {
	glBindBuffer(GL_ARRAY_BUFFER, 0); 
	for (int i = 0; i < 5; i++)
	{
		glDeleteBuffers(1, &VBO[i]); 
	}
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
			else if (event.type == sf::Event::KeyPressed)
			{
				if (sf::Keyboard::isKeyPressed(sf::Keyboard::E))
					cameraPos += cameraFront;
				if (sf::Keyboard::isKeyPressed(sf::Keyboard::Q))
					cameraPos -= cameraFront;
				if (sf::Keyboard::isKeyPressed(sf::Keyboard::A))
					cameraPos -= glm::normalize(glm::cross(cameraFront, cameraUp));
				if (sf::Keyboard::isKeyPressed(sf::Keyboard::D))
					cameraPos += glm::normalize(glm::cross(cameraFront, cameraUp));
				if (sf::Keyboard::isKeyPressed(sf::Keyboard::W)) {
					cameraPos += cameraUp;
				}
				if (sf::Keyboard::isKeyPressed(sf::Keyboard::S)) {
					cameraPos -= cameraUp;
				}
				const float sensitivity = 0.9;
				if (sf::Keyboard::isKeyPressed(sf::Keyboard::Left)) {
					yaw -= sensitivity;
				}
				if (sf::Keyboard::isKeyPressed(sf::Keyboard::Right)) {
					yaw += sensitivity;
				}
				if (sf::Keyboard::isKeyPressed(sf::Keyboard::Up)) {
					pitch -= sensitivity;
				}
				if (sf::Keyboard::isKeyPressed(sf::Keyboard::Down)) {
					pitch += sensitivity;
				}
				if (pitch > 89.0f) {
					pitch = 89.0f;
				}
				if (pitch < -89.0f) {
					pitch = -89.0f;
				}

				glm::vec3 front;
				front.x = cos(glm::radians(yaw)) * cos(glm::radians(pitch));
				front.y = sin(glm::radians(pitch));
				front.z = sin(glm::radians(yaw)) * cos(glm::radians(pitch));
				cameraFront = glm::normalize(front);
			}
		}

		Draw();

		window.display();
	}
	Release();
	return 0;
}