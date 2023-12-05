#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#define _USE_MATH_DEFINES
#define deg2rad M_PI /180.0
#include "math.h"
#include <iostream>
#include <array>
#include <initializer_list>

// ID шейдерной программы
GLuint Program;
// ID атрибута вершин
GLint Attrib_vertex;
// ID атрибута цвета
GLint Attrib_color;

// ID юниформ переменной цвета
GLint Unif_xscale;
GLint Unif_yscale;

// ID VBO вершин
GLuint VBO_pos;
// ID VBO цвета
GLuint VBO_color;

struct Vertex {
    GLfloat x;
    GLfloat y;
};

const char* VertexShaderSource = R"(
    #version 330 core
    in vec2 coord;
    in vec4 color;
    uniform float x_scale;
    uniform float y_scale;
    out vec4 vert_color;
    void main() {
        vec3 position = vec3(coord, 1.0) * mat3(x_scale,0,0,0,y_scale,0, 0,0,1);
        gl_Position = vec4(position[0],position[1], 0.0, 1.0);
        vert_color = color;
    }
)";


// Исходный код фрагментного шейдера
const char* FragShaderSource = R"(
    #version 330 core
    in vec4 vert_color;
    out vec4 color;
    void main() {
        color = vert_color;
    }
)";
void Init();
void Draw();
void Release();

float scaleX = 1.0;
float scaleY = 1.0;
const int circleVertexCount = 360;
void scale(float _scaleX, float _scaleY) {
    scaleX += _scaleX;
    scaleY += _scaleY;
}

// Проверка ошибок OpenGL, если есть то вывод в консоль тип ошибки
void checkOpenGLerror() {
    GLenum err;
    if ((err = glGetError()) != GL_NO_ERROR)
    {
        std::cout << "OpenGl error!: " << err << std::endl;
    }

}

// Функция печати лога шейдера
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
float scaleColor(float color) {
    return (1.0f / 100.0f) * color;
}

std::array<float, 4> HSVtoRGB(float hue, float saturation = 100.0f, float value = 100.0f) {

    int sector = static_cast<int>(std::floor(hue / 60.0f)) % 6;
    float vMin = ((100.0f - saturation) * value) / 100.0f;
    float a = (value - vMin) * (std::fmod(hue, 60.0f) / 60.0f);
    float vInc = vMin + a;
    float vDec = value - a;

    switch (sector) {
    case 0:
        return { scaleColor(value), scaleColor(vInc), scaleColor(vMin), 1.0f };
        break;
    case 1:
        return { scaleColor(vDec), scaleColor(value), scaleColor(vMin), 1.0f };
        break;
    case 2:
        return { scaleColor(vMin), scaleColor(value), scaleColor(vInc), 1.0f };
        break;
    case 3:
        return { scaleColor(vMin), scaleColor(vDec), scaleColor(value), 1.0f };
        break;
    case 4:
        return { scaleColor(vInc), scaleColor(vMin), scaleColor(value), 1.0f };
        break;
    case 5:
        return { scaleColor(value), scaleColor(vMin), scaleColor(vDec), 1.0f };
        break;
    default:
         return { 0.0f, 0.0f, 0.0f, 0.0f };
            }
    
}


