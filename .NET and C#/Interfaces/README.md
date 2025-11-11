# Remote Control & Validator Projects

A small collection of educational console programs designed to practice key C# concepts — **interfaces, classes, and basic data validation**.

---

## Contents

1. **Remote Control**  
   Implements the `IRemoteControl` interface for controlling different devices.  
   **Features:**  
   - Defines `IRemoteControl` interface with methods:  
     - `TurnOn()` — turns the device on  
     - `TurnOff()` — turns the device off  
     - `SetChannel(int channel)` — sets the device channel  
   - Provides concrete implementations for:  
     - `TvRemoteControl` — controls a TV  
     - `RadioRemoteControl` — controls a radio  
   - Demonstrates **interface implementation** and polymorphism  

2. **Validator**  
   Implements the `IValidator` interface for validating data.  
   **Features:**  
   - Defines `IValidator` interface with method:  
     - `Validate()` — checks if data is valid  
   - Provides concrete implementations for:  
     - `EmailValidator` — checks if an email contains `@` and `.`  
     - `PasswordValidator` — checks if a password meets simple rules (e.g., minimum length, contains a digit)  
   - Demonstrates **interface-based design** and basic validation logic  

---

## Format

Each task is implemented as a **separate console application in C#**.
