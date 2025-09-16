#include "AgeException.h"

AgeException::AgeException(int a) : age(a) {
    if (age < 0) {
        message = "age cannot be negative (" + std::to_string(age) + ")";
    }
    else if (age < 18) {
        message = "you are a minor, your age is - " + std::to_string(age) + (age > 2 ? " years" : " year");
    }
    else if (age > 150) {
        message = "unrealistic age (" + std::to_string(age) + ")";
    }
    else {
        message = "Logic error: AgeException thrown with valid age (" + std::to_string(age) + ")";
    }
}

const char* AgeException::what() const noexcept {
    return message.c_str();
}
