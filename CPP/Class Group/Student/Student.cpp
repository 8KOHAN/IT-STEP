#include "Student.h"

Student::Student(const std::string& name, const std::string& university, int age)
    : name(name), university(university), age(age) {}

std::string Student::GetName() const { return name; }
std::string Student::GetUniversity() const { return university; }
int Student::GetAge() const { return age; }

void Student::SetName(const std::string& name) { this->name = name; }
void Student::SetUniversity(const std::string& university) { this->university = university; }
void Student::SetAge(int age) { this->age = age; }

void Student::PrintInfo() const {
    std::cout << "Name: " << name
        << ", Age: " << age
        << ", University: " << university << std::endl;
}
