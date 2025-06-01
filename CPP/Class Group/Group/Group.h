#pragma once
#include <iostream> 

class Student {
public:
    char name[50];
    char university[50];
    int age;
};

class Group {
private:
	Student** _student;
	char* _name;
	int _size;
public:
	Group(char* name = nullptr) {}

	Group(Group& group) {}

	Student** GetStudent() {}

	Student** SetStudent(Student& student) {}

	char* SetName(char* name) {}

	Student** DeleteStudent(int index) {}

	void Studentinfo(int index) {}

	~Group() {}
};
