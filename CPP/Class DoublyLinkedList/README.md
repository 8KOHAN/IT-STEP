# Doubly Linked List Implementation in C++

This project implements a classic **doubly linked list** data structure in C++ with full support for forward/backward traversal, dynamic insertion and deletion, and memory-safe operations.

---

## Features

- Core operations:
  - `push_front`, `push_back` — add nodes to beginning or end
  - `pop_front`, `pop_back` — remove nodes from beginning or end
  - `insert(position, value)` — insert at a specific index
  - `erase(position)` — delete a node by index
  - `find(value)` — locate a node by value
  - `clear()` — delete all elements
- Status checkers:
  - `size()`, `empty()`
- Output utilities:
  - `print_forward()` — prints list head → tail
  - `print_backward()` — prints list tail → head
- Safely handles edge cases (empty list, out-of-bounds insert/delete)

---

## Architecture

- `Node` class stores value + two pointers: `prev` and `next`
- `DoublyLinkedList` manages `head`, `tail`, and internal `count`
- Clean separation between class interface (`.h`) and implementation (`.cpp`)
- Proper memory cleanup in destructor and `clear()` method
