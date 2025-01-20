
CREATE TABLE EmployeeRoles (
EmployeeRoleID INT IDENTITY(1,1) PRIMARY KEY,
EmployeeID INT,
RoleID INT,
FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE,
FOREIGN KEY (RoleID) REFERENCES Roles(RoleID) ON DELETE CASCADE,
)

INSERT INTO EmployeeRoles (EmployeeID, RoleID)
VALUES
(1,1),
(2,1),
(3,1),
(4,2),
(4,3),
(5,4),
(6,5),
(6,6),
(7,3),
(8,5),
(9,2),
(9,6),
(10,4)

SELECT * FROM EmployeeRoles