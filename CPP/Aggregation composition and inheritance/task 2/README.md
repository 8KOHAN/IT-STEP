# Custom String and BitString Classes in C++

This project implements a dynamic C-style `String` class and a binary `BitString` subclass using object-oriented techniques in C++.

---

## String Class

- Manages character arrays manually (`char*`)
- Supports:
  - Copy and move constructors
  - Assignment operators
  - Operator overloads: `==`, `!=`, `+`, `+=`, `[]`, stream I/O
- Additional methods:
  - `length()`, `clear()`, `compare()`, `find()`, `empty()`
- Demonstrates full **Rule of Five**

---

## BitString Class

- Inherits from `String`
- Accepts and validates binary strings (`0`, `1` only)
- Core operations:
  - `invertSign()` – flips sign using two’s complement
  - `toInt()` – converts binary to signed integer
  - `fromInt()` – creates binary from integer
  - `+`, `+=` operators for binary addition
- Handles signed integers using two’s complement logic
