# C++ Matrix Project

This project demonstrates the implementation of a **Matrix class in C++** with support for input/output streams, dynamic memory management, and file saving.

## Features
- **Dynamic Matrix Allocation**  
  Matrix elements are allocated dynamically and initialized with random numbers (`0–999`).

- **Copy Assignment Operator**  
  Properly handles deep copying of matrices to avoid memory issues.

- **Stream Operators**  
  - `operator<<` – prints the matrix to the console.  
  - `operator>>` – allows interactive user input to fill the matrix.  

- **File Saving** (`saveToFile`)  
  Saves the matrix to a text file, including its dimensions and values.

- **Destructor**  
  Ensures all dynamically allocated memory is freed.
