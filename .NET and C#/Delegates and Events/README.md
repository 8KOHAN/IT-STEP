# Delegates & Events

A small collection of educational C# console projects designed to practice **delegates and events**.

---

## Contents

1. **Backpack**  
   Demonstrates the use of events to track changes inside a backpack object.  
   **Includes:**  
   - Classes:  
     - `Backpack` — stores backpack properties and the list of items  
     - `BackpackItem` — stores item name and volume  
   - Events:  
     - `ObjectAdded` — triggered when an item is added  
     - `ObjectRemoved` — triggered when an item is removed  
     - `ObjectChanged` — triggered when an item's volume is updated  
   - Methods:  
     - `AddObject(name, volume)` — adds an item and checks capacity  
     - `RemoveObject(name)` — removes an item  
     - `ChangeObject(name, newVolume)` — updates item volume with capacity validation  
   - Demonstrated in the program:  
     - Anonymous delegates subscribed to events  
     - Error handling (`InvalidOperationException`, `ArgumentException`)  
     - A simple event-driven notification system

2. **Count Multiples**  
   Uses a `Func<int[], int, int>` delegate to count how many array elements are divisible by a given number.  
   **Features:**  
   - Anonymous delegate taking an array and divisor  
   - Simple loop-based multiple counting  
   - Sample output for divisors 7, 3, 5, and 10  
   - Good example of using built-in .NET delegates

3. **Rainbow Color Delegate**  
   Uses a custom `RainbowColorDelegate` to convert a rainbow color name into an RGB tuple.  
   **Features:**  
   - Delegate returning a tuple `(int R, int G, int B)`  
   - Anonymous method with a `switch` expression  
   - Prints RGB values for all rainbow colors  
   - Illustrates delegates and tuple usage in C#

---

## Format

Each task is implemented as a **separate C# console application**.
