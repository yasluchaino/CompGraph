#include <GL/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>

// ID шейдерной программы
GLuint Program;

// ID VBO вершин
GLuint VBO;

sf::Image photo_img;
GLuint texture;

GLint Unif_Coef;

float coef = 0.05f;

struct Vertex {
	GLfloat x;
	GLfloat y;
	GLfloat z;
};

// Исходный код вершинного шейдера
const char* VertexShaderSource = R"(
#version 330 core
in vec3 coord;
in vec4 color;
in vec2  texCoord;
    
out vec4 vert_color;
out vec2 TexCoord;

void main() {
	vec3 position = coord * mat3(
           1, 0, 0,
            0, cos(1), -sin(1),
            0, sin(1), cos(1)
        ) * mat3(
            cos(-1), 0, sin(-1),
            0, 1, 0,
            -sin(-1), 0, cos(-1)
		);
	gl_Position = vec4(position, 1.0);
    vert_color = color;
	TexCoord =  texCoord;
}
)";

// Исходный код фрагментного шейдера
const char* FragShaderSource = R"(
#version 330 core
in vec4 vert_color;
in vec2 TexCoord;

uniform sampler2D ourTexture;
uniform float coef;

out vec4 color;

void main() {
    color = mix(texture(ourTexture, TexCoord), vec4(vert_color), coef);
}
)";

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
	}
}

void checkOpenGLerror() {
	GLenum errCode;
	if ((errCode = glGetError()) != GL_NO_ERROR)
		std::cout << "OpenGl error!: " << errCode << std::endl;
}



bool InitTextures()
{
	if (!photo_img.loadFromFile("1.png"))
	{
		return false;
	}

	glGenTextures(1, &texture);
	glBindTexture(GL_TEXTURE_2D, texture);
	glTexImage2D(GL_TEXTURE_2D, 0, GL_RGBA, photo_img.getSize().x, photo_img.getSize().y, 0, GL_RGBA, GL_UNSIGNED_BYTE,
		photo_img.getPixelsPtr());
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
	glBindTexture(GL_TEXTURE_2D, 0);
}

void InitVBO() {
	glGenBuffers(1, &VBO);

	float cube[] = {
		-0.5f, -0.5f, -0.5f,  1.0f, 1.0f, 0.0f,  0.0f, 0.0f,
		 0.5f, -0.5f, -0.5f,  0.0f, 1.0f, 1.0f,  1.0f, 0.0f,
		 0.5f,  0.5f, -0.5f,  1.0f, 0.0f, 1.0f,  1.0f, 1.0f,
		 0.5f,  0.5f, -0.5f,  1.0f, 0.0f, 1.0f,  1.0f, 1.0f,
		-0.5f,  0.5f, -0.5f,  0.0f, 0.0f, 1.0f,  0.0f, 1.0f,
		-0.5f, -0.5f, -0.5f,  1.0f, 1.0f, 0.0f,  0.0f, 0.0f,

		-0.5f, -0.5f,  0.5f,   0.0f, 1.0f, 1.0f,  0.0f, 0.0f,
		 0.5f, -0.5f,  0.5f,   1.0f, 1.0f, 0.0f,  1.0f, 0.0f,
		 0.5f,  0.5f,  0.5f,   0.0f, 0.0f, 1.0f,  1.0f, 1.0f,
		 0.5f,  0.5f,  0.5f,   0.0f, 0.0f, 1.0f,  1.0f, 1.0f,
		-0.5f,  0.5f,  0.5f,   1.0f, 0.0f, 1.0f,  0.0f, 1.0f,
		-0.5f, -0.5f,  0.5f,   0.0f, 1.0f, 1.0f,  0.0f, 0.0f,

		-0.5f,  0.5f,  0.5f,   1.0f, 0.0f, 1.0f,  1.0f, 0.0f,
		-0.5f,  0.5f, -0.5f,  0.0f, 0.0f, 1.0f,  1.0f, 1.0f,
		-0.5f, -0.5f, -0.5f,  1.0f, 1.0f, 0.0f,  0.0f, 1.0f,
		-0.5f, -0.5f, -0.5f,  1.0f, 1.0f, 0.0f,  0.0f, 1.0f,
		-0.5f, -0.5f,  0.5f,   0.0f, 1.0f, 1.0f,  0.0f, 0.0f,
		-0.5f,  0.5f,  0.5f,   1.0f, 0.0f, 1.0f,  1.0f, 0.0f,

		 0.5f,  0.5f,  0.5f,   0.0f, 0.0f, 1.0f,  1.0f, 0.0f,
		 0.5f,  0.5f, -0.5f,  1.0f, 0.0f, 1.0f,  1.0f, 1.0f,
		 0.5f, -0.5f, -0.5f,  0.0f, 1.0f, 1.0f,  0.0f, 1.0f,
		 0.5f, -0.5f, -0.5f,  0.0f, 1.0f, 1.0f,  0.0f, 1.0f,
		 0.5f, -0.5f,  0.5f,   1.0f, 1.0f, 0.0f,  0.0f, 0.0f,
		 0.5f,  0.5f,  0.5f,   0.0f, 0.0f, 1.0f,  1.0f, 0.0f,

		-0.5f, -0.5f, -0.5f,  1.0f, 1.0f, 0.0f,  0.0f, 1.0f,
		 0.5f, -0.5f, -0.5f,  0.0f, 1.0f, 1.0f,  1.0f, 1.0f,
		 0.5f, -0.5f,  0.5f,   1.0f, 1.0f, 0.0f,  1.0f, 0.0f,
		 0.5f, -0.5f,  0.5f,   1.0f, 1.0f, 0.0f,  1.0f, 0.0f,
		-0.5f, -0.5f,  0.5f,   0.0f, 1.0f, 1.0f,  0.0f, 0.0f,
		-0.5f, -0.5f, -0.5f,  1.0f, 1.0f, 0.0f,  0.0f, 1.0f,

		-0.5f,  0.5f, -0.5f,  0.0f, 0.0f, 1.0f,  0.0f, 1.0f,
		 0.5f,  0.5f, -0.5f,  1.0f, 0.0f, 1.0f,  1.0f, 1.0f,
		 0.5f,  0.5f,  0.5f,   0.0f, 0.0f, 1.0f,  1.0f, 0.0f,
		 0.5f,  0.5f,  0.5f,   0.0f, 0.0f, 1.0f,  1.0f, 0.0f,
		-0.5f,  0.5f,  0.5f,   1.0f, 0.0f, 1.0f,  0.0f, 0.0f,
		-0.5f,  0.5f, -0.5f,  0.0f, 0.0f, 1.0f,  0.0f, 1.0f
	};


	// Передаем вершины в буфер
	glBindBuffer(GL_ARRAY_BUFFER, VBO);
	glBufferData(GL_ARRAY_BUFFER, sizeof(cube), cube, GL_STATIC_DRAW);
	checkOpenGLerror();
}

