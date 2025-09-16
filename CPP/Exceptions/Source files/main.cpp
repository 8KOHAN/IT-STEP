#include <iostream>
#include "functions.h"


int main() {

    //1
    {
        try {
            std::cout << toInt("123") << "\n";
            std::cout << toInt("-42") << "\n";
            std::cout << toInt("12a3") << "\n";
        }
        catch (const std::exception& e) {
            std::cerr << "Error: " << e.what() << "\n";
        }

    }

    //2
    {
        try {
            process();
        }
        catch (const std::exception& e) {
            std::cerr << "error in function 'process()' : " << e.what() << std::endl;
        }
    }

    //3
    {
        try {
            std::string password;
            std::cout << "Enter password: ";
            std::cin >> password;

            checkPassword(password);
        }
        catch (const std::exception& e) {
            std::cerr << "Error: " << e.what() << std::endl;
        }
    }

    //4
    {
        try {
            int age;
            while (true) {
                std::cout << "Enter your age: ";
                if (std::cin >> age) {
                    break;
                }
                else {
                    std::cout << "Error: wrong number entered!Try again." << std::endl;
                    std::cin.clear();
                    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
                }
            }
            ageVerification(age);
        }
        catch (const AgeException& e) {
            std::cerr << "Error: " << e.what() << std::endl;
        }
    }
}
