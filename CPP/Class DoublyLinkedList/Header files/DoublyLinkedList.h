#pragma once

#include "node.h"
#include <iostream>

class DoublyLinkedList {
private:
    Node* head;
    Node* tail;
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
    Node* find(int value);
    void clear();
    int size() const;
    bool empty() const;
    void print_forward() const;
    void print_backward() const;
};
