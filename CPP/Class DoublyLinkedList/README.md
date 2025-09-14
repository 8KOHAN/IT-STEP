# Doubly Linked List Implementation in C++ (Smart Pointers)

This project implements a classic **doubly linked list** data structure in C++ with full support for forward/backward traversal, dynamic insertion and deletion, and **memory-safe operations using smart pointers**.

---

## Features

- Core operations:
  - `push_front`, `push_back` — add nodes to beginning or end
  - `pop_front`, `pop_back` — remove nodes from beginning or end
  - `insert(position, value)` — insert at a specific index
  - `erase(position)` — delete a node by index
  - `find(value)` — locate a node by value (**returns `std::shared_ptr<Node>`**)
  - `clear()` — delete all elements automatically
- Status checkers:
  - `size()`, `empty()`
- Output utilities:
  - `print_forward()` — prints list head → tail
  - `print_backward()` — prints list tail → head
- Safely handles edge cases (empty list, out-of-bounds insert/delete)

---

## Architecture

- **Node**
  - `int value`
  - `std::weak_ptr<Node> prev` — weak reference to the previous node  
  - `std::shared_ptr<Node> next` — strong reference to the next node  
- **DoublyLinkedList**
  - Manages `std::shared_ptr<Node> head` and `tail`
  - Tracks size with `count`
- **Memory safety**
  - Smart pointers automatically handle memory cleanup
  - No need for manual `delete`
  - No memory leaks thanks to `weak_ptr` preventing circular references
