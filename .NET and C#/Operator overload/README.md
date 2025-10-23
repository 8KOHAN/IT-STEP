# Operator overload

A small collection of educational console programs designed to practice key C# concepts — **classes, properties, indexers, operator overloading, and encapsulation**.

---

## Contents

1. **Temperature Array**  
   Implements a `TemperatureArray` class that stores daily temperatures for a week.  
   **Features:**  
   - Uses **auto-properties** for each day of the week (`Monday` … `Sunday`)  
   - Provides an **indexer** (`this[int index]`) for convenient access using day indexes  
   - Calculates **average weekly temperature** (`GetAverageTemperature()`)  
   - Demonstrates safe array-like access and data validation  

2. **Product**  
   Defines a `Product` class that stores information about an item — **name, quantity, and price**.  
   **Features:**  
   - Uses **properties** with validation (quantity and price cannot be negative)  
   - Overloads arithmetic operators `+` and `-` to increase or decrease product quantity  
   - Overloads comparison operators:  
     - `==` and `!=` to compare products **by price**  
     - `>` and `<` to compare products **by quantity**  
   - Includes a `ToString()` method for formatted output  

---

## Format

Each task is implemented as a **separate console application in C#**
