#pragma once

#include <iostream>

class Date {
private:
    int day, month, year;

public:
    Date();
    Date(int d, int m, int y);
    void setDate(int d, int m, int y);
    void display() const;
};

class Person {
private:
    int id;
    char* surname;
    char* name;
    char* patronymic;
    Date birthDate;

    static int instanceCount;

public:
    Person(int id, const Date& birthDate, const char* surname = nullptr, const char* name = nullptr, const char* patronymic = nullptr);
    Person(const Person& other);
    Person(Person&& other) noexcept;
    Person& operator=(const Person& other);
    Person& operator = (Person&& other) noexcept;
    ~Person();

    static int getInstanceCount();

    void setId(int id);
    void setSurname(const char* s);
    void setName(const char* n);
    void setPatronymic(const char* p);
    void setBirthDate(const Date& d);

    int getId() const;
    const char* getSurname() const;
    const char* getName() const;
    const char* getPatronymic() const;
    Date getBirthDate() const;

    void display() const;
};

