# Drob and Person Class System in C++

This C++ project implements two independent class structures:

- **Drob** — for handling and calculating rational fractions
- **Person** — for modeling human data with support for deep copying, move semantics, and date of birth handling

---

## Drob Class Highlights

- Represents a fraction (`numerator` / `denominator`)
- Supports:
  - Addition, subtraction, multiplication, and division
  - Operations with both `Drob` objects and integers
- Automatically simplifies results
- Prevents division by zero
- Includes user input and console output functions

---

## Person Class Highlights

- Represents a person with:
  - ID, name, surname, patronymic
  - Birth date via `Date` class
- Implements:
  - Full **Rule of Five**: copy/move constructors and assignment, destructor
  - Deep copy for dynamically allocated strings# Drob and Person Class System in C++

This C++ project implements two independent class structures:

- **Drob** — for handling and calculating rational fractions
- **Person** — for modeling human data with support for deep copying, move semantics, and date of birth handling

---

## ✅ Drob Class Highlights

- Represents a fraction (`numerator` / `denominator`)
- Supports:
  - Addition, subtraction, multiplication, and division
  - Operations with both `Drob` objects and integers
- Automatically simplifies results
- Prevents division by zero
- Includes user input and console output functions

---

## ✅ Person Class Highlights

- Represents a person with:
  - ID, name, surname, patronymic
  - Birth date via `Date` class
- Implements:
  - Full **Rule of Five**: copy/move constructors and assignment, destructor
  - Deep copy for dynamically allocated strings
  - Instance counter tracking how many `Person` objects exist
- Encapsulated accessors/mutators for all fields

---

## 🎓 Educational Goals

- Demonstrates:
  - Dynamic memory management with `char*`
  - Proper use of deep copying to avoid memory leaks
  - Composition (Date inside Person)
  - Defensive programming (e.g., `nullptr` checks, default fallback)

  - Instance counter tracking how many `Person` objects exist
- Encapsulated accessors/mutators for all fields

---

## Educational Goals

- Demonstrates:
  - Dynamic memory management with `char*`
  - Proper use of deep copying to avoid memory leaks
  - Composition (Date inside Person)
  - Defensive programming (e.g., `nullptr` checks, default fallback)
