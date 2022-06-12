--1
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL UNIQUE,
Password VARCHAR(50) NOT NULL, 
Name VARCHAR(50),
Birthdate DATETIME,
Age INT CHECK(Age>=14 AND Age<=110),
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(25),
LastName VARCHAR(25),
Birthdate DATETIME,
Age INT CHECK(Age>=18 AND Age<=110),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Status(
Id INT PRIMARY KEY IDENTITY,
[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
StatusId INT NOT NULL FOREIGN KEY REFERENCES Status(Id),
OpenDate DATETIME NOT NULL,
CloseDate DATETIME,
Description VARCHAR(200) NOT NULL,
UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--2
INSERT INTO Employees(FirstName, LastName,Birthdate,DepartmentId)
VALUES
('Marlo','O''Malley''',	1958-9-21,1),
('Niki','Stanaghan',1969-11-26,4),
('Ayrton','Senna',1960-03-21,9),
('Ronnie','Peterson',1944-02-14,9),
('Giovanna','Amati',1959-07-20,5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,Description,UserId,EmployeeId)
VALUES
(1,1,2017-04-13,NULL,'Stuck Road on Str.133',6,2),
(6,3,2015-09-05,2015-12-06,'Charity trail running',3,5),
(14,2,2015-09-07,NULL,'Falling bricks on Str.58',5,2),
(4,3,2017-07-03,2017-07-06,'Cut off streetlight on Str.11',1,1)


--3
UPDATE Reports
SET CloseDate=GETDATE()
WHERE CloseDate IS NULL

--4 
DELETE FROM Reports
WHERE StatusId=4

--5
SELECT r.Description,FORMAT(r.OpenDate,'dd-MM-yyyy') FROM Reports r
WHERE r.EmployeeId IS NULL
ORDER BY r.OpenDate ASC,r.Description ASC

--6
SELECT r.Description, c.Name AS CategoryName FROM Reports r
	JOIN Categories c ON c.Id=r.CategoryId
ORDER BY r.Description, c.Name 

--7 
SELECT TOP(5) c.Name,COUNT(*) AS ReportsNumber FROM Reports r
	JOIN Categories c ON r.CategoryId=c.Id
GROUP BY r.CategoryId,c.Name
ORDER BY ReportsNumber DESC,c.Name

--8
SELECT u.Username, c.Name AS CategoryName FROM Users u
	JOIN Reports r ON r.UserId = u.Id
	JOIN Categories c ON c.Id = r.CategoryId
WHERE  DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate)
		AND DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.Birthdate)
ORDER BY u.Username, c.Name

--9
SELECT CONCAT_WS(' ',e.FirstName,e.LastName) AS FullName,COUNT(u.Id) UsersCount 
FROM Employees e
	LEFT JOIN Reports r ON r.EmployeeId=e.Id
	LEFT JOIN Users u ON u.Id=r.UserId
GROUP BY e.FirstName, e.LastName
ORDER BY UsersCount DESC, FullName

--10
SELECT CASE
             WHEN r.EmployeeId IS NULL THEN 'None'
			 ELSE CONCAT(e.FirstName, ' ', e.LastName) 
		  END [Employee],
		  ISNULL(d.[Name], 'None')[Department],
		  ISNULL(c.[Name], 'None')[Category],
		  ISNULL(r.[Description], 'None')[Description],
		  ISNULL(FORMAT(r.OpenDate, 'dd.MM.yyyy'), 'None')[OpenDate],
		  ISNULL(s.[Label], 'None')[Status],
		  ISNULL(u.[Name],'None')[User]
FROM Reports r
	LEFT JOIN Employees e ON e.Id=r.EmployeeId
	LEFT JOIN Categories c ON c.Id=r.CategoryId
		LEFT JOIN Departments d ON d.Id=e.DepartmentId
	LEFT JOIN Users u ON u.Id=r.UserId
	LEFT JOIN [Status] s ON s.Id=r.StatusId
ORDER BY e.FirstName DESC,e.LastName DESC, d.Name ASC,c.Name ASC,r.Description ASC,r.OpenDate ASC,s.Label ASC,u.Name ASC

--11
CREATE OR ALTER FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS 
BEGIN
IF @StartDate IS NULL OR @EndDate IS NULL 
	RETURN 0
RETURN DATEDIFF(HOUR,@StartDate,@EndDate)
END
	

--12 
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @EmpD INT = (SELECT e.DepartmentId FROM Employees e
	WHERE e.Id=@EmployeeId)
	
	DECLARE @ReportD INT = (SELECT c.DepartmentId FROM Categories c
		JOIN Reports r ON r.CategoryId=c.Id
		WHERE r.Id=@ReportId)

		IF @EmpD=@ReportD 
			BEGIN 
				UPDATE Reports 
					SET EmployeeId=@EmployeeId
				WHERE Id=@ReportId
			END
		ELSE THROW 51000,'E
		mployee doesn''t belong to the appropriate department!',1
END

