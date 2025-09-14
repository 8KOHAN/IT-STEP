#include "DoublyLinkedList.h"
#include <iostream>

DoublyLinkedList::DoublyLinkedList() : head(nullptr), tail(nullptr), count(0) {}

DoublyLinkedList::~DoublyLinkedList() {
    clear();
}

void DoublyLinkedList::push_front(int value) {
    auto new_node = std::make_shared<Node>(value);
    new_node->next = head;
    if (head) {
        head->prev = new_node;
    }
    head = new_node;
    if (!tail) tail = head;
    count++;
}

void DoublyLinkedList::push_back(int value) {
    auto new_node = std::make_shared<Node>(value);
    new_node->prev = tail;
    if (tail) {
        tail->next = new_node;
    }
    tail = new_node;
    if (!head) head = tail;
    count++;
}

void DoublyLinkedList::pop_front() {
    if (!head) return;
    head = head->next;
    if (head) {
        head->prev.reset();
    }
    else {
        tail.reset();
    }
    count--;
}

void DoublyLinkedList::pop_back() {
    if (!tail) return;
    tail = tail->prev.lock();
    if (tail) {
        tail->next.reset();
    }
    else {
        head.reset();
    }
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
        auto current = head;
        for (int i = 0; i < position; ++i) current = current->next;
        auto new_node = std::make_shared<Node>(value);

        new_node->prev = current->prev;
        new_node->next = current;
        if (auto prev = current->prev.lock()) {
            prev->next = new_node;
        }
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
        auto current = head;
        for (int i = 0; i < position; ++i) current = current->next;

        if (auto prev = current->prev.lock()) {
            prev->next = current->next;
        }
        if (current->next) {
            current->next->prev = current->prev;
        }

        count--;
    }
}

std::shared_ptr<Node> DoublyLinkedList::find(int value) {
    auto current = head;
    while (current) {
        if (current->value == value) return current;
        current = current->next;
    }
    return nullptr;
}

void DoublyLinkedList::clear() {
    head.reset();
    tail.reset();
    count = 0;
}

int DoublyLinkedList::size() const {
    return count;
}

bool DoublyLinkedList::empty() const {
    return count == 0;
}

void DoublyLinkedList::print_forward() const {
    auto current = head;
    while (current) {
        std::cout << current->value << " ";
        current = current->next;
    }
    std::cout << std::endl;
}

void DoublyLinkedList::print_backward() const {
    auto current = tail;
    while (current) {
        std::cout << current->value << " ";
        current = current->prev.lock();
    }
    std::cout << std::endl;
}
