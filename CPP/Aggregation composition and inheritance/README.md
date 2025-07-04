# Aggregation, Composition & Inheritance in C++

This project consists of two tasks demonstrating the principles of **inheritance**, **composition**, **dynamic polymorphism**, and **operator overloading** in modern C++.

---

## Task 1: Pet Hierarchy

Implements a polymorphic base class `Pet` and three derived classes: `Dog`, `Cat`, and `Parrot`.

### Key Features

- **Base class** `Pet` contains common attributes: `name`, `age`, `color`
- Derived classes:
  - `Dog`
  - `Cat`
  - `Parrot`
- Each class overrides the `displayInfo()` method
- Demonstrates **virtual function dispatch** and **clean inheritance**

---

## Task 2: String & BitString Classes

Implements a custom `String` class and a derived `BitString` class for binary operations using two’s complement representation.

### `String` Class Features

- Manual dynamic memory management (`char*`)
- Implements:
  - Rule of Five (copy/move constructors & assignment, destructor)
  - Operator overloads: `==`, `!=`, `+`, `+=`, `[]`, stream I/O
  - Utility methods: `compare`, `find`, `length`, `empty`, `clear`

### `BitString` Class Features

- Inherits from `String`
- Validates binary input (`0` and `1` only)
- Converts binary strings to signed integers and back
- Supports:
  - `invertSign()` for two’s complement negation
  - Arithmetic: `+`, `+=` between two `BitString` objects
  - Conversion to and from integers

---

## Highlights

- Showcases key object-oriented programming concepts:
  - Inheritance and virtual methods
  - Encapsulation and protected access
  - Constructor delegation
  - Operator overloading
- Teaches binary logic and bitwise arithmetic through `BitString`
- Demonstrates robust memory handling and input safety
