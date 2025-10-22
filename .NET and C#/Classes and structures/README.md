# Warehouse and Employee Management

A small collection of educational C# console programs to practice working with **structures**, **enums**, **nullable types**, and **basic CRUD operations**.

## Contents

1. **Warehouse Program** — simulates a simple warehouse system that stores items, grouped by category.  
   - Uses an `Item` structure with fields for name, quantity, price, and category.  
   - Includes an `ItemCategory` enum (`Electronics`, `Furniture`, `Food`).  
   - The `Warehouse` class provides methods to **add**, **remove**, **update**, and **display** items.  
   - Demonstrates the use of **LINQ** (`FirstOrDefault`) and **lambda expressions (`=>`)** for searching and filtering.

2. **Class Employee** — models employees with optional data fields.  
   - Uses an `Employee` structure with fields: `Name`, `Age`, and `Salary`.  
   - Both `Age` and `Salary` are **nullable** (`int?`, `double?`), allowing for missing data.  
   - Includes a `DisplayInfo()` method that checks for `null` values using `.HasValue` and outputs readable information.  
   - Demonstrates how to safely handle optional data and print formatted output.

## Format

Each project is implemented as a **separate console application in C#**
