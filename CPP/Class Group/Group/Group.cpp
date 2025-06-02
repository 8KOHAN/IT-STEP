#include <iostream>
#include "Group.h"

Group::Group(char* name) {
	_student = new Student* [1];
	if (name){
			_name = new char[strlen(name) + 1];
			strcpy_s(_name, strlen(name) + 1, name);
		}
	else _name = nullptr;
	_size = 0;
}

Group::Group(const Group& group) {
	if (group.GetSize() == 0) {
			std::cout << "empty list Student" << std::endl;
			_student = new Student* [1];
		}
	else {
		_student = new Student* [group.GetSize()];
		for (int i = 0; i < group.GetSize(); ++i)
			_student[i] = new Student(*group.GetStudent()[i]);
	}

	if (group.GetName()) {
			_name = new char[strlen(group.GetName()) + 1];
			strcpy_s(_name, strlen(group.GetName()) + 1, group.GetName());
		}
	else {
			std::cout << "name == nullptr" << std::endl;
			_name = nullptr;
		}

	_size = group.GetSize();
}

Student** Group::GetStudent() const {
	if (_student) return _student;

	std::cout << "Student is not initialized (_student == nullptr)" << std::endl;
	return nullptr;
}

char* Group::GetName() const {
	if (_name) return _name;

	std::cout << "name is not initialized (_name == nullptr)" << std::endl;
	return nullptr;
}

int Group::GetSize() const {
	return _size;
}

Student** Group::SetStudent(Student& student) {
	Student** temp = new Student* [_size + 1];
	for (int i = 0; i < _size; ++i) {
		temp[i] = _student[i];
	}
	temp[_size++] = new Student(student);

	delete[] _student;

	_student = temp;
	return _student;
}

char* Group::SetName(char* name) {
	if (name) {
		delete[] _name;
		_name = new char[strlen(name) + 1];
		strcpy_s(_name, strlen(name) + 1, name);
		return _name;
	}
	std::cout << "name has not been changed (parameter == nullptr)" << std::endl;
	return _name;
}

Student** Group::DeleteStudent(int index) {
	if (index < 0) {
		std::cout << "_student is not changed index cannot be less than zero" << std::endl;
		return _student;
	}
	if (index >= _size) {
		std::cout << "_student is not changed index cannot be greater than size" << std::endl;
		return _student;
	}


	Student** temp = new Student* [_size - 1];

	int k = 0;
	for (int i = 0; i < _size; ++i) {
		if (i == index) continue;
		temp[k++] = _student[i];
	}
	delete _student[index];
	delete[] _student;

	--_size;
	_student = temp;
	return _student;
}

void Group::Studentinfo(int index) {
	if (index < 0) {
		std::cout << "index cannot be less than zero" << std::endl;
		return;
	}
	if (index >= _size) {
		std::cout << "index cannot be greater than size" << std::endl;
		return;
	}

	std::cout << "name: " << _student[index]->name << "age: " << _student[index]->age << "university: " <<  _student[index]->university << std::endl;
}

Group::~Group() {
	if (_size > 0) {
		for (int i = 0; i < _size; ++i) {
			delete _student[i];
		}
	}
	delete[] _student;
	delete[] _name;
}
