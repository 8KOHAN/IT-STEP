#include "Reservoir.h"

Reservoir::Reservoir(const std::string& name = "", const std::string& type = "", double width = 0, double length = 0, double maxDepth = 0)
    : name(name), type(type), width(width), length(length), maxDepth(maxDepth) {}
Reservoir::Reservoir(const Reservoir& other)
    : name(other.name), type(other.type), width(other.width),
    length(other.length), maxDepth(other.maxDepth) {}

double Reservoir::getVolume() const {
    return width * length * maxDepth;
}
double Reservoir::getSurfaceArea() const {
    return width * length;
}

bool Reservoir::isSameType(const Reservoir& other) const {
    return type == other.type;
}

int Reservoir::compareArea(const Reservoir& other) const {
    if (!isSameType(other)) return -2;
    if (getSurfaceArea() > other.getSurfaceArea()) return 1;
    if (getSurfaceArea() < other.getSurfaceArea()) return -1;
    return 0;
}

void Reservoir::setName(const std::string& name) {
    this->name = name;
}
void Reservoir::setType(const std::string& type) {
    this->type = type;
}
void Reservoir::setDimensions(double width, double length, double maxDepth) {
    this->width = width;
    this->length = length;
    this->maxDepth = maxDepth;
}

std::string Reservoir::getName() const {
    return name;
}
std::string Reservoir::getType() const {
    return type;
}

void Reservoir::display() const {
    std::cout << "Name: " << name << "\nType: " << type << std::endl;
    std::cout << "width: " << width << ", length: " << length << ", Max depth: " << maxDepth << "\n";
}
