CREATE TABLE Employees (
EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
FirstName VARCHAR(100),
LastName VARCHAR(100),
ManagerID INT NULL,
FOREIGN KEY (ManagerID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE
)

INSERT INTO Employees (FirstName, LastName, ManagerID)
VALUES
('Jeffery', 'Wells', NULL)

INSERT INTO Employees (FirstName, LastName, ManagerID)
VALUES
('Victor', 'Atkins', 1),
('Kelli', 'Hamilton', 1)

INSERT INTO Employees (FirstName, LastName, ManagerID)
VALUES
('Adam', 'Braun', 2),
('Brian', 'Cruz', 2),
('Kristen', 'Floyd', 2)

INSERT INTO Employees (FirstName, LastName, ManagerID)
VALUES
('Lois', 'Martinez', 3),
('Michael', 'Lind', 3),
('Eric', 'Bay', 3),
('Brandon', 'Young', 3)

SELECT * FROM Employees


