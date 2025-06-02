# Student Group Management System

## Project Description

This is a simple console-based C++ application designed to manage student information within a single academic group. It provides basic functionalities to add new students, remove existing students, and display details of all students in the group. The system utilizes dynamic memory allocation to handle a variable number of students.

## Features

* **Add Student:** Allows users to input a student's name, age, and university, and add them to the group.
* **Delete Student:** Enables users to remove a student from the group by providing their index.
* **Display Student Information:** Shows a list of all students currently in the group, along with their assigned index, name, age, and university.
* **Dynamic Group Size:** The group can dynamically grow and shrink to accommodate changes in the number of students.

## How to Build and Run

To compile and run this project, you will need a C++ compiler (e.g., g++ or Visual C++).

1.  **Save the files:**
    * Create three files: `main.cpp`, `Group.cpp`, and `Group.h`.
    * Copy the respective code blocks provided below into these files.

2.  **Compile (Example using g++):**
    Open your terminal or command prompt, navigate to the directory where you saved the files, and run the following command:

    ```bash
    g++ main.cpp Group.cpp -o student_group_manager
    ```

    *If you are using Visual Studio, you would typically add these files to a new C++ console project and build the solution.*

3.  **Run the executable:**
    After successful compilation, execute the program:

    ```bash
    ./student_group_manager
    ```

    (On Windows, it might be `student_group_manager.exe`)

## Usage

Once the program is running, a menu will be displayed:
