# 👔 `Overcoat` Class & 🏠 `Flat` Class

---

## 📌 Quick Overview

### 👔 Overcoat

The `Overcoat` class represents outerwear with the following fields:
- `type` — type of coat (e.g., `"Raincoat"`, `"Down jacket"`).
- `price` — price (type `double`).

#### Implemented operators:
- `==` — checks if the coat types are the same.
- `=` — assignment operator.
- `>` — compares prices (only if types are the same).

---

### 🏠 Flat

The `Flat` class models an apartment with the following fields:
- `area` — area (type `double`).
- `price` — price (type `double`).

#### Implemented operators:
- `==` — checks if the areas are equal.
- `=` — assignment operator.
- `>` — compares prices.

---

## 📁 Project Structure

```bash
Project/
├── Overcoat/
│   ├── Overcoat.h
│   └── Overcoat.cpp
├── Flat/
│   ├── Flat.h
│   └── Flat.cpp
├── main.cpp
└── README.md
