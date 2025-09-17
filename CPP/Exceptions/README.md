# C++ Exceptions Project

This project demonstrates **exception handling in C++** using custom exceptions, standard exceptions, and file logging.  

## Features
- **String to Integer Conversion** (`toInt`)  
  Converts a string into an integer and throws an exception if extra characters are found.  

- **Error Logging** (`process`)  
  Throws a runtime error, catches it, and logs the error into a file (`error_log.txt`).  

- **Password Validation** (`checkPassword`)  
  Ensures the password is at least 8 characters long and contains at least one digit.  

- **Age Verification** (`ageVerification`)  
  Uses a custom `AgeException` class to handle invalid ages:  
  - Negative values  
  - Under 18 (minor)  
  - Over 150 (unrealistic)  
