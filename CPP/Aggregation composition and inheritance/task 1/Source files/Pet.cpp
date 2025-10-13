#include <iostream>
#include "Pet.h"

Pet::Pet(const std::string& name, int age, const std::string& color)
    : name(name), age(age), color(color) {}

void Pet::displayInfo() const {
    std::cout << "Name: " << name
        << ", Age: " << age
        << ", Color: " << color << std::endl;
}

Dog::Dog(const std::string& name, int age, const std::string& color)
    : Pet(name, age, color) {}

void Dog::displayInfo() const {
    std::cout << "Dog - ";
    Pet::displayInfo();
}

Cat::Cat(const std::string& name, int age, const std::string& color)
    : Pet(name, age, color) {}

void Cat::displayInfo() const {
    std::cout << "Cat - ";
    Pet::displayInfo();
}

Parrot::Parrot(const std::string& name, int age, const std::string& color)
    : Pet(name, age, color) {}

void Parrot::displayInfo() const {
    std::cout << "Parrot - ";
    Pet::displayInfo();
}
