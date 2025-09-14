#pragma once

#include "node.h"

class DoublyLinkedList {
private:
    std::shared_ptr<Node> head;
    std::shared_ptr<Node> tail;
    int count;
public:
    DoublyLinkedList();
    ~DoublyLinkedList();

    void push_front(int value);
    void push_back(int value);
    void pop_front();
    void pop_back();
    void insert(int position, int value);
    void erase(int position);
    std::shared_ptr<Node> find(int value);
    void clear();
    int size() const;
    bool empty() const;
    void print_forward() const;
    void print_backward() const;
};
