#include <iostream>
#include <Windows.h>
class Figure {
public:
    virtual double area() const = 0;
};
class Rectanglee : public Figure {
public:
    Rectanglee(double width, double height) : width_(width), height_(height) {};
    virtual double area() const {
        return width_ * height_;
    }
private:
    double width_;
    double height_;
};
class Circle : public Figure {
public:
    Circle(double radius) : radius_(radius) {};
    virtual double area() const {
        return 3.1415 * radius_ * radius_;
    }
private:
    double radius_;
};
class Triangle : public Figure {
public:
    Triangle(double base, double height) : base_(base), height_(height) {};
    virtual double area() const {
        return (base_ * height_) / 2;
    }
private:
    double base_;
    double  height_;
};
int main() {
    SetConsoleOutputCP(1251);
    SetConsoleCP(1251);
    Figure* fptr;
    int choice;
    bool isOpen = true;
    while (isOpen) {
        std::cout << "виберете фигуру:\n1 = квадрат\n2 = круг\n3 = триугольник\n0 = выход" << std::endl;
        std::cin >> choice;
        switch (choice)
        {
        case 1:
            std::cout << "input width: ";
            double width;
            std::cin >> width;
            std::cout << "input height: ";
            double height;
            std::cin >> height;
            fptr = new Rectanglee(width, height);
            break;
        case 2:
            std::cout << "input radius: ";
            double radius;
            std::cin >> radius;
            fptr = new Circle(radius);
            break;
        case 3:
            std::cout << "input base: ";
            double base;
            std::cin >> base;
            std::cout << "input height: ";
            double height2;
            std::cin >> height2;
            fptr = new Triangle(base, height2);
            break;
        case 0:
            isOpen = false;
            break;
        default:
            std::cout << "stupid?)" << std::endl;
            break;
        }
        std::cout << fptr->area() << std::endl;
        delete fptr;
    }
}
