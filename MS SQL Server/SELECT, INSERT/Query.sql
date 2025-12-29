IF DB_ID('Academy') IS NULL
	CREATE DATABASE Academy;

USE Academy;

IF OBJECT_ID('dbo.Departments', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Departments (
        ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Financing MONEY NOT NULL DEFAULT 0 CHECK (Financing > 0),
        [Name] NVARCHAR(100) NOT NULL UNIQUE
    );
END;

IF OBJECT_ID('dbo.Faculties', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Faculties (
        ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Dean NVARCHAR(MAX) NOT NULL CHECK (Dean <> ''),
        [Name] NVARCHAR(100) NOT NULL CHECK ([Name] <> '')
    );
END;

IF OBJECT_ID('dbo.Groups', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Groups (
        ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Rating INT NOT NULL CHECK (Rating >= 0 AND Rating <= 5),
        [Year] INT NOT NULL CHECK ([Year] >= 1 AND [Year] <= 5),
        [Name] NVARCHAR(100) NOT NULL UNIQUE CHECK ([Name] <> '') 
    );
END;

IF OBJECT_ID('dbo.Teachers', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Teachers (
        ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        EmploymentDate DATE NOT NULL CHECK (EmploymentDate > '1990-01-01'),
        IsAssistant BIT NOT NULL DEFAULT 0,
        IsProfessor BIT NOT NULL DEFAULT 0,
        Name NVARCHAR(MAX) NOT NULL CHECK ([Name] <> ''),
        Position NVARCHAR(MAX) NOT NULL CHECK (Position <> ''),
        Premium MONEY NOT NULL CHECK (Premium >= 0) DEFAULT 0,
        Salary MONEY NOT NULL CHECK (Salary > 0),
        Surname NVARCHAR(MAX) NOT NULL CHECK (Surname <> '')
    );
END;


INSERT INTO dbo.Departments (Financing, [Name]) VALUES
(10000, N'Mathematics'),
(15000, N'Physics'),
(20000, N'Computer Science');

INSERT INTO dbo.Faculties (Dean, [Name]) VALUES
(N'John Smith', N'Faculty of Natural Sciences'),
(N'Robert Johnson', N'Faculty of Information Technologies');

INSERT INTO dbo.Groups (Rating, [Year], [Name]) VALUES
(4, 1, N'CS-101'),
(5, 2, N'CS-201'),
(3, 3, N'MATH-301');

INSERT INTO dbo.Teachers
(EmploymentDate, IsAssistant, IsProfessor, Name, Position, Premium, Salary, Surname)
VALUES
('2005-09-01', 1, 0, N'Alexander', N'Assistant', 2000, 15000, N'Brown'),
('1998-02-15', 0, 1, N'Mary', N'Professor', 5000, 30000, N'Wilson'),
('2012-11-10', 0, 0, N'Andrew', N'Lecturer', 0, 18000, N'Taylor');


SELECT [Name], Financing, ID 
FROM dbo.Departments

SELECT Year AS 'Group year', Name AS 'Group name'
FROM dbo.Groups

SELECT
    Surname,
    Salary * 100.0 / Premium AS SalaryToPremiumPercent,
    Salary * 100.0 / (Salary + Premium) AS SalaryToTotalPercent
FROM dbo.Teachers
WHERE Premium > 0;

SELECT 
    'The dean of faculty ' + [Name] + ' is ' + Dean + '.' AS FacultyInfo
FROM dbo.Faculties

SELECT Surname
FROM dbo.Teachers
WHERE IsProfessor = 1 AND Salary > 1050;

SELECT [Name]
FROM dbo.Departments
WHERE Financing < 11000 OR Financing > 25000;

SELECT [Name]
FROM dbo.Faculties
WHERE [Name] <> 'Computer Science';

SELECT Surname, Position
FROM dbo.Teachers
WHERE IsProfessor = 0;

SELECT Surname, Position, Salary, Premium
FROM dbo.Teachers
WHERE IsAssistant = 1
  AND Premium BETWEEN 160 AND 550;

SELECT Surname, Salary
FROM dbo.Teachers
WHERE IsAssistant = 1;

SELECT Surname, Position
FROM dbo.Teachers
WHERE EmploymentDate < '2000-01-01';

SELECT [Name] AS [Name of Department]
FROM dbo.Departments
WHERE [Name] < 'Software Development';

SELECT Surname
FROM dbo.Teachers
WHERE IsAssistant = 1 AND (Salary + Premium) <= 1200;

SELECT [Name]
FROM dbo.Groups
WHERE [Year] = 5 AND Rating BETWEEN 2 AND 4;

SELECT Surname
FROM dbo.Teachers
WHERE IsAssistant = 1 AND (Salary < 550 OR Premium < 200);
