#include <GL/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <iostream>


// ID шейдерной программы
GLuint Program;
// ID атрибута вершин
GLint Attrib_vertex;
// ID атрибута цвета
GLint Attrib_color;

GLint Unif_xmove;
GLint Unif_ymove;

// ID VBO вершин
GLuint VBO_pos;
// ID VBO цвета
GLuint VBO_color;

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

    uniform float x_move;
    uniform float y_move;
    
    out vec4 vert_color;

    void main() {
        vec3 position = vec3(coord) + vec3(x_move, y_move, 0);
        gl_Position = vec4(position[0], position[1], 0.0, 1.0);
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

float moveX = 0;
float moveY = 0;

void move(float move_X, float move_Y) {
    moveX += move_X;
    moveY += move_Y;
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



void InitVBO()
{
    glGenBuffers(1, &VBO_pos);
    glGenBuffers(1, &VBO_color);

    // Вершины тетраэдра
    Vertex tetrahedron[] = {

         { 0.3, 0.55, -0.4 },   
    { -0.5, 0.1, -0.4 },  
    { 0.1, 0.1, 0.6 },        
    { -0.5, 0.1, -0.4 },    
    { 0.1, 0.1, 0.6},      
    { 0.3, -0.35, -0.4 }, 
    { 0.1, 0.1, 0.6 },         
    { 0.3, 0.55, -0.4 },   
    { 0.3, -0.35, -0.4 },  

    };

    float colors[9][4] = {
        { 0.0, 0.0, 1.0, 1.0 }, { 1.0, 0.0, 0.0, 1.0 }, { 1.0, 1.0, 1.0, 1.0 },
        { 1.0, 0.0, 0.0, 1.0 }, { 1.0, 1.0, 1.0, 1.0 }, { 0.0, 1.0, 0.0, 1.0 },
        { 1.0, 1.0, 1.0, 1.0 }, { 0.0, 0.0, 1.0, 1.0 }, { 0.0, 1.0, 0.0, 1.0 },
    };

    // Передаем вершины в буфер
    glBindBuffer(GL_ARRAY_BUFFER, VBO_pos);
    glBufferData(GL_ARRAY_BUFFER, sizeof(tetrahedron), tetrahedron, GL_STATIC_DRAW);
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glBufferData(GL_ARRAY_BUFFER, sizeof(colors), colors, GL_STATIC_DRAW);
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
    const char* unif_name = "x_move";
    Unif_xmove = glGetUniformLocation(Program, unif_name);
    if (Unif_xmove == -1)
    {
        std::cout << "could not bind uniform " << unif_name << std::endl;
        return;
    }

    unif_name = "y_move";
    Unif_ymove = glGetUniformLocation(Program, unif_name);
    if (Unif_ymove == -1)
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

    glUniform1f(Unif_xmove, moveX);
    glUniform1f(Unif_ymove, moveY);


    // Включаем массивы атрибутов
    glEnableVertexAttribArray(Attrib_vertex);
    glEnableVertexAttribArray(Attrib_color);

    // Подключаем VBO_pos
    glBindBuffer(GL_ARRAY_BUFFER, VBO_pos);
    glVertexAttribPointer(Attrib_vertex, 3, GL_FLOAT, GL_FALSE, 0, 0);

    // Подключаем VBO_color
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glVertexAttribPointer(Attrib_color, 4, GL_FLOAT, GL_FALSE, 0, 0);

    // Отключаем VBO
    glBindBuffer(GL_ARRAY_BUFFER, 0);

    // Передаем данные на видеокарту
    glDrawArrays(GL_TRIANGLES, 0, 9);

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
                    move(0, 0.1);
                }
                else if (event.key.code == sf::Keyboard::S) {
                    move(0, -0.1);
                }
                else if (event.key.code == sf::Keyboard::A) {
                    move(-0.1, 0);
                }
                else if (event.key.code == sf::Keyboard::D) {
                    move(0.1, 0);
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
