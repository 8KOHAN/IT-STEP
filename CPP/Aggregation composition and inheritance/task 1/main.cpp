#include <iostream>
#include <windows.h>
#include <string>

class Pet {
protected:
    std::string name;
    int age;
    std::string color;
public:
    Pet(const std::string& name, int age, const std::string& color)
        : name(name), age(age), color(color) {}

    virtual void displayInfo() const {
        std::cout << "Ім'я: " << name
            << ", Вік: " << age
            << ", Колір: " << color << std::endl;
    }
};

class Dog : public Pet {
public:
    Dog(const std::string& name, int age, const std::string& color)
        : Pet(name, age, color) {}

    void displayInfo() const override {
        std::cout << "Собака - ";
        Pet::displayInfo();
    }
};

class Cat : public Pet {
public:
    Cat(const std::string& name, int age, const std::string& color)
        : Pet(name, age, color) {}

    void displayInfo() const override {
        std::cout << "Кішка - ";
        Pet::displayInfo();
    }
};

class Parrot : public Pet {
public:
    Parrot(const std::string& name, int age, const std::string& color)
        : Pet(name, age, color) {}

    void displayInfo() const override {
        std::cout << "Папуга - ";
        Pet::displayInfo();
    }
};

int main() {
    SetConsoleOutputCP(1251);

    Dog dog("Рекс", 5, "коричневий");
    Cat cat("Мурка", 3, "сіра");
    Parrot parrot("Кеша", 2, "зелений");

    dog.displayInfo();
    cat.displayInfo();
    parrot.displayInfo();

    return 0;
}
