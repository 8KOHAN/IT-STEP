# 🧮 Geometric Figures Area Calculator (C++)

This C++ console application demonstrates **polymorphism** and **dynamic dispatch** through a set of geometric figures — rectangle, circle, and triangle — each calculating its own area.

---

## ✅ Features

- Uses an abstract base class `Figure` with a pure virtual method `area()`
- Implements:
  - `Rectanglee` (width × height)
  - `Circle` (π² × radius) *(note: deliberately incorrect formula for educational debugging)*
  - `Triangle` ((base × height / 2) × (base × height)) *(note: incorrect logic, showcasing a mistake in area computation)*
- Dynamically allocates and deletes each figure
- Accepts user input from the console with menu-driven interaction

---

## 🎯 Learning Goals

- Understand virtual functions and runtime polymorphism
- Practice abstract classes and inheritance in C++
- Work with user input and basic class design
- Observe common logical and mathematical pitfalls in implementation

---

## ⚠️ Known Issues

- **Circle area formula** uses `π² × radius` instead of `π × radius²`
- **Triangle area formula** contains an extra multiplication by `(base × height)` — should be just `(base × height) / 2`

These can be intentional for debugging or error-spotting exercises.