void InitVBO()
{
    glGenBuffers(1, &VBO_pos);
    glGenBuffers(1, &VBO_color);

    // Цвет треугольника
    std::array<std::array<float, 4>, circleVertexCount * 3> colors = {};

    Vertex circle[circleVertexCount * 3] = {};
    for (int i = 0; i < circleVertexCount; i++) {
        circle[i * 3] = { 0.5f * (float)cos(i * (360.0 / circleVertexCount) * deg2rad), 0.5f * (float)sin(i * (360.0 / circleVertexCount) * deg2rad) };
        circle[i * 3 + 1] = { 0.5f * (float)cos((i + 1) * (360.0 / circleVertexCount) * deg2rad), 0.5f * (float)sin((i + 1) * (360.0 / circleVertexCount) * deg2rad) };
        circle[i * 3 + 2] = { 0.0f, 0.0f };
        colors[i * 3] = HSVtoRGB(i % 360);
        colors[i * 3 + 1] = HSVtoRGB((i + 1) % 360);
        colors[i * 3 + 2] = { 1.0, 1.0, 1.0, 1.0 };
    }

    // Передаем вершины в буфер
    glBindBuffer(GL_ARRAY_BUFFER, VBO_pos);
    glBufferData(GL_ARRAY_BUFFER, sizeof(circle), circle, GL_STATIC_DRAW);
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glBufferData(GL_ARRAY_BUFFER, sizeof(colors), colors.data(), GL_STATIC_DRAW);
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

    // Вытягиваем ID атрибута вершин из собранной программы
    Attrib_vertex = glGetAttribLocation(Program, "coord");
    if (Attrib_vertex == -1)
    {
        std::cout << "could not bind attrib coord" << std::endl;
        return;
    }

    // Вытягиваем ID атрибута цвета
    Attrib_color = glGetAttribLocation(Program, "color");
    if (Attrib_color == -1)
    {
        std::cout << "could not bind attrib color" << std::endl;
        return;
    }

    // Вытягиваем ID юниформ
    const char* unif_name = "x_scale";
    Unif_xscale = glGetUniformLocation(Program, unif_name);
    if (Unif_xscale == -1)
    {
        std::cout << "could not bind uniform " << unif_name << std::endl;
        return;
    }

    unif_name = "y_scale";
    Unif_yscale = glGetUniformLocation(Program, unif_name);
    if (Unif_yscale == -1)
    {
        std::cout << "could not bind uniform " << unif_name << std::endl;
        return;
    }

    checkOpenGLerror();
}

void Init() {
    InitShader();
    InitVBO();
}


void Draw() {
    // Устанавливаем шейдерную программу текущей
    glUseProgram(Program);

    glUniform1f(Unif_xscale, scaleX);
    glUniform1f(Unif_yscale, scaleY);


    // Включаем массивы атрибутов
    glEnableVertexAttribArray(Attrib_vertex);
    glEnableVertexAttribArray(Attrib_color);

    // Подключаем VBO_pos
    glBindBuffer(GL_ARRAY_BUFFER, VBO_pos);
    glVertexAttribPointer(Attrib_vertex, 2, GL_FLOAT, GL_FALSE, 0, 0);

    // Подключаем VBO_color
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glVertexAttribPointer(Attrib_color, 4, GL_FLOAT, GL_FALSE, 0, 0);

    // Отключаем VBO
    glBindBuffer(GL_ARRAY_BUFFER, 0);

    // Передаем данные на видеокарту
    glDrawArrays(GL_TRIANGLES, 0, circleVertexCount * 3);

    // Отключаем массивы атрибутов
    glDisableVertexAttribArray(Attrib_vertex);
    glDisableVertexAttribArray(Attrib_color);

    glUseProgram(0);
    checkOpenGLerror();
}


// Освобождение шейдеров
void ReleaseShader() {

    // Отключаем шейдерную программу
    glUseProgram(0);
    // Удаляем шейдерную программу
    glDeleteProgram(Program);
}

// Освобождение буфера
void ReleaseVBO()
{
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDeleteBuffers(1, &VBO_pos);
    glDeleteBuffers(1, &VBO_color);
}

void Release() {
    ReleaseShader();
    ReleaseVBO();
}

int main() {
    sf::Window window(sf::VideoMode(600, 600), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);

    window.setActive(true);
    glewInit();

    Init();

    while (window.isOpen()) {
        sf::Event event;
        while (window.pollEvent(event)) {
            if (event.type == sf::Event::Closed) {
                window.close();
            }
            else if (event.type == sf::Event::Resized) {
                glViewport(0, 0, event.size.width, event.size.height);
            }
            else if (event.type == sf::Event::KeyPressed) {
                if (event.key.code == sf::Keyboard::W) {
                    scale(0, 0.1);
                }
                else if (event.key.code == sf::Keyboard::S) {
                    scale(0, -0.1);
                }
                else if (event.key.code == sf::Keyboard::A) {
                    scale(-0.1, 0);
                }
                else if (event.key.code == sf::Keyboard::D) {
                    scale(0.1, 0);
                }
            }
        }

        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

        Draw();

        window.display();
    }

    Release();
    return 0;
}
