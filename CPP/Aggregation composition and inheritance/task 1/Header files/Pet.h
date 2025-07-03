#pragma once
#include <string>

class Pet {
public:
    Pet(const std::string& name, int age, const std::string& color);

    virtual void displayInfo() const;
protected:
    std::string name;
    int age;
    std::string color;
};

class Dog : public Pet {
public:
    Dog(const std::string& name, int age, const std::string& color);
    void displayInfo() const override;
};

class Cat : public Pet {
public:
    Cat(const std::string& name, int age, const std::string& color);
    void displayInfo() const override;
};

class Parrot : public Pet {
public:
    Parrot(const std::string& name, int age, const std::string& color);
    void displayInfo() const override;
};
