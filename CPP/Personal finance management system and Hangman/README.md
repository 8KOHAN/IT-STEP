# Personal Finance Management System and Hangman

This console-based C++ application allows users to manage their personal finances and enjoy a game as a reward.  
You can create wallets, manage debit and credit cards, track expenses, and view detailed spending statistics.  

The system supports multiple currencies — Hryvnia (₴), Dollar ($), and Euro (€) — and automatically converts prices according to the current exchange rate used in the program.  

All statistics, including a full spending history and top three purchases by day, week, and month, can be viewed directly in the console and are also automatically saved to files for future reference.  

A virtual shop lets you purchase various items — and if you buy a PS5, the classic Hangman game becomes available to play.  
The Hangman word list is securely stored in an encrypted text file, with each word encoded using a simple ASCII shift for additional protection.  

This project was developed as a coursework project at IT STEP Academy and demonstrates object-oriented programming, file handling, and modular C++ design.

---

## Features

- Wallet and card management (debit and credit)
- Multiple currency support (₴, $, €) with exchange rate conversion  
- Expense tracking and detailed spending history  
- Daily, weekly, and monthly top 3 purchase statistics  
- Data persistence through text files  
- Integrated virtual shop system  
- Hidden Hangman game unlocked by purchasing a PS5  
- Encrypted Hangman word list using ASCII shift encryption  

---

## Structure

```bash
|── Personal finance management system and Hangman/
├── Header Files/
│ ├── Hangman/
│ │ ├── Hangman.h
│ │ ├── Player.h
│ │ └── WordManager.h
│ ├── CardCredit.h
│ ├── CardDebit.h
│ ├── ClearScreen.h
│ ├── Expense.h
│ ├── ExpenseTracker.h
│ ├── Functions.h
│ ├── Products.h
│ ├── Purse.h
│ └── Shop.h
│
├── Source Files/
│ ├── Hangman/
│ │ ├── Hangman.cpp
│ │ ├── Player.cpp
│ │ └── WordManager.cpp
│ ├── CardCredit.cpp
│ ├── CardDebit.cpp
│ ├── ClearScreen.cpp
│ ├── Expense.cpp
│ ├── ExpenseTracker.cpp
│ ├── Functions.cpp
│ ├── Purse.cpp
│ ├── Shop.cpp
│ ├── main.cpp
│ └── Hangman.txt
│
└── README.md
```
