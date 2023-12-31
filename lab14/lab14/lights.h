#pragma once
#include <glm/glm.hpp>
#include <glm/gtc/matrix_transform.hpp>
#include <glm/gtc/type_ptr.hpp>

#include <gl/glew.h>
#include <gl/GL.h>
#include <gl/GLU.h>
#include <string>
#include <iostream>

using namespace std;

struct PointLight {
	glm::vec3 pos;
	glm::vec3 ambient;
	glm::vec3 diffuse;
	glm::vec3 specular;
	float constant_attenuation;
	float linear_attenuation;
	float quadratic_attenuation;


	void Load(GLuint program)
	{
		std::string type = "pointl.";
		glUniform3fv(glGetUniformLocation(program, (type + "pos").c_str()), 1, glm::value_ptr(pos));
		glUniform3fv(glGetUniformLocation(program, (type + "ambient").c_str()), 1, glm::value_ptr(ambient));
		glUniform3fv(glGetUniformLocation(program, (type + "diffuse").c_str()), 1, glm::value_ptr(diffuse));
		glUniform3fv(glGetUniformLocation(program, (type + "specular").c_str()), 1, glm::value_ptr(specular));
		glUniform1f(glGetUniformLocation(program, (type + "constant_attenuation").c_str()), constant_attenuation);
		glUniform1f(glGetUniformLocation(program, (type + "linear_attenuation").c_str()), linear_attenuation);
		glUniform1f(glGetUniformLocation(program, (type + "quadratic_attenuation").c_str()), quadratic_attenuation);


	}
};

struct DirLight {
	glm::vec3 pos;
	glm::vec3 direction;
	glm::vec3 ambient;
	glm::vec3 diffuse;
	glm::vec3 specular;

	void Load(GLuint program)
	{
		std::string type = "dirl.";
		glUniform3fv(glGetUniformLocation(program, (type + "pos").c_str()), 1, glm::value_ptr(pos));
		glUniform3fv(glGetUniformLocation(program, (type + "direction").c_str()), 1, glm::value_ptr(direction));
		glUniform3fv(glGetUniformLocation(program, (type + "ambient").c_str()), 1, glm::value_ptr(ambient));
		glUniform3fv(glGetUniformLocation(program, (type + "diffuse").c_str()), 1, glm::value_ptr(diffuse));
		glUniform3fv(glGetUniformLocation(program, (type + "specular").c_str()), 1, glm::value_ptr(specular));
	}
};

struct SpotLight {
	glm::vec3 pos;
	glm::vec3 direction;
	glm::vec3 ambient;
	glm::vec3 diffuse;
	glm::vec3 specular;
	float constant_attenuation;
	float linear_attenuation;
	float quadratic_attenuation;
	float cutoff;


	void Load(GLuint program)
	{
		std::string type = "spotl.";
		glUniform3fv(glGetUniformLocation(program, (type + "pos").c_str()), 1, glm::value_ptr(pos));
		glUniform3fv(glGetUniformLocation(program, (type + "direction").c_str()), 1, glm::value_ptr(direction));
		glUniform3fv(glGetUniformLocation(program, (type + "ambient").c_str()), 1, glm::value_ptr(ambient));
		glUniform3fv(glGetUniformLocation(program, (type + "diffuse").c_str()), 1, glm::value_ptr(diffuse));
		glUniform3fv(glGetUniformLocation(program, (type + "specular").c_str()), 1, glm::value_ptr(specular));
		glUniform1f(glGetUniformLocation(program, (type + "cutoff").c_str()), cutoff);
		glUniform1f(glGetUniformLocation(program, (type + "constant_attenuation").c_str()), constant_attenuation);
		glUniform1f(glGetUniformLocation(program, (type + "linear_attenuation").c_str()), linear_attenuation);
		glUniform1f(glGetUniformLocation(program, (type + "quadratic_attenuation").c_str()), quadratic_attenuation);
	}
};

struct Material {
	glm::vec3 ambient;
	glm::vec3 diffuse;
	glm::vec3 specular;
	glm::vec3 emission;
	float shininess;

	void Load(GLuint program)
	{
		std::string type = "material.";
		glUniform3fv(glGetUniformLocation(program, (type + "ambient").c_str()), 1, glm::value_ptr(ambient));
		glUniform3fv(glGetUniformLocation(program, (type + "diffuse").c_str()), 1, glm::value_ptr(diffuse));
		glUniform3fv(glGetUniformLocation(program, (type + "specular").c_str()), 1, glm::value_ptr(specular));
		glUniform3fv(glGetUniformLocation(program, (type + "emission").c_str()), 1, glm::value_ptr(emission));
		glUniform1f(glGetUniformLocation(program, (type + "shininess").c_str()), shininess);
	}

};