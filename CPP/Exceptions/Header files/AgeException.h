#pragma once

#include <iostream>
#include <stdexcept>
#include <string>

class AgeException : public std::exception {
public:
    AgeException(int a);
    const char* what() const noexcept override;
private:
    int age;
    std::string message;
};
