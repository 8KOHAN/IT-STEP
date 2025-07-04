# Templated Dynamic Array Class in C++

This C++ project implements a generic, resizable `Array<T>` class that mimics a subset of dynamic array behavior, similar to `std::vector`, but with manual control over size, growth factor, and memory handling.

---

## Features

- Fully templated class: works with any data type
- Manual control over:
  - Initial size
  - Growth factor (`growBy`)
- Key functionalities:
  - `Add`, `InsertAt`, `RemoveAt`
  - `SetAt`, `GetAt`
  - `SetSize`, `FreeExtra`, `RemoveAll`
  - `Append` another array
- Operator overloads:
  - `[]` with bounds checking (const and non-const)
  - Copy/move assignment and constructors

---

## Highlights

- Custom dynamic memory management (no STL used)
- Efficient reallocation and memory reuse
- Bound-checking included in const `operator[]`
- Supports shrinking with `FreeExtra()`
- Ensures safe copying/moving between arrays
