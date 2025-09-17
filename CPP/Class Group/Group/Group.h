#pragma once
#include <string>
#include <vector>
#include "Student.h"

class Group {
private:
    std::string name;
    std::vector<Student> students;
public:
    Group(const std::string& name);

    std::string GetName() const;
    void SetName(const std::string& name);

    void AddStudent(const Student& student);
    void DeleteStudent(int index);
    void ShowStudents() const;

    int GetSize() const;
};
