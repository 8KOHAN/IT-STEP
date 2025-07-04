# ➗ Fraction Arithmetic in C++

This project implements a C++ class `Drob` (fraction) for performing basic arithmetic with rational numbers, supporting both fractions and integers.

---

## ✅ Features

- Stores fractions using numerator and denominator
- Automatically simplifies all fractions after each operation
- Handles zero denominators gracefully
- Supports:
  - Addition, subtraction, multiplication, and division with both other fractions and integers
- Proper sign handling and error checking

---

## 🧪 Sample Operations

- `A + B`, `A - B`, `A * B`, `A / B` for two user-input fractions
- Same operations for `A` and an integer (`5` in example)

---

## 📌 Highlights

- Implements a private `gcd()` function to simplify results
- Ensures negative signs are always in the numerator
- Uses modular method structure for code clarity
