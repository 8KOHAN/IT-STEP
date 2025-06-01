#include <iostream>
#include "Group.h"

class Group {
private:
	Student** _student;
	char* _name;
	int _size;
public:
	Group(Student** group = nullptr, char* name = nullptr, int size = 0) {
		_student = group;

		if (name){
			_name = new char(strlen(name));
			strcpy_s(_name, strlen(name), name);
		}
		else _name = nullptr;

		if (size > 0) _size = size;
		else _size = 0;
	}

	Student** GetStudent() {
		if (_student) return _student;

		std::cout << "Student is not initialized (_student == nullptr)" << std::endl;
		return nullptr;
	}

	char* GetName() {
		if (_name) return _name;

		std::cout << "name is not initialized (_name == nullptr)" << std::endl;
		return nullptr;
	}

	int GetSize() {
		return _size;
	}

	Student** SetStudent(Student& student) {
		_student[_size++] = new Student(student);
		return _student;
	}

	char* SetName(char* name) {
		if (name) {
			delete[] _name;
			_name = new char(strlen(name));
			strcpy_s(_name, strlen(name), name);
		}
	}
};
