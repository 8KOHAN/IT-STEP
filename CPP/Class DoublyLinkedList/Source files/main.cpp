#include <iostream>
#include "DoublyLinkedList.h"

int main() {
    DoublyLinkedList list;

    list.push_back(10);
    list.push_back(20);
    list.push_front(5);
    list.insert(1, 15);

    list.print_forward();
    list.print_backward();

    list.erase(1);
    list.print_forward();

    std::shared_ptr<Node> found = list.find(10);
    if (found) std::cout << "Found: " << found->value << std::endl;

    std::cout << "Size: " << list.size() << std::endl;
    std::cout << "Empty: " << (list.empty() ? "Yes" : "No") << std::endl;

    list.clear();
    list.print_forward();

    return 0;
}
