#pragma once

#include <memory>

class Node {
public:
    int value;
    std::weak_ptr<Node> prev;
    std::shared_ptr<Node> next;

    Node(int val);
};
