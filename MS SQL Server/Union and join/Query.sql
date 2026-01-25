CREATE DATABASE Academy;

USE Academy;

CREATE TABLE Teachers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL CHECK (Name <> ''),
    Surname NVARCHAR(MAX) NOT NULL CHECK (Surname <> '')
);

CREATE TABLE Assistants (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TeacherId INT NOT NULL,
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
);

CREATE TABLE Curators (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TeacherId INT NOT NULL,
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
);

CREATE TABLE Deans (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TeacherId INT NOT NULL,
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
);

CREATE TABLE Heads (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TeacherId INT NOT NULL,
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
);

CREATE TABLE Faculties (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> ''),
    DeanId INT NOT NULL,
    FOREIGN KEY (DeanId) REFERENCES Deans(Id)
);

CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> ''),
    FacultyId INT NOT NULL,
    HeadId INT NOT NULL,
    FOREIGN KEY (FacultyId) REFERENCES Faculties(Id),
    FOREIGN KEY (HeadId) REFERENCES Heads(Id)
);

CREATE TABLE Groups (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(10) NOT NULL UNIQUE CHECK (Name <> ''),
    Year INT NOT NULL CHECK (Year BETWEEN 1 AND 5),
    DepartmentId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

CREATE TABLE GroupsCurators (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CuratorId INT NOT NULL,
    GroupId INT NOT NULL,
    FOREIGN KEY (CuratorId) REFERENCES Curators(Id),
    FOREIGN KEY (GroupId) REFERENCES Groups(Id)
);

CREATE TABLE Subjects (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE CHECK (Name <> '')
);

CREATE TABLE Lectures (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    SubjectId INT NOT NULL,
    TeacherId INT NOT NULL,
    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
);

CREATE TABLE GroupsLectures (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    GroupId INT NOT NULL,
    LectureId INT NOT NULL,
    FOREIGN KEY (GroupId) REFERENCES Groups(Id),
    FOREIGN KEY (LectureId) REFERENCES Lectures(Id)
);

CREATE TABLE LectureRooms (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 6),
    Name NVARCHAR(10) NOT NULL UNIQUE CHECK (Name <> '')
);

CREATE TABLE Schedules (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Class INT NOT NULL CHECK (Class BETWEEN 1 AND 8),
    DayOfWeek INT NOT NULL CHECK (DayOfWeek BETWEEN 1 AND 7),
    Week INT NOT NULL CHECK (Week BETWEEN 1 AND 52),
    LectureId INT NOT NULL,
    LectureRoomId INT NOT NULL,
    FOREIGN KEY (LectureId) REFERENCES Lectures(Id),
    FOREIGN KEY (LectureRoomId) REFERENCES LectureRooms(Id)
);


INSERT INTO Teachers (Name, Surname) VALUES
('Edward', 'Hopper'),
('Alex', 'Carmack'),
('John', 'Smith'),
('Alice', 'Brown'),
('Bob', 'White');

INSERT INTO Assistants (TeacherId) VALUES (3);
INSERT INTO Curators (TeacherId) VALUES (4);
INSERT INTO Deans (TeacherId) VALUES (1);
INSERT INTO Heads (TeacherId) VALUES (2);

INSERT INTO Faculties (Building, Name, DeanId)
VALUES (1, 'Computer Science', 1);

INSERT INTO Departments (Building, Name, FacultyId, HeadId)
VALUES (2, 'Software Development', 1, 1);

INSERT INTO Groups (Name, Year, DepartmentId)
VALUES ('F505', 5, 1);

INSERT INTO GroupsCurators (CuratorId, GroupId)
VALUES (1, 1);

INSERT INTO Subjects (Name) VALUES
('Databases'),
('Operating Systems');

INSERT INTO Lectures (SubjectId, TeacherId) VALUES
(1, 1),
(2, 2),
(1, 3);

INSERT INTO GroupsLectures (GroupId, LectureId) VALUES
(1, 1),
(1, 2),
(1, 3);

INSERT INTO LectureRooms (Building, Name) VALUES
(6, 'A311'),
(6, 'A104'),
(2, 'B201');

INSERT INTO Schedules (Class, DayOfWeek, Week, LectureId, LectureRoomId) VALUES
(3, 3, 2, 1, 1),
(1, 1, 1, 2, 2),
(2, 2, 1, 3, 3);


SELECT DISTINCT lr.Name
FROM Teachers t
JOIN Lectures l ON l.TeacherId = t.Id
JOIN Schedules s ON s.LectureId = l.Id
JOIN LectureRooms lr ON lr.Id = s.LectureRoomId
WHERE t.Name = 'Edward' AND t.Surname = 'Hopper';

SELECT DISTINCT t.Surname
FROM Assistants a
JOIN Teachers t ON t.Id = a.TeacherId
JOIN Lectures l ON l.TeacherId = t.Id
JOIN GroupsLectures gl ON gl.LectureId = l.Id
JOIN Groups g ON g.Id = gl.GroupId
WHERE g.Name = 'F505';

SELECT DISTINCT s.Name
FROM Teachers t
JOIN Lectures l ON l.TeacherId = t.Id
JOIN Subjects s ON s.Id = l.SubjectId
JOIN GroupsLectures gl ON gl.LectureId = l.Id
JOIN Groups g ON g.Id = gl.GroupId
WHERE t.Name = 'Alex'
  AND t.Surname = 'Carmack'
  AND g.Year = 5;

SELECT DISTINCT t.Surname
FROM Teachers t
WHERE t.Id NOT IN (
    SELECT l.TeacherId
    FROM Lectures l
    JOIN Schedules s ON s.LectureId = l.Id
    WHERE s.DayOfWeek = 1
);

SELECT lr.Name, lr.Building
FROM LectureRooms lr
WHERE lr.Id NOT IN (
    SELECT LectureRoomId
    FROM Schedules
    WHERE DayOfWeek = 3 AND Week = 2 AND Class = 3
);

SELECT DISTINCT t.Name, t.Surname
FROM Teachers t
JOIN Deans d ON d.TeacherId = t.Id
JOIN Faculties f ON f.DeanId = d.Id
WHERE f.Name = 'Computer Science'
AND t.Id NOT IN (
    SELECT c.TeacherId
    FROM Curators c
    JOIN GroupsCurators gc ON gc.CuratorId = c.Id
    JOIN Groups g ON g.Id = gc.GroupId
    JOIN Departments dep ON dep.Id = g.DepartmentId
    WHERE dep.Name = 'Software Development'
);

SELECT Building FROM Faculties
UNION
SELECT Building FROM Departments
UNION
SELECT Building FROM LectureRooms;

SELECT t.Name, t.Surname, 'Dean' AS Role FROM Deans d JOIN Teachers t ON t.Id = d.TeacherId
UNION ALL
SELECT t.Name, t.Surname, 'Head' FROM Heads h JOIN Teachers t ON t.Id = h.TeacherId
UNION ALL
SELECT t.Name, t.Surname, 'Teacher' FROM Teachers t
UNION ALL
SELECT t.Name, t.Surname, 'Curator' FROM Curators c JOIN Teachers t ON t.Id = c.TeacherId
UNION ALL
SELECT t.Name, t.Surname, 'Assistant' FROM Assistants a JOIN Teachers t ON t.Id = a.TeacherId;

SELECT DISTINCT s.DayOfWeek
FROM Schedules s
JOIN LectureRooms lr ON lr.Id = s.LectureRoomId
WHERE lr.Building = 6
  AND lr.Name IN ('A311', 'A104');
