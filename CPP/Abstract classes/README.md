# Serializable Shape Hierarchy in C++

This C++ project demonstrates a polymorphic class hierarchy for basic 2D shapes (`Square`, `Rectangle`, `Circle`) with support for serialization and deserialization to/from text files.

---

## Features

- Abstract base class `Shape` with pure virtual methods:
  - `Show()` — displays shape details
  - `Save(std::ofstream&)` — writes shape data to file
  - `Load(std::ifstream&)` — loads shape data from file
- Derived classes:
  - `Square` (x, y, side)
  - `Rectangle` (x, y, width, height)
  - `Circle` (x, y, radius)
- Serialization format: plain-text line per shape with type and parameters
- Factory function `CreateShapeFromFile()` parses and reconstructs shape objects from file
- Full memory cleanup and pointer management