void InitShader() {

	// Создаем вершинный шейдер
	GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
	// Передаем исходный код
	glShaderSource(vShader, 1, &VertexShaderSource, NULL);
	// Компилируем шейдер
	glCompileShader(vShader);
	std::cout << "vertex shader \n";
	ShaderLog(vShader);


	// Создаем фрагментный шейдер
	GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
	// Передаем исходный код
	glShaderSource(fShader, 1, &FragShaderSource, NULL);
	// Компилируем шейдер
	glCompileShader(fShader);
	std::cout << "fragment shader \n";
	ShaderLog(fShader);


	// Создаем программу и прикрепляем шейдеры к ней
	Program = glCreateProgram();
	glAttachShader(Program, vShader);
	glAttachShader(Program, fShader);

	// Линкуем шейдерную программу
	glLinkProgram(Program);
	// Проверяем статус сборки
	int link_ok;
	glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);
	if (!link_ok)
	{
		std::cout << "error attach shaders \n";
		return;
	}

	// Вытягиваем ID юниформ
	const char* unif_name = "coef";
	Unif_Coef = glGetUniformLocation(Program, unif_name);
	if (Unif_Coef < 0 || Unif_Coef > 1)
	{
		std::cout << "could not bind uniform" << std::endl;
		return;
	}

	checkOpenGLerror();
}

void Init() {
	InitShader();
	InitTextures();
	InitVBO();
	glEnable(GL_DEPTH_TEST);
}


void Draw() {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	// Устанавливаем шейдерную программу текущей
	glUseProgram(Program);

	glUniform1f(Unif_Coef, coef);
	glBindTexture(GL_TEXTURE_2D, texture);
	// подключаем VBO
	glBindBuffer(GL_ARRAY_BUFFER, VBO);

	// Подключаем массив аттрибутов с указанием на каких местах кто находится
	glVertexAttribPointer(0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(float), (void*)0);
	glEnableVertexAttribArray(0);

	glVertexAttribPointer(1, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(float), (void*)(3 * sizeof(float)));
	glEnableVertexAttribArray(1);

	glVertexAttribPointer(2, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(float), (void*)(6 * sizeof(float)));
	glEnableVertexAttribArray(2);

	glBindBuffer(GL_ARRAY_BUFFER, 0);  // Отключаем VBO

	//Рисуем 
	glDrawArrays(GL_TRIANGLES, 0, 36);

	// Отключаем массивы атрибутов
	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
	glDisableVertexAttribArray(2);

	glUseProgram(0); // Отключаем шейдерную программу
}


// Освобождение шейдеров
void ReleaseShader() {
	// Отключаем шейдерную программу
	glUseProgram(0);
	// Удаляем шейдерную программу
	glDeleteProgram(Program);
}

// Освобождение буфера
void ReleaseVBO() {
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDeleteBuffers(1, &VBO);

}

void Release() {
	ReleaseShader();
	ReleaseVBO();
}

int main() {
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
			else if (event.type == sf::Event::KeyPressed) {
				switch (event.key.code) {
				case (sf::Keyboard::W): coef += 0.1f; break;
				case (sf::Keyboard::S): coef -= 0.1f; break;
				default: break;
				}
				if (coef >= 1.0f)
					coef = 1.0f;
				if (coef <= 0.0f)
					coef = 0.0f;
			}
		}

		Draw();
		window.display();
	}
	Release();
	return 0;
}