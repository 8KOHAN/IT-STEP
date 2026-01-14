CREATE DATABASE Academy;

USE Academy;


CREATE TABLE Faculties (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    CONSTRAINT CK_Faculties_Name_NotEmpty CHECK (Name <> '')
);

CREATE TABLE Departments (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Financing MONEY NOT NULL CONSTRAINT DF_Departments_Financing DEFAULT 0,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    FacultyId INT NOT NULL,
    CONSTRAINT CK_Departments_Financing CHECK (Financing >= 0),
    CONSTRAINT CK_Departments_Name_NotEmpty CHECK (Name <> ''),
    CONSTRAINT FK_Departments_Faculties FOREIGN KEY (FacultyId)
        REFERENCES Faculties(Id)
);

CREATE TABLE Groups (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(10) NOT NULL UNIQUE,
    Year INT NOT NULL,
    DepartmentId INT NOT NULL,
    CONSTRAINT CK_Groups_Name_NotEmpty CHECK (Name <> ''),
    CONSTRAINT CK_Groups_Year CHECK (Year BETWEEN 1 AND 5),
    CONSTRAINT FK_Groups_Departments FOREIGN KEY (DepartmentId)
        REFERENCES Departments(Id)
);

CREATE TABLE Subjects (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    CONSTRAINT CK_Subjects_Name_NotEmpty CHECK (Name <> '')
);

CREATE TABLE Teachers (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Surname NVARCHAR(MAX) NOT NULL,
    Salary MONEY NOT NULL,
    CONSTRAINT CK_Teachers_Name_NotEmpty CHECK (Name <> ''),
    CONSTRAINT CK_Teachers_Surname_NotEmpty CHECK (Surname <> ''),
    CONSTRAINT CK_Teachers_Salary CHECK (Salary > 0)
);

CREATE TABLE Lectures (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    DayOfWeek INT NOT NULL,
    LectureRoom NVARCHAR(MAX) NOT NULL,
    SubjectId INT NOT NULL,
    TeacherId INT NOT NULL,
    CONSTRAINT CK_Lectures_DayOfWeek CHECK (DayOfWeek BETWEEN 1 AND 7),
    CONSTRAINT CK_Lectures_LectureRoom_NotEmpty CHECK (LectureRoom <> ''),
    CONSTRAINT FK_Lectures_Subjects FOREIGN KEY (SubjectId)
        REFERENCES Subjects(Id),
    CONSTRAINT FK_Lectures_Teachers FOREIGN KEY (TeacherId)
        REFERENCES Teachers(Id)
);

CREATE TABLE GroupsLectures (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    GroupId INT NOT NULL,
    LectureId INT NOT NULL,
    CONSTRAINT FK_GroupsLectures_Groups FOREIGN KEY (GroupId)
        REFERENCES Groups(Id),
    CONSTRAINT FK_GroupsLectures_Lectures FOREIGN KEY (LectureId)
        REFERENCES Lectures(Id)
);


INSERT INTO Faculties (Name)
VALUES ('Computer Science'), ('Engineering');

INSERT INTO Departments (Name, Financing, FacultyId)
VALUES 
('Software Development', 50000, 1),
('Computer Systems', 40000, 1),
('Mechanical Engineering', 30000, 2);

INSERT INTO Groups (Name, Year, DepartmentId)
VALUES 
('CS-101', 1, 1),
('CS-201', 2, 1),
('CS-301', 3, 2);

INSERT INTO Subjects (Name)
VALUES 
('Databases'),
('Algorithms'),
('Operating Systems'),
('Programming');

INSERT INTO Teachers (Name, Surname, Salary)
VALUES
('Dave', 'McQueen', 3500),
('Jack', 'Underhill', 4000),
('Anna', 'Smith', 3000);

INSERT INTO Lectures (DayOfWeek, LectureRoom, SubjectId, TeacherId)
VALUES
(1, 'D201', 1, 1),
(2, 'D201', 2, 1),
(3, 'A101', 3, 2),
(4, 'A101', 1, 2),
(5, 'B303', 4, 3);

INSERT INTO GroupsLectures (GroupId, LectureId)
VALUES
(1,1),(2,1),(1,2),(3,3),(2,4),(1,5),(2,5);


SELECT COUNT(DISTINCT Id)
FROM Teachers
WHERE Id IN (
    SELECT TeacherId
    FROM Lectures
    WHERE Id IN (
        SELECT LectureId
        FROM GroupsLectures
        WHERE GroupId IN (
            SELECT Id
            FROM Groups
            WHERE DepartmentId = (
                SELECT Id
                FROM Departments
                WHERE Name = 'Software Development'
            )
        )
    )
);

SELECT COUNT(*)
FROM Lectures
WHERE TeacherId = (
    SELECT Id
    FROM Teachers
    WHERE Name = 'Dave' AND Surname = 'McQueen'
);

SELECT COUNT(*)
FROM Lectures
WHERE LectureRoom = 'D201';

SELECT LectureRoom,
       (SELECT COUNT(*)
        FROM Lectures l2
        WHERE l2.LectureRoom = l1.LectureRoom) AS LecturesCount
FROM Lectures l1
GROUP BY LectureRoom;

SELECT COUNT(DISTINCT GroupId)
FROM GroupsLectures
WHERE LectureId IN (
    SELECT Id
    FROM Lectures
    WHERE TeacherId = (
        SELECT Id
        FROM Teachers
        WHERE Name = 'Jack' AND Surname = 'Underhill'
    )
);

SELECT AVG(Salary)
FROM Teachers
WHERE Id IN (
    SELECT TeacherId
    FROM Lectures
    WHERE Id IN (
        SELECT LectureId
        FROM GroupsLectures
        WHERE GroupId IN (
            SELECT Id
            FROM Groups
            WHERE DepartmentId IN (
                SELECT Id
                FROM Departments
                WHERE FacultyId = (
                    SELECT Id
                    FROM Faculties
                    WHERE Name = 'Computer Science'
                )
            )
        )
    )
);

SELECT AVG(Financing)
FROM Departments;

SELECT 
    Name + ' ' + Surname AS FullName,
    (
        SELECT COUNT(DISTINCT SubjectId)
        FROM Lectures
        WHERE TeacherId = Teachers.Id
    ) AS SubjectsCount
FROM Teachers;

SELECT DayOfWeek,
       COUNT(*) AS LecturesCount
FROM Lectures
GROUP BY DayOfWeek
ORDER BY DayOfWeek;

SELECT 
    LectureRoom,
    (
        SELECT COUNT(DISTINCT DepartmentId)
        FROM Groups
        WHERE Id IN (
            SELECT GroupId
            FROM GroupsLectures
            WHERE LectureId IN (
                SELECT Id
                FROM Lectures l2
                WHERE l2.LectureRoom = l1.LectureRoom
            )
        )
    ) AS DepartmentsCount
FROM Lectures l1
GROUP BY LectureRoom;

SELECT Name,
(
    SELECT COUNT(DISTINCT SubjectId)
    FROM Lectures
    WHERE Id IN (
        SELECT LectureId
        FROM GroupsLectures
        WHERE GroupId IN (
            SELECT Id
            FROM Groups
            WHERE DepartmentId IN (
                SELECT Id
                FROM Departments
                WHERE FacultyId = Faculties.Id
            )
        )
    )
) AS SubjectsCount
FROM Faculties;

SELECT 
    (SELECT Name + ' ' + Surname
     FROM Teachers
     WHERE Id = l.TeacherId) AS Teacher,
    LectureRoom,
    COUNT(*) AS LecturesCount
FROM Lectures l
GROUP BY TeacherId, LectureRoom;
