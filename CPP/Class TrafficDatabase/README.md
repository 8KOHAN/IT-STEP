# Traffic Violation Database (C++)

This C++ project implements a binary search tree–based system for managing traffic violations by car number. It allows adding violations, retrieving specific car data, and displaying records within a range.

---

## Features

- Stores car numbers and associated traffic violations using a binary search tree
- Allows:
  - Adding multiple violations per car
  - Printing all car records in sorted order
  - Querying a specific car's violation history
  - Retrieving all records within a specified license plate range

---

## Data Structure

- Each node in the tree contains:
  - A car number (`std::string`)
  - A list of violations (`std::vector<std::string>`)
  - Left and right child pointers

- Insertion maintains BST order based on car number

---

## Highlights

- Efficient search and range-based queries via in-order traversal
- Encapsulation of tree logic inside the `TrafficDatabase` class
- Clean and structured output formatting for easy readability
