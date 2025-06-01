#include <iostream>
#include "Group.h"

class Group {
private:
	Student** _student;
	char* _name;
	int _size;
public:
	Group(char* name = nullptr) {
		_student = new Student* [1];
		_size = 0;

		if (name){
			_name = new char[strlen(name) + 1];
			strcpy_s(_name, strlen(name) + 1, name);
		}
		else _name = nullptr;
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

		Student** temp = new Student* [_size + 1];
		for (int i = 0; i < _size; ++i) {
			temp[i] = _student[i];
		}
		temp[_size++] = new Student(student);

		delete[] _student;

		_student = temp;
		return _student;
	}

	char* SetName(char* name) {
		if (name) {
			delete[] _name;
			_name = new char[strlen(name) + 1];
			strcpy_s(_name, strlen(name) + 1, name);
			return _name;
		}
		std::cout << "name has not been changed (parameter == nullptr)" << std::endl;
		return _name;
	}

	Student** DeleteStudent(int index) {
		if (index < 0) {
			std::cout << "_student is not changed index cannot be less than zero" << std::endl;
			return _student;
		}
		if (index > _size) {
			std::cout << "_student is not changed index cannot be greater than size" << std::endl;
			return _student;
		}


		Student** temp = new Student * [_size - 1];

		int k = 0;
		for (int i = 0; i < _size; ++i) {
			if (i == index) continue;
			temp[k++] = _student[i];
		}
		delete _student[index];
		delete[] _student;

		_student = temp;
		return _student;
	}

	void Studentinfo(int index) {
		if (index < 0) {
			std::cout << "index cannot be less than zero" << std::endl;
			return;
		}
		if (index >= _size) {
			std::cout << "index cannot be greater than size" << std::endl;
			return;
		}


		std::cout << "name:       " << _student[index]->name << "age:        " << _student[index]->age << "university: " <<  _student[index]->university << std::endl;
	}

	~Group() {
		if (_size > 0) {
			for (int i = 0; i < _size; ++i) {
				delete _student[i];
			}
		}
		delete[] _student;
		delete[] _name;
	}
};
