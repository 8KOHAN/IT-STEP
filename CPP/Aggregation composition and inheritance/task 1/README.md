# Pet Inheritance Hierarchy in C++

This project demonstrates a simple and clean example of **class inheritance** and **dynamic polymorphism** using pets.

---

## Features

- Abstract concept of a pet modeled through the `Pet` base class
- Derived classes:
  - `Dog`
  - `Cat`
  - `Parrot`
- Each subclass overrides the virtual `displayInfo()` method to show its type and attributes
- Constructor inheritance to initialize common properties (`name`, `age`, `color`)
