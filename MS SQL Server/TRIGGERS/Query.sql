CREATE DATABASE Sports_shop;

USE Sports_shop;


CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    ProductType NVARCHAR(50) NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity >= 0),
    CostPrice MONEY NOT NULL,
    Manufacturer NVARCHAR(100) NOT NULL,
    SalePrice MONEY NOT NULL
);

CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(150) NOT NULL,
    Position NVARCHAR(50) NOT NULL,
    HireDate DATE NOT NULL,
    Gender NVARCHAR(10),
    Salary MONEY NOT NULL
);

CREATE TABLE Clients (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(150) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Gender NVARCHAR(10),
    TotalPurchases MONEY DEFAULT 0,
    Discount INT DEFAULT 0,
    IsSubscribed BIT NOT NULL
);

CREATE TABLE Sales (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    EmployeeId INT NOT NULL,
    ClientId INT NULL,
    Quantity INT NOT NULL,
    SalePrice MONEY NOT NULL,
    SaleDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);

CREATE TABLE SalesHistory (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100),
    Quantity INT,
    SalePrice MONEY,
    SaleDate DATETIME,
    EmployeeName NVARCHAR(150),
    ClientName NVARCHAR(150)
);

CREATE TABLE ProductsArchive (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    ProductType NVARCHAR(50),
    Manufacturer NVARCHAR(100),
    ArchiveDate DATETIME
);

CREATE TABLE LastUnit (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100),
    FixDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE EmployeesArchive (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(150),
    Position NVARCHAR(50),
    HireDate DATE,
    FireDate DATE
);


CREATE TRIGGER trg_SalesHistory
ON Sales
AFTER INSERT
AS
INSERT INTO SalesHistory
SELECT
    p.Name,
    i.Quantity,
    i.SalePrice,
    i.SaleDate,
    e.FullName,
    c.FullName
FROM inserted i
JOIN Products p ON p.Id = i.ProductId
JOIN Employees e ON e.Id = i.EmployeeId
LEFT JOIN Clients c ON c.Id = i.ClientId;

CREATE TRIGGER trg_ProductArchive
ON Products
AFTER UPDATE
AS
INSERT INTO ProductsArchive
SELECT Name, ProductType, Manufacturer, GETDATE()
FROM inserted
WHERE Quantity = 0;

CREATE TRIGGER trg_LastUnit
ON Products
AFTER UPDATE
AS
INSERT INTO LastUnit (ProductName)
SELECT Name
FROM inserted
WHERE Quantity = 1;


CREATE TRIGGER trg_NoDuplicateClients
ON Clients
INSTEAD OF INSERT
AS
IF EXISTS (
    SELECT 1
    FROM Clients c
    JOIN inserted i 
      ON c.FullName = i.FullName 
     AND c.Email = i.Email
)
BEGIN
    RAISERROR ('Client already exists',16,1);
    ROLLBACK;
END
ELSE
INSERT INTO Clients (FullName, Email, Phone, Gender, TotalPurchases, Discount, IsSubscribed)
SELECT FullName, Email, Phone, Gender, TotalPurchases, Discount, IsSubscribed
FROM inserted;

CREATE TRIGGER trg_NoDeleteClients
ON Clients
INSTEAD OF DELETE
AS
BEGIN
    RAISERROR ('Deleting clients forbidden',16,1);
    ROLLBACK;
END

CREATE TRIGGER trg_NoDeleteOldEmployees
ON Employees
INSTEAD OF DELETE
AS
IF EXISTS (SELECT 1 FROM deleted WHERE HireDate < '2015-01-01')
BEGIN
    RAISERROR ('Cannot delete old employees',16,1);
    ROLLBACK;
END
ELSE
DELETE FROM Employees WHERE Id IN (SELECT Id FROM deleted);

CREATE TRIGGER trg_ClientDiscount
ON Sales
AFTER INSERT
AS
UPDATE c
SET
    TotalPurchases += i.Quantity * i.SalePrice,
    Discount = CASE
        WHEN TotalPurchases + i.Quantity * i.SalePrice >= 50000 THEN 15
        ELSE Discount
    END
FROM Clients c
JOIN inserted i ON i.ClientId = c.Id;

CREATE TRIGGER trg_BlockManufacturer
ON Products
INSTEAD OF INSERT
AS
IF EXISTS (SELECT 1 FROM inserted WHERE Manufacturer = N'Sports, sun and barbell')
BEGIN
    RAISERROR ('Manufacturer forbidden',16,1);
    ROLLBACK;
END
ELSE
INSERT INTO Products (Name, ProductType, Quantity, CostPrice, Manufacturer, SalePrice)
SELECT Name, ProductType, Quantity, CostPrice, Manufacturer, SalePrice
FROM inserted;


CREATE TRIGGER trg_MergeProducts
ON Products
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM Products p
        JOIN inserted i 
          ON p.Name = i.Name
         AND p.ProductType = i.ProductType
         AND p.Manufacturer = i.Manufacturer
         AND p.SalePrice = i.SalePrice
    )
    BEGIN
        UPDATE p
        SET p.Quantity = p.Quantity + i.Quantity
        FROM Products p
        INNER JOIN inserted i 
          ON p.Name = i.Name
         AND p.ProductType = i.ProductType
         AND p.Manufacturer = i.Manufacturer
         AND p.SalePrice = i.SalePrice;
    END
    ELSE
    BEGIN
        INSERT INTO Products (Name, ProductType, Quantity, CostPrice, Manufacturer, SalePrice)
        SELECT Name, ProductType, Quantity, CostPrice, Manufacturer, SalePrice
        FROM inserted;
    END
END

CREATE TRIGGER trg_EmployeeArchive
ON Employees
AFTER DELETE
AS
INSERT INTO EmployeesArchive
SELECT FullName, Position, HireDate, GETDATE()
FROM deleted;

CREATE TRIGGER trg_MaxSellers
ON Employees
INSTEAD OF INSERT
AS
BEGIN
    IF (
        (SELECT COUNT(*) FROM Employees WHERE Position='Seller') +
        (SELECT COUNT(*) FROM inserted WHERE Position='Seller')
    ) > 6
    BEGIN
        RAISERROR('Too many sellers', 16, 1);
        ROLLBACK;
        RETURN;
    END
    INSERT INTO Employees (FullName, Position, HireDate, Gender, Salary)
    SELECT FullName, Position, HireDate, Gender, Salary
    FROM inserted;
END
