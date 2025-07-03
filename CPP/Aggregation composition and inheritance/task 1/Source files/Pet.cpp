#include <iostream>
#include "Pet.h"

Pet::Pet(const std::string& name, int age, const std::string& color)
    : name(name), age(age), color(color) {}

void Pet::displayInfo() const {
    std::cout << "Ім'я: " << name
        << ", Вік: " << age
        << ", Колір: " << color << std::endl;
}

Dog::Dog(const std::string& name, int age, const std::string& color)
    : Pet(name, age, color) {}

void Dog::displayInfo() const {
    std::cout << "Собака - ";
    Pet::displayInfo();
}

Cat::Cat(const std::string& name, int age, const std::string& color)
    : Pet(name, age, color) {}

void Cat::displayInfo() const {
    std::cout << "Кішка - ";
    Pet::displayInfo();
}

Parrot::Parrot(const std::string& name, int age, const std::string& color)
    : Pet(name, age, color) {}

void Parrot::displayInfo() const {
    std::cout << "Папуга - ";
    Pet::displayInfo();
}
