# LINQ

A small C# console project demonstrating the use of **LINQ**, object collections, and nested data structures.  
The project includes classes for **Firm**, **Employee**, and a main program with multiple LINQ queries.

---

## Contents

1. **Employee.cs** – represents an employee.
2. **Firm.cs** – represents a company with a list of employees.
3. **Program.cs** – contains LINQ queries for filtering firms and employees.

---

## Employee

File: `Firm/Employee.cs`

Stores basic employee information:

- `FullName`
- `Position`
- `Phone`
- `Email`
- `Salary`

The class includes a formatted `ToString()` method.

---

## Firm

File: `Firm/Firm.cs`

Represents a company with:

- `Name`
- `Founded`
- `BusinessProfile`
- `DirectorFullName`
- `Employees` (count)
- `Address`
- `EmployeesList` (`List<Employee>`)

Includes a formatted `ToString()` method.

---

## Program — LINQ Queries

File: `Firm/Program.cs`

### Firm Queries
- All firms  
- Firms containing `"Food"`  
- Firms in **Marketing**  
- Firms in **Marketing** or **IT**  
- Firms with **>100 employees**  
- Firms with **100–300 employees**  
- Firms located in **London**  
- Firms with director `"White"`  
- Firms founded **over 2 years ago**  
- Firms founded **123+ days ago**  
- Firms where director is **Black** and name contains `"White"`  

---

### Employee Queries
- Employees of **Global Food Corp**  
- Employees with salary **> 3000**  
- All **Managers** across firms  
- Employees whose phone starts with `"23"`  
- Employees whose email starts with `"di"`  
- Employees whose first name is **Lionel**
