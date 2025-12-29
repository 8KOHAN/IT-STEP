IF DB_ID('Academy') IS NULL
	CREATE DATABASE Academy;

USE Academy;

IF OBJECT_ID('dbo.Curators', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Curators (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(MAX) NOT NULL CHECK (Name <> ''),
        Surname NVARCHAR(MAX) NOT NULL CHECK (Surname <> '')
    );
END;

IF OBJECT_ID('dbo.Faculties', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Faculties (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Financing MONEY NOT NULL DEFAULT 0 CHECK (Financing >= 0),
        Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> '')
    );
END;

IF OBJECT_ID('dbo.Departments', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Departments (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Financing MONEY NOT NULL DEFAULT 0 CHECK (Financing >= 0),
        Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> ''),
        FacultyId INT NOT NULL,
        FOREIGN KEY (FacultyId) REFERENCES dbo.Faculties(Id)
    );
END;

IF OBJECT_ID('dbo.Groups', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Groups (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(10) NOT NULL UNIQUE CHECK (Name <> ''),
        [Year] INT NOT NULL CHECK ([Year] BETWEEN 1 AND 5),
        DepartmentId INT NOT NULL,
        FOREIGN KEY (DepartmentId) REFERENCES dbo.Departments(Id)
    );
END;

IF OBJECT_ID('dbo.Teachers', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Teachers (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(MAX) NOT NULL CHECK (Name <> ''),
        Surname NVARCHAR(MAX) NOT NULL CHECK (Surname <> ''),
        Salary MONEY NOT NULL CHECK (Salary > 0)
    );
END;

IF OBJECT_ID('dbo.Subjects', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Subjects (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> '')
    );
END;

IF OBJECT_ID('dbo.Lectures', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Lectures (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        LectureRoom NVARCHAR(MAX) NOT NULL CHECK (LectureRoom <> ''),
        SubjectId INT NOT NULL,
        TeacherId INT NOT NULL,
        FOREIGN KEY (SubjectId) REFERENCES dbo.Subjects(Id),
        FOREIGN KEY (TeacherId) REFERENCES dbo.Teachers(Id)
    );
END;

IF OBJECT_ID('dbo.GroupsCurators', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.GroupsCurators (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        CuratorId INT NOT NULL,
        GroupId INT NOT NULL,
        FOREIGN KEY (CuratorId) REFERENCES dbo.Curators(Id),
        FOREIGN KEY (GroupId) REFERENCES dbo.Groups(Id)
    );
END;

IF OBJECT_ID('dbo.GroupsLectures', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.GroupsLectures (
        Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        GroupId INT NOT NULL,
        LectureId INT NOT NULL,
        FOREIGN KEY (GroupId) REFERENCES dbo.Groups(Id),
        FOREIGN KEY (LectureId) REFERENCES dbo.Lectures(Id)
    );
END;

INSERT INTO dbo.Faculties (Financing, Name) VALUES
(80000, N'Faculty of Information Technologies'),
(60000, N'Faculty of Mathematics'),
(50000, N'Faculty of Physics');

INSERT INTO dbo.Departments (Financing, Name, FacultyId) VALUES
(30000, N'Computer Science', 1),
(25000, N'Software Engineering', 1),
(20000, N'Applied Mathematics', 2),
(18000, N'Theoretical Mathematics', 2),
(22000, N'Quantum Physics', 3);

INSERT INTO dbo.Groups (Name, [Year], DepartmentId) VALUES
(N'CS-101', 1, 1),
(N'CS-102', 1, 1),
(N'CS-201', 2, 1),
(N'SE-301', 3, 2),
(N'SE-401', 4, 2),
(N'MATH-101', 1, 3),
(N'MATH-201', 2, 4),
(N'PHYS-301', 3, 5);

INSERT INTO dbo.Curators (Name, Surname) VALUES
(N'Ivan', N'Ivanov'),
(N'Petr', N'Petrov'),
(N'Olga', N'Sidorova'),
(N'Anna', N'Kuznetsova');

INSERT INTO dbo.Teachers (Name, Surname, Salary) VALUES
(N'Alexey', N'Brown', 25000),
(N'Maria', N'Wilson', 30000),
(N'John', N'Smith', 28000),
(N'Elena', N'White', 32000),
(N'Dmitry', N'Black', 27000);

INSERT INTO dbo.Subjects (Name) VALUES
(N'Databases'),
(N'Algorithms'),
(N'Programming'),
(N'Linear Algebra'),
(N'Quantum Mechanics');

INSERT INTO dbo.Lectures (LectureRoom, SubjectId, TeacherId) VALUES
(N'Room 101', 1, 1),
(N'Room 102', 2, 2),
(N'Room 103', 3, 3),
(N'Room 201', 4, 4),
(N'Room 301', 5, 5);

INSERT INTO dbo.GroupsCurators (CuratorId, GroupId) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(3, 5),
(3, 6),
(4, 7),
(4, 8);

INSERT INTO dbo.GroupsLectures (GroupId, LectureId) VALUES
(1, 1),
(1, 3),
(2, 1),
(2, 2),
(3, 2),
(3, 3),
(4, 3),
(4, 4),
(5, 4),
(6, 4),
(7, 5),
(8, 5);


SELECT t.Surname AS TeacherSurname, g.Name AS GroupName
FROM Teachers t, Groups g;


SELECT Name
FROM Faculties f
WHERE (
    SELECT SUM(Financing)
    FROM Departments
    WHERE FacultyId = f.Id
) > f.Financing;


SELECT
    (SELECT Surname FROM Curators c WHERE c.Id = gc.CuratorId) AS CuratorSurname,
    (SELECT Name FROM Groups g WHERE g.Id = gc.GroupId) AS GroupName
FROM GroupsCurators gc;


SELECT Surname
FROM Teachers
WHERE Id IN (
    SELECT TeacherId
    FROM Lectures
    WHERE Id IN (
        SELECT LectureId
        FROM GroupsLectures
        WHERE GroupId = (
            SELECT Id FROM Groups WHERE Name = 'P107'
        )
    )
)
GROUP BY Surname;


SELECT
    t.Surname,
    (SELECT Name FROM Faculties f
     WHERE f.Id = d.FacultyId) AS FacultyName
FROM Teachers t, Departments d
WHERE d.Id IN (
    SELECT DepartmentId
    FROM Groups
    WHERE Id IN (
        SELECT GroupId
        FROM GroupsLectures
        WHERE LectureId IN (
            SELECT Id FROM Lectures
            WHERE TeacherId = t.Id
        )
    )
)
GROUP BY t.Surname, d.FacultyId;


SELECT
    (SELECT Name FROM Departments d WHERE d.Id = g.DepartmentId) AS DepartmentName,
    g.Name AS GroupName
FROM Groups g;


SELECT Name
FROM Subjects
WHERE Id IN (
    SELECT SubjectId
    FROM Lectures
    WHERE TeacherId = (
        SELECT Id FROM Teachers
        WHERE Name = 'Samantha' AND Surname = 'Adams'
    )
)
GROUP BY Name;


SELECT Name
FROM Departments
WHERE Id IN (
    SELECT DepartmentId
    FROM Groups
    WHERE Id IN (
        SELECT GroupId
        FROM GroupsLectures
        WHERE LectureId IN (
            SELECT Id FROM Lectures
            WHERE SubjectId = (
                SELECT Id FROM Subjects
                WHERE Name = 'Quantum Physics'
            )
        )
    )
)
GROUP BY Name;


SELECT Name
FROM Groups
WHERE DepartmentId IN (
    SELECT Id
    FROM Departments
    WHERE FacultyId = (
        SELECT Id FROM Faculties
        WHERE Name = 'Computer Science'
    )
)
GROUP BY Name;


SELECT
    g.Name AS GroupName,
    (SELECT Name FROM Faculties f
     WHERE f.Id = (
         SELECT FacultyId FROM Departments d
         WHERE d.Id = g.DepartmentId
     )) AS FacultyName
FROM Groups g
WHERE g.[Year] = 5
GROUP BY g.Name, g.DepartmentId;


SELECT
    (SELECT Surname FROM Teachers t WHERE t.Id = l.TeacherId) AS TeacherSurname,
    (SELECT Name FROM Subjects s WHERE s.Id = l.SubjectId) AS SubjectName,
    (SELECT Name FROM Groups g
     WHERE g.Id IN (
         SELECT GroupId
         FROM GroupsLectures
         WHERE LectureId = l.Id
     )) AS GroupName
FROM Lectures l
WHERE l.LectureRoom = 'B103'
GROUP BY l.TeacherId, l.SubjectId, l.Id;
