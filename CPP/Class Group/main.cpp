#include <iostream>
#include "Group.h"

int main()
{
    Group group((char*)"П42");
    int choice;
    do {
        std::cout << "1. Add student\n";
        std::cout << "2. Delete student\n";
        std::cout << "3. Show student information\n";
        std::cout << "0. Exit\n";
        std::cout << "Your choice: ";

        std::cin >> choice;
        switch (choice) {
        case 1: {
            Student s;
            std::cout << "Enter name: ";
            std::cin >> s.name;
            std::cout << "Age: ";
            std::cin >> s.age;
            std::cout << "University: ";
            std::cin >> s.university;
            group.SetStudent(s);
            break;
        }

        case 2: {
            int index;
            std::cout << "Enter student index to delete: ";
            std::cin >> index;
            group.DeleteStudent(index);
            break;
        }

        case 3: {
            for (int i = 0; i < group.GetSize(); ++i) {
                group.Studentinfo(i);
            }
            break;
        }

        case 0:
            std::cout << "Exiting\n";
            break;

        default:
            std::cout << "Invalid choice!\n";
        }
    } while (choice != 0);
}
