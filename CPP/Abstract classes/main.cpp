#include <iostream>
#include <fstream>
#include <vector>
#include <string>

class Shape {
public:
    virtual void Show() const = 0;
    virtual void Save(std::ofstream& out) const = 0;
    virtual void Load(std::ifstream& in) = 0;
    virtual ~Shape() {}
};

class Square : public Shape {
public:
    Square(int x = 0, int y = 0, int side = 0) : x(x), y(y), side(side) {}
    void Show() const override {
        std::cout << "Square: (" << x << ", " << y << "), side = " << side << std::endl;
    }
    void Save(std::ofstream& out) const override {
        out << "Square " << x << " " << y << " " << side << std::endl;
    }
    void Load(std::ifstream& in) override {
        in >> x >> y >> side;
    }
private:
    int x, y;
    int side;
};

class Rectangle : public Shape {
public:
    Rectangle(int x = 0, int y = 0, int width = 0, int height = 0)
        : x(x), y(y), width(width), height(height) {}
    void Show() const override {
        std::cout << "Rectangle: (" << x << ", " << y << "), width = "
            << width << ", height = " << height << std::endl;
    }
    void Save(std::ofstream& out) const override {
        out << "Rectangle " << x << " " << y << " " << width << " " << height << std::endl;
    }
    void Load(std::ifstream& in) override {
        in >> x >> y >> width >> height;
    }
private:
    int x, y;
    int width, height;
};

class Circle : public Shape {
public:
    Circle(int x = 0, int y = 0, int radius = 0) : x(x), y(y), radius(radius) {}
    void Show() const override {
        std::cout << "Circle: center (" << x << ", " << y << "), radius = " << radius << std::endl;
    }
    void Save(std::ofstream& out) const override {
        out << "Circle " << x << " " << y << " " << radius << std::endl;
    }
    void Load(std::ifstream& in) override {
        in >> x >> y >> radius;
    }
private:
    int x, y;
    int radius;
};

Shape* CreateShapeFromFile(std::ifstream& in) {
    std::string type;
    if (!(in >> type)) return nullptr;

    Shape* shape = nullptr;
    if (type == "Square") shape = new Square();
    else if (type == "Rectangle") shape = new Rectangle();
    else if (type == "Circle") shape = new Circle();

    if (shape) shape->Load(in);
    return shape;
}

int main() {
    std::vector<Shape*> shapes;
    shapes.push_back(new Square(0, 0, 10));
    shapes.push_back(new Rectangle(5, 5, 20, 10));
    shapes.push_back(new Circle(15, 15, 7));

    std::ofstream outFile("shapes.txt");
    for (Shape* s : shapes)
        s->Save(outFile);
    outFile.close();

    for (Shape* s : shapes)
        delete s;
    shapes.clear();

    std::ifstream inFile("shapes.txt");
    std::vector<Shape*> loadedShapes;
    while (true) {
        Shape* s = CreateShapeFromFile(inFile);
        if (!s) break;
        loadedShapes.push_back(s);
    }
    inFile.close();

    for (Shape* s : loadedShapes) {
        s->Show();
        delete s;
    }

    return 0;
}
