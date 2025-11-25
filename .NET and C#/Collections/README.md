# Collections & Generics

A small collection of educational C# console projects designed to practice **generics**, **Collections**, and **custom iterators**.

---

## Contents

1. **Max of Three (Generic Method)**  
   Demonstrates a simple use of generics to compute the maximum of three values.  
   **Includes:**  
   - Method:  
     - `MaxOfThree<T>(T a, T b, T c)` — returns the largest value  
   - Features:  
     - Type constraint `where T : IComparable<T>`  
     - Works with numbers, strings, and other comparable types  
   - Demonstrated in the program:  
     - Calling the method with different data types  
     - Comparing values using `CompareTo`

2. **FilterByTwoCriteria (Generic Filtering)**  
   Demonstrates functional-style filtering using two independent predicates.  
   **Includes:**  
   - Method:  
     - `FilterByTwoCriteria<T>(IEnumerable<T> collection, Func<T, bool> p1, Func<T, bool> p2)`  
   - Features:  
     - Uses generic types  
     - Accepts two `Func<T, bool>` filters  
     - Returns a new filtered collection  
   - Demonstrated in the program:  
     - Filtering numbers (e.g., >10 and divisible by 5)  
     - Filtering strings (e.g., starts with "ca" and length >3)

3. **House / Apartment / Resident (Custom Iterators)**  
   Demonstrates how to implement iterators using `IEnumerable<T>` in custom classes.  
   **Includes:**  
   - Classes:  
     - `Resident` — stores resident name  
     - `Apartment` — stores apartment number and list of residents  
     - `House` — stores a list of apartments  
   - Iterator Support:  
     - `Apartment` implements `IEnumerable<Resident>`  
     - `House` implements `IEnumerable<Apartment>`  
   - Demonstrated in the program:  
     - Using nested `foreach` loops  
     - Encapsulating internal lists while exposing enumerators  
     - Clean and readable iteration over custom objects

---

## Format

Each task is implemented as a **separate C# console application**.
