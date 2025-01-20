CREATE TABLE Roles (
RoleID INT Identity(1,1) PRIMARY KEY,
RoleName VARCHAR(100) NOT NULL UNIQUE
)

INSERT INTO Roles(RoleName)
VALUES
('Director'),
('IT'),
('Support'),
('Accounting'),
('Analyst'),
('Sales')

SELECT * FROM Roles
