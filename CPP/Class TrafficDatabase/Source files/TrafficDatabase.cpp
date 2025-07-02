#include "TrafficDatabase.h"
#include <iostream>

Node::Node(const std::string& number, const std::string& violation)
    : carNumber(number), left(nullptr), right(nullptr) {
    violations.push_back(violation);
}

TrafficDatabase::TrafficDatabase() : root(nullptr) {}

Node* TrafficDatabase::insert(Node* node, const std::string& number, const std::string& violation) {
    if (!node)
        return new Node(number, violation);
    if (number == node->carNumber)
        node->violations.push_back(violation);
    else if (number < node->carNumber)
        node->left = insert(node->left, number, violation);
    else
        node->right = insert(node->right, number, violation);
    return node;
}

void TrafficDatabase::addViolation(const std::string& number, const std::string& violation) {
    root = insert(root, number, violation);
}

void TrafficDatabase::printAll(Node* node) {
    if (!node) return;
    printAll(node->left);
    std::cout << "Car: " << node->carNumber << "\nViolations:\n";
    for (const std::string& v : node->violations)
        std::cout << "  - " << v << '\n';
    std::cout << "------------------\n";
    printAll(node->right);
}

void TrafficDatabase::printCar(Node* node, const std::string& number) {
    if (!node) {
        std::cout << "Car not found.\n";
        return;
    }
    if (number == node->carNumber) {
        std::cout << "Car: " << node->carNumber << "\nViolations:\n";
        for (const std::string& v : node->violations)
            std::cout << "  - " << v << '\n';
    }
    else if (number < node->carNumber)
        printCar(node->left, number);
    else
        printCar(node->right, number);
}

void TrafficDatabase::printRange(Node* node, const std::string& from, const std::string& to) {
    if (!node) return;
    if (from < node->carNumber)
        printRange(node->left, from, to);
    if (from <= node->carNumber && node->carNumber <= to) {
        std::cout << "Car: " << node->carNumber << "\nViolations:\n";
        for (const std::string& v : node->violations)
            std::cout << "  - " << v << '\n';
        std::cout << "------------------\n";
    }
    if (node->carNumber < to)
        printRange(node->right, from, to);
}

void TrafficDatabase::printDatabase() {
    printAll(root);
}

void TrafficDatabase::printByNumber(const std::string& number) {
    printCar(root, number);
}

void TrafficDatabase::printByRange(const std::string& from, const std::string& to) {
    printRange(root, from, to);
}
