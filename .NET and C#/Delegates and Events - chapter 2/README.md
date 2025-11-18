# Delegates & Events — Chapter 2

A collection of C# console applications designed to practice **Action, Func, Predicate delegates** as well as **custom events** using more advanced object behavior.

---

## Contents

1. **Action, Predicate, Func Demo**  
   Demonstrates the use of built-in delegates for simple calculations and system information output.  
   **Includes:**  
   - `Action` delegates:  
     - `showTime` — prints current time  
     - `showDate` — prints current date  
     - `showDayOfWeek` — prints current day of the week  
   - `Func<double, double, double>` delegates:  
     - `triangleArea` — calculates triangle area  
     - `rectangleArea` — calculates rectangle area  
   - `Predicate<double>`:  
     - `isLargeArea` — checks if area is greater than 50  
   **Demonstrates:**  
   - Use of lambda expressions  
   - Inline computations with delegates  

2. **Credit Card**  
   Demonstrates an advanced event-driven model using a `CreditCard` class with multiple financial actions.  
   **Includes:**  
   - Properties:  
     - Card number, owner name, expiration date  
     - PIN with automatic event notification on update  
     - Credit limit and current balance  
   - Events:  
     - `MoneyAdded` — triggered when money is added  
     - `MoneySpent` — triggered when money is spent  
     - `CreditStarted` — triggered when balance becomes negative for the first time  
     - `TargetBalanceReached` — triggered when a specified target balance is reached  
     - `PinChanged` — triggered whenever the card’s PIN is updated  
   - Methods:  
     - `AddMoney(amount, targetBalance)` — adds funds and checks for target  
     - `SpendMoney(amount)` — spends money and checks credit limit  
   **Demonstrates:**  
   - Event-driven programming  
   - Anonymous event handlers  
   - Error handling (`InvalidOperationException`)  
   - Property-triggered events (`PIN` setter)

---

## Format

Each task is implemented as a **separate C# console application**.
