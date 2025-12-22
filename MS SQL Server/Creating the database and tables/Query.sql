IF DB_ID('Hospital') IS NULL
	CREATE DATABASE Hospital;

USE Hospital;
	
IF OBJECT_ID('dbo.Departments', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Departments (
        ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Building INT NOT NULL,
        Financing MONEY NOT NULL DEFAULT 0,
        Name NVARCHAR(100) NOT NULL UNIQUE
    );
END;

IF OBJECT_ID('dbo.Diseases', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Diseases (
        ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL UNIQUE,
        Severity INT NOT NULL DEFAULT 1
    );
END;

IF OBJECT_ID('dbo.Doctors', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Doctors (
        ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(MAX) NOT NULL,
        Surname NVARCHAR(MAX) NOT NULL,
        Phone CHAR(10) NOT NULL,
        Salary MONEY NOT NULL
    );
END;

IF OBJECT_ID('dbo.Examinations', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Examinations (
        ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        DayOfWeek INT NOT NULL,
        StartTime TIME NOT NULL,
        EndTime TIME NOT NULL,
        Name NVARCHAR(100) NOT NULL UNIQUE
    );
END;
