#pragma once

#include <string>
#include <vector>

struct Node {
    std::string carNumber;
    std::vector<std::string> violations;
    Node* left;
    Node* right;

    Node(const std::string& number, const std::string& violation);
};

class TrafficDatabase {
private:
    Node* root;

    Node* insert(Node* node, const std::string& number, const std::string& violation);
    void printAll(Node* node);
    void printCar(Node* node, const std::string& number);
    void printRange(Node* node, const std::string& from, const std::string& to);

public:
    TrafficDatabase();
    void addViolation(const std::string& number, const std::string& violation);
    void printDatabase();
    void printByNumber(const std::string& number);
    void printByRange(const std::string& from, const std::string& to);
};
