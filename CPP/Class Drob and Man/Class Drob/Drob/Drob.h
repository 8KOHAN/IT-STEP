#pragma once
#include <iostream>

class Drob {
private:
    int numerator;
    int denominator;

    int gcd(int a, int b) const;

    void simplify();

public:

    Drob(int num = 0, int den = 1);

    void input();

    void print() const;

    Drob add(const Drob& other) const;

    Drob add(int num);

    Drob subtract(const Drob& other) const;

    Drob subtract(int num);

    Drob multiply(const Drob& other) const;

    Drob multiply(int num);

    Drob divide(const Drob& other) const;

    Drob divide(int num);

};
