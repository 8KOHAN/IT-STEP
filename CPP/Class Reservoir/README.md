# Reservoir Manager (C++ OOP Project)

This project is a object-oriented program written in C++ for managing water bodies (reservoirs). It demonstrates class design, dynamic object management, and basic console interface features.

## Features

- Create and manage multiple `Reservoir` objects
- Add new reservoirs with dimensions and type
- Delete existing reservoirs by index
- Display all reservoirs
- Compare surface areas of two reservoirs of the same type
- Automatically manage memory using `std::string` and `std::vector`

## Project Structure
```bash
ReservoirProject/
├── Reservoir/
│ ├── Reservoir.h # Class definition
│ └── Reservoir.cpp # Class implementation
├── main.cpp # Console menu interface
├── README.md # This file
```
## Class `Reservoir`

### Constructors:
- Default constructor
- Parameterized constructor (`explicit`)
- Copy constructor
- Destructor
