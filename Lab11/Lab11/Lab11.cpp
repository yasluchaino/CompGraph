#include <GL/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>


// ID шейдерной программы
GLuint Program;
// ID атрибута
GLint Attrib_vertex;
// ID Vertex Buffer Object
GLuint VBO;
// ID uniform
GLuint location;

struct Vertex {
    GLfloat x;
    GLfloat y;
};

// Исходный код вершинного шейдера
const char* VertexShaderSource = R"(
#version 330 core
in vec2 coord;
void main() {
gl_Position = vec4(coord, 0.0, 1.0);
}
)";
// Исходный код фрагментного шейдера
const char* FragShaderSource = R"(
#version 330 core
out vec4 color;
void main() {

color = vec4(1.0, 0.75, 0.79,1);
}
)";

const char* FragShaderSourceUnifColor = R"(
#version 330 core
uniform vec4 color;
void main() {
gl_FragColor = color;
}
)";



void checkOpenGLerror() {
    GLenum err;
    while ((err = glGetError()) != GL_NO_ERROR)
    {
        //  printf("smth went wrong");
    }
}

void InitVBO() {
    glGenBuffers(1, &VBO);
    // четырёхугольник
    Vertex quad[4] = {
    { -0.75f, -0.75f },
    { -0.75f, 0.75f },
    { 0.75f, 0.75f },
    { 0.75f, -0.75f }
    };

    // правильный пятиугольник
    float pi = 3.14159265358979323846;
    float angle;

    Vertex pentagon[5];

    for (int i = 0; i < 5; ++i) {
        angle = 72.0f * i * pi / 180.0f;
        pentagon[i].x = cos(angle);
        pentagon[i].y = sin(angle);

    }

    // веер
    float phi = pi * 2 / 27;

    Vertex fan[9];
    int k = 1;
    for (int i = 0; i < 7; ++i) {
        float angle = phi + 2.0f * pi * (k) / 27.0f;
        fan[i].x = cos(angle);
        fan[i].y = sin(angle);
        k += 2;
    }

    fan[7].x = cos(phi + 2.0f * pi * 19.5f / 27.0f);
    fan[7].y = sin(phi + 2.0f * pi * 19.5f / 27.0f);
    fan[8].x = cos(phi + 2.0f * pi * 26.0f / 27.0f);
    fan[8].y = sin(phi + 2.0f * pi * 26.0f / 27.0f);

    // Передаем вершины в буфер
    glBindBuffer(GL_ARRAY_BUFFER, VBO);

    glBufferData(GL_ARRAY_BUFFER, sizeof(quad), quad, GL_STATIC_DRAW); // четырёхугольник
    //glBufferData(GL_ARRAY_BUFFER, sizeof(pentagon), pentagon, GL_STATIC_DRAW); // правильный пятиугольник
    //glBufferData(GL_ARRAY_BUFFER, sizeof(fan), fan, GL_STATIC_DRAW); // веер

    checkOpenGLerror(); // Проверка ошибок OpenGL, если есть то вывод в консоль тип ошибки
}

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

void InitShader() {
    // Создаем вершинный шейдер
    GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
    // Передаем исходный код
    glShaderSource(vShader, 1, &VertexShaderSource, NULL);
    // Компилируем шейдер
    glCompileShader(vShader);
    std::cout << "vertex shader \n";
    // Функция печати лога шейдера
    ShaderLog(vShader);

    // Создаем фрагментный шейдер
    GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
    // Передаем исходный код
    glShaderSource(fShader, 1, &FragShaderSourceUnifColor, NULL);
    // Компилируем шейдер
    glCompileShader(fShader);
    std::cout << "fragment shader \n";
    // Функция печати лога шейдера
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
    if (!link_ok) {
        std::cout << "error attach shaders \n";
        return;
    }
    // Вытягиваем ID атрибута из собранной программы
    const char* attr_name = "coord"; //имя в шейдере
    Attrib_vertex = glGetAttribLocation(Program, attr_name);
    if (Attrib_vertex == -1) {
        std::cout << "could not bind attrib " << attr_name << std::endl;
        return;
    }
    checkOpenGLerror();

}

void Init() {
    // Шейдеры
    InitShader();
    // Вершинный буфер
    InitVBO();
}

void Draw() {
    glUseProgram(Program); // Устанавливаем шейдерную программу текущей
    glEnableVertexAttribArray(Attrib_vertex); // Включаем массив атрибутов
    glBindBuffer(GL_ARRAY_BUFFER, VBO); // Подключаем VBO
    glVertexAttribPointer(Attrib_vertex, 2, GL_FLOAT, GL_FALSE, 0, 0); // Указывая pointer 0 при подключенном буфере, мы указываем что данные в VBO
    glBindBuffer(GL_ARRAY_BUFFER, 0); // Отключаем VBO

    float color[4] = { 0.5f, 0.0f, 1.0f, 1.0f }; // Фиолетовый
    location = glGetUniformLocation(Program, "color");
    glUniform4f(location, color[0], color[1], color[2], color[3]);
    
    
    glDrawArrays(GL_QUADS, 0, 4); // четырёхугольник
    //glDrawArrays(GL_POLYGON, 0, 5); // правильный пятиугольник
    //glDrawArrays(GL_TRIANGLE_FAN, 0, 9); // веер
    glDisableVertexAttribArray(Attrib_vertex); // Отключаем массив атрибутов
    glUseProgram(0); // Отключаем шейдерную программу
    checkOpenGLerror();
}


// Освобождение буфера
void ReleaseVBO() {
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDeleteBuffers(1, &VBO);
}
// Освобождение шейдеров
void ReleaseShader() {
    // Передавая ноль, мы отключаем шейдерную программу
    glUseProgram(0);
    // Удаляем шейдерную программу
    glDeleteProgram(Program);
}

void Release() {
    // Шейдеры
    ReleaseShader();
    // Вершинный буфер
    ReleaseVBO();
}

int main()
{
    sf::Window window(sf::VideoMode(600, 600), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
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
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
        Draw();
        window.display();
    }
    Release();
    return 0;
}

