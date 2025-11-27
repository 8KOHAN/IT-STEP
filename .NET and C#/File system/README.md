# Poem Collection App

A simple educational C# console application demonstrating **working with files**, **collections**, **string parsing**, and **basic CRUD operations**.  
The project allows you to store, edit, search, and manage a collection of poems saved in a text file.

---

## Features

### **1. Add Poems**
- Enter title, author, year, theme, and multiline text.
- Automatically stored in memory and can be saved to a file.

### **2. Remove Poems**
- Remove a poem using its title (case-insensitive).

### **3. Update Poems**
- Edit an existing poem by replacing all its fields.

### **4. Search Poems**
- Search by:
  - title  
  - author  
  - theme  
  - poem text  
- Case-insensitive substring search.

### **5. Show All Poems**
- Displays all poems with formatted output.

### **6. Save / Load Collection**
- Saves all poems to `poems.txt`.
- Loads poems from the file when the application starts.
- Poems are stored using a custom text format with `|` separators.
