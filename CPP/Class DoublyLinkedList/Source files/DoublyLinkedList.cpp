#include "DoublyLinkedList.h"

DoublyLinkedList::DoublyLinkedList() : head(nullptr), tail(nullptr), count(0) {}

DoublyLinkedList::~DoublyLinkedList() {
    clear();
}

void DoublyLinkedList::push_front(int value) {
    Node* new_node = new Node(value);
    new_node->next = head;
    if (head) head->prev = new_node;
    head = new_node;
    if (!tail) tail = head;
    count++;
}

void DoublyLinkedList::push_back(int value) {
    Node* new_node = new Node(value);
    new_node->prev = tail;
    if (tail) tail->next = new_node;
    tail = new_node;
    if (!head) head = tail;
    count++;
}

void DoublyLinkedList::pop_front() {
    if (!head) return;
    Node* temp = head;
    head = head->next;
    if (head) head->prev = nullptr;
    else tail = nullptr;
    delete temp;
    count--;
}

void DoublyLinkedList::pop_back() {
    if (!tail) return;
    Node* temp = tail;
    tail = tail->prev;
    if (tail) tail->next = nullptr;
    else head = nullptr;
    delete temp;
    count--;
}

void DoublyLinkedList::insert(int position, int value) {
    if (position <= 0) {
        push_front(value);
    }
    else if (position >= count) {
        push_back(value);
    }
    else {
        Node* current = head;
        for (int i = 0; i < position; ++i) current = current->next;
        Node* new_node = new Node(value);
        new_node->prev = current->prev;
        new_node->next = current;
        current->prev->next = new_node;
        current->prev = new_node;
        count++;
    }
}

void DoublyLinkedList::erase(int position) {
    if (position < 0 || position >= count) return;
    if (position == 0) {
        pop_front();
    }
    else if (position == count - 1) {
        pop_back();
    }
    else {
        Node* current = head;
        for (int i = 0; i < position; ++i) current = current->next;
        current->prev->next = current->next;
        current->next->prev = current->prev;
        delete current;
        count--;
    }
}

Node* DoublyLinkedList::find(int value) {
    Node* current = head;
    while (current) {
        if (current->value == value) return current;
        current = current->next;
    }
    return nullptr;
}

void DoublyLinkedList::clear() {
    while (head) {
        Node* temp = head;
        head = head->next;
        delete temp;
    }
    tail = nullptr;
    count = 0;
}

int DoublyLinkedList::size() const {
    return count;
}

bool DoublyLinkedList::empty() const {
    return count == 0;
}

void DoublyLinkedList::print_forward() const {
    Node* current = head;
    while (current) {
        std::cout << current->value << " ";
        current = current->next;
    }
    std::cout << std::endl;
}

void DoublyLinkedList::print_backward() const {
    Node* current = tail;
    while (current) {
        std::cout << current->value << " ";
        current = current->prev;
    }
    std::cout << std::endl;
}
