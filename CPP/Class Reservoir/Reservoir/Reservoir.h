#pragma once

#include <iostream>
#include <string>

class Reservoir {
private:
    std::string name;
    std::string type;
    double width;
    double length;
    double maxDepth;

public:
    explicit Reservoir(const std::string& name, const std::string& type, double width, double length, double maxDepth);
    Reservoir(const Reservoir& other);

    double getVolume() const;
    double getSurfaceArea() const;
    bool isSameType(const Reservoir& other) const;
    int compareArea(const Reservoir& other) const;

    void setName(const std::string& name);
    void setType(const std::string& type);
    void setDimensions(double width, double length, double maxDepth);

    std::string getName() const;
    std::string getType() const;

    void display() const;
};
