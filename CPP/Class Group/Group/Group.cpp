#include "Group.h"
#include <iostream>

Group::Group(const std::string& name) : name(name) {}

std::string Group::GetName() const { return name; }
void Group::SetName(const std::string& name) { this->name = name; }

void Group::AddStudent(const Student& student) {
    students.push_back(student);
}

void Group::DeleteStudent(int index) {
    if (index - 1 < 0 || index - 1 >= students.size()) {
        std::cout << "Invalid index!" << std::endl;
        return;
    }
    students.erase(students.begin() + (index - 1));
}

void Group::ShowStudents() const {
    if (students.empty()) {
        std::cout << "No students in the group." << std::endl;
        return;
    }
    for (size_t i = 0; i < students.size(); ++i) {
        std::cout << i + 1 << ". ";
        students[i].PrintInfo();
    }
}

int Group::GetSize() const {
    return students.size();
}
