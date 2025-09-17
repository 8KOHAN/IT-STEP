#pragma once
#include <string>
#include <iostream>

class Student {
private:
    std::string name;
    std::string university;
    int age;
public:
    Student(const std::string& name, const std::string& university, int age);

    std::string GetName() const;
    std::string GetUniversity() const;
    int GetAge() const;

    void SetName(const std::string& name);
    void SetUniversity(const std::string& university);
    void SetAge(int age);

    void PrintInfo() const;
};
