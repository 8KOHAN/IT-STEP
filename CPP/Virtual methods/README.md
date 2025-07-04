# 🧮 Geometric Figures Area Calculator (C++)

This C++ console application demonstrates **polymorphism** and **dynamic dispatch** through a set of geometric figures — rectangle, circle, and triangle — each calculating its own area based on user input.

---

## ✅ Features

- Uses an abstract base class `Figure` with a pure virtual method `area()`
- Implements:
  - `Rectanglee` (area = width × height)
  - `Circle` (area = π × radius²)
  - `Triangle` (area = ½ × base × height)
- Dynamically allocates and deletes each figure object
- Accepts user input from the console with a simple menu interface
