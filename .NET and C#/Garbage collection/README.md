# Books & Library

A small educational console project designed to practice key **C# OOP concepts** — including **classes**, **destructors (finalizers)**, and **the `IDisposable` interface**.

---

## Contents

1. **Book**  
   Represents a single book with basic information and demonstrates proper resource management.  
   **Features:**  
   - Stores key data:  
     - `Title` — book title  
     - `Author` — book author  
     - `Year` — publication year  
     - `Pages` — total number of pages  
   - Implements the `IDisposable` interface  
     - Outputs a message when resources are released  
     - Uses a **finalizer** (`~Book()`) to show when the object is collected by the garbage collector  
   - Demonstrates object lifecycle and cleanup logic  

2. **Library**  
   Represents a simple library that stores a collection of books.  
   **Features:**  
   - Contains an internal collection of `Book` objects  
   - Provides methods:  
     - `AddBook(Book book)` — adds a new book to the library  
     - `DisplayAllBooks()` — displays all stored books  
   - Implements the `IDisposable` interface to:  
     - Release resources associated with books  
     - Clear the internal collection  
     - Show cleanup messages through console output  
   - Includes a **finalizer** for demonstration of GC behavior  
