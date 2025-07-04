# Custom String Class in C++

This project implements a fully functional custom `String` class in C++ that replicates key behavior of the standard `std::string` — including memory management, string manipulation, and operator overloading — with clean, bug-free logic.

---

## Features

- Manual dynamic memory handling with deep copy and move semantics
- Fully implements the **Rule of Five**:
  - Constructor
  - Copy constructor
  - Move constructor
  - Copy assignment operator
  - Move assignment operator
  - Destructor
- Core methods:
  - `length()`, `empty()`, `clear()`
  - `front()`, `back()`, `begin()`, `end()`
  - `find(char[], int)`
  - `compare(String)` and `compare(char[])`
- Operator overloads:
  - `==` for string equality
  - `+` for concatenation
  - `[]` for character access
  - Stream operators `>>` and `<<`

---

## Key Fixes Implemented

- `find()` now correctly uses `==` instead of `=`
- `empty()` properly returns a `bool` result
- `operator+` calculates the correct new length and allocates sufficient memory
- All memory operations are safe and free of leaks or double frees

---

## Use Cases

- Teaching low-level string manipulation in C++
- Understanding dynamic memory and object life cycles
- Practicing class design and operator overloading
