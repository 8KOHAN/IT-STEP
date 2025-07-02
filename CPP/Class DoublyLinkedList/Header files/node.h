#pragma once

class Node {
public:
    int value;
    Node* prev;
    Node* next;

    Node(int val);
};
