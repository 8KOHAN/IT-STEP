# Reservoir Manager (C++ OOP Project)

This project is a simple object-oriented program written in C++ for managing water bodies (reservoirs). It demonstrates class design, dynamic object management, and basic console interface features.

## Features

- Create and manage multiple `Reservoir` objects
- Add new reservoirs with dimensions and type
- Delete existing reservoirs by index
- Display all reservoirs
- Compare surface areas of two reservoirs of the same type
- Automatically manage memory using `std::string` and `std::vector`

## Project Structure

ReservoirProject/
├── Reservoir/
│ ├── Reservoir.h # Class definition
│ └── Reservoir.cpp # Class implementation
├── main.cpp # Console menu interface
├── README.md # This file

## Class `Reservoir`

### Fields:
- `std::string name` – reservoir name
- `std::string type` – type (lake, sea, etc.)
- `double width`, `length`, `maxDepth` – dimensions

### Key Methods:
- `double getSurfaceArea()` – calculates surface area
- `double getVolume()` – calculates approximate volume
- `bool isSameType(const Reservoir&)` – checks if two reservoirs are the same type
- `int compareArea(const Reservoir&)` – compares surface area:
  - `1`: this is larger
  - `-1`: this is smaller
  - `0`: equal
  - `-2`: different types

### Constructors:
- Default constructor
- Parameterized constructor (`explicit`)
- Copy constructor
- Destructor
