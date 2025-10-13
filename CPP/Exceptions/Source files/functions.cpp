#include "functions.h"

int toInt(const std::string& s) {
    size_t pos;
    int value = std::stoi(s, &pos); 

    if (pos != s.size()) {
        throw std::invalid_argument("Invalid string: there are extra characters");
    }

    return value;
}

void process() {
    try {
        throw std::runtime_error("Error in the program");
    }
    catch (const std::exception& e) {
        std::ofstream file("error_log.txt", std::ios::app); 
        if (file) {
            file << "Error: " << e.what() << std::endl;
            file.close();
        }

        throw;
    }
}

void checkPassword(const std::string& password) {
    if (password.length() < 8) {
        throw std::runtime_error("Password is too short (minimum 8 characters)");
    }

    bool hasDigit = false;
    for (char ch : password) {
        if (std::isdigit(static_cast<unsigned char>(ch))) { 
            hasDigit = true;
            break;
        }
    }

    if (!hasDigit) {
        throw std::runtime_error("Password must contain at least one digit");
    }

    std::cout << "Password is valid" << std::endl;
}

void ageVerification(int age) {
    if (age < 18 || age > 150) {
        throw AgeException(age);
    }
    std::cout << "you are of age" << std::endl;
}
