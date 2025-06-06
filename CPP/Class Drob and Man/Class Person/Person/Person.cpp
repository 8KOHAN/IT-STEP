#include "Person.h"

Date::Date() : day(1), month(1), year(2000) {}
Date::Date(int d, int m, int y) : day(d), month(m), year(y) {}
void Date::setDate(int d, int m, int y) {
    day = d;
    month = m;
    year = y;
}
void Date::display() const {
    std::cout << day << "." << month << "." << year;
}


int Person::instanceCount = 0;

Person::Person(int id, const Date& d, const char* s, const char* n, const char* p) : id(id), birthDate(d) {
    if (s) {
        surname = new char[strlen(s) + 1];
        strcpy_s(surname, strlen(s) + 1, s);
    }
    else {
        std::cout << "surname == nullptr" << std::endl;
        surname = nullptr;
    }

    if (n) {
        name = new char[strlen(n) + 1];
        strcpy_s(name, strlen(n) + 1, n);
    }
    else {
        std::cout << "name == nullptr" << std::endl;
        name = nullptr;
    }

    if (p) {
        patronymic = new char[strlen(p) + 1];
        strcpy_s(patronymic, strlen(p) + 1, p);
    }
    else {
        std::cout << "patronymic == nullptr" << std::endl;
        patronymic = nullptr;
    }

    instanceCount++;
}
Person& Person::operator=(const Person& other) {
    if (this != &other) {
        if (surname) { delete[] surname; }
        if (name) { delete[] name; }
        if (patronymic) { delete[] patronymic; }

        if (other.surname) {
            surname = new char[strlen(other.surname) + 1];
            strcpy_s(surname, strlen(other.surname) + 1, other.surname);
        }
        else {
            std::cout << "surname == nullptr" << std::endl;
            surname = nullptr;
        }

        if (other.name) {
            name = new char[strlen(other.name) + 1];
            strcpy_s(name, strlen(other.name) + 1, other.name);
        }
        else {
            std::cout << "name == nullptr" << std::endl;
            name = nullptr;
        }

        if (other.patronymic) {
            patronymic = new char[strlen(other.patronymic) + 1];
            strcpy_s(patronymic, strlen(other.patronymic) + 1, other.patronymic);
        }
        else {
            std::cout << "patronymic == nullptr" << std::endl;
            patronymic = nullptr;
        }
        birthDate = other.birthDate;
        id = other.id;
    }
    return *this;
}
Person::Person(Person&& other) noexcept : id(other.id), birthDate(other.birthDate) {
    name = other.name;
    surname = other.surname;
    patronymic = other.patronymic;
    birthDate = other.birthDate;

    other.name = nullptr;
    other.surname = nullptr;
    other.patronymic = nullptr;
    other.id = 0;
    other.setBirthDate(Date(0, 0, 0));
}
Person& Person::operator = (Person&& other) noexcept {
    if (this == &other) return *this;
    if (surname) { delete[] surname; }
    if (name) { delete[] name; }
    if (patronymic) { delete[] patronymic; }

    name = other.name;
    surname = other.surname;
    patronymic = other.patronymic;
    id = other.id;
    birthDate = other.birthDate;

    other.name = nullptr;
    other.surname = nullptr;
    other.patronymic = nullptr;
    other.id = 0;
    Date d = { 0, 0, 0 };
    other.setBirthDate(d);

    return *this;
}

Person::Person(const Person& other) : id(other.id), birthDate(other.birthDate) {

    if (other.surname) {
        surname = new char[strlen(other.surname) + 1];
        strcpy_s(surname, strlen(other.surname) + 1, other.surname);
    }
    else {
        std::cout << "surname == nullptr" << std::endl;
        surname = nullptr;
    }

    if (other.name) {
        name = new char[strlen(other.name) + 1];
        strcpy_s(name, strlen(other.name) + 1, other.name);
    }
    else {
        std::cout << "name == nullptr" << std::endl;
        name = nullptr;
    }

    if (other.patronymic) {
        patronymic = new char[strlen(other.patronymic) + 1];
        strcpy_s(patronymic, strlen(other.patronymic) + 1, other.patronymic);
    }
    else {
        std::cout << "patronymic == nullptr" << std::endl;
        patronymic = nullptr;
    }

    instanceCount++;
}

Person::~Person() {
    if (surname) { delete[] surname; }
    if (name) { delete[] name; }
    if (patronymic) { delete[] patronymic; }
    instanceCount--;
}

int Person::getInstanceCount() {
    return instanceCount;
}

void Person::setId(int id) { this->id = id; }
void Person::setSurname(const char* s) {
    if (s) {
        if (surname) { delete[] surname; }
        surname = new char[strlen(s) + 1];
        strcpy_s(surname, strlen(s) + 1, s);
    }
    else {
        std::cout << "surname == nullptr" << std::endl;
        if (surname) { delete[] surname; }
        surname = nullptr;
    }
}
void Person::setName(const char* n) {
    if (n) {
        if (name) { delete[] name; }
        name = new char[strlen(n) + 1];
        strcpy_s(name, strlen(n) + 1, n);
    }
    else {
        std::cout << "name == nullptr" << std::endl;
        if (name) { delete[] name; }
        name = nullptr;
    }
}
void Person::setPatronymic(const char* p) {
    if (p) {
        if (patronymic) { delete[] patronymic; }
        patronymic = new char[strlen(p) + 1];
        strcpy_s(patronymic, strlen(p) + 1, p);
    }
    else {
        std::cout << "patronymic == nullptr" << std::endl;
        if (patronymic) { delete[] patronymic; }
        patronymic = nullptr;
    }
}
void Person::setBirthDate(const Date& d) {
    birthDate = d;
}

int Person::getId() const { return id; }
const char* Person::getSurname() const { return surname; }
const char* Person::getName() const { return name; }
const char* Person::getPatronymic() const { return patronymic; }
Date Person::getBirthDate() const { return birthDate; }

void Person::display() const {
    std::cout << "ID: " << id << "\n"
        << "Surname: " << surname << "\n"
        << "Name: " << name << "\n"
        << "Patronymic: " << patronymic << "\n"
        << "Birth Date: ";
    birthDate.display();
    std::cout << "\n";
}
