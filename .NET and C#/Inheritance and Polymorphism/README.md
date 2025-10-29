# Musical Instruments

A simple educational C# console app demonstrating **OOP principles** — **abstract classes**, **inheritance**, and **method overriding**.

## Contents

1. **Abstract Class – `MusicalInstrument`**  
   - Fields: `Name`, `Characteristics`.  
   - Abstract methods: `Sound()`, `History()`.  
   - Implemented methods: `Show()`, `Desc()`.

2. **Derived Classes – `Violin`, `Trombone`, `Ukulele`, `Cello`**  
   - Each defines its own sound using `Console.Beep()` and a brief history.  
   - Constructors set instrument name and description.

3. **Program.cs**  
   - Creates an array of instruments and calls `Show()`, `Desc()`, `History()`, and `Sound()` for each.  
   - Demonstrates **polymorphism** in action.
