--1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
SELECT e.FirstName,e.LastName
FROM Employees e
WHERE e.Salary>35000

--2
CREATE PROCEDURE 
usp_GetEmployeesSalaryAboveNumber 
@Salary DECIMAL(18,4) 
AS
SELECT e.FirstName,e.LastName
FROM Employees e
WHERE e.Salary>=@Salary

EXEC usp_GetEmployeesSalaryAboveNumber
@Salary=48100

--3
CREATE PROCEDURE usp_GetTownsStartingWith
@Letter VARCHAR(1)
AS 
SELECT t.Name FROM Towns t
WHERE LEFT(t.Name,1)=@Letter

--4
CREATE PROCEDURE usp_GetEmployeesFromTown
@tName VARCHAR(50)
AS 
SELECT e.FirstName,e.LastName FROM Employees e
JOIN Addresses a ON a.AddressID=e.AddressID
JOIN Towns t ON t.TownID=a.TownID
WHERE @tName=t.Name


--5 
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS NVARCHAR(50)
BEGIN 
	IF @salary IS NULL RETURN NULL
	ELSE IF @salary<30000 RETURN 'Low'
	ELSE IF @salary <=50000 RETURN 'Average'
	ELSE RETURN 'High'
	RETURN NULL
END


--6
CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel
@SalaryLevel VARCHAR(10)
AS 
SELECT e.FirstName,e.LastName FROM Employees e
WHERE dbo.ufn_GetSalaryLevel(e.Salary)=@SalaryLevel

--7 
CREATE OR ALTER FUNCTION ufn_IsWordComprised (@setOfLetters NVARCHAR(10), @word NVARCHAR(50)) 
RETURNS BIT 
AS
BEGIN 
	DECLARE @count INT=1
	DECLARE @Res BIT=1
	WHILE @count<=LEN(@word)
		BEGIN 
			IF CHARINDEX(SUBSTRING(@word,@count,1),@setOfLetters)<=0
			BEGIN 
				SET @Res=0;
				RETURN @Res;
			END
			SET @count+=1;
		END
	RETURN @Res
END

--8
CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment(@departmentId INT)
AS
BEGIN

	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN 
	(
	SELECT EmployeeID FROM Employees
	WHERE DepartmentID=@departmentId
	)

	UPDATE Employees
	SET ManagerID=NULL
	WHERE ManagerID IN 
	(
	SELECT EmployeeID FROM Employees
	WHERE DepartmentID=@departmentId
	)
	
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE DepartmentID=@departmentId

	DELETE FROM Departments
	WHERE DepartmentID=@departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID=@departmentId
END

--9
CREATE PROC usp_GetHoldersFullName
AS 
SELECT CONCAT_WS(' ',a.FirstName,a.LastName) AS [Full Name]  FROM AccountHolders a

--10
CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan(@Number DECIMAL(18,4))
AS
SELECT a.FirstName,a.LastName FROM AccountHolders a
JOIN Accounts acc ON acc.AccountHolderId=a.Id
GROUP BY a.FirstName, a.LastName
HAVING SUM(acc.Balance)>@Number
ORDER BY a.FirstName, a.LastName

--11
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18,4),@yir FLOAT,@Years INT)
RETURNS DECIMAL(18,4) AS
BEGIN
	DECLARE @Res DECIMAL(18,4)=@Sum*(POWER(1+@yir,@Years))
	RETURN @Res
END

--12
CREATE OR ALTER PROC usp_CalculateFutureValueForAccount(@AccountID INT,@ir FLOAT)
AS
BEGIN
	SELECT a.Id AS [Account Id], 
	ah.FirstName,
	ah.LastName,
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance,@ir,5) AS [Balance in 5 years] 
	
	FROM Accounts a
	JOIN AccountHolders ah ON ah.Id=a.AccountHolderId
	WHERE a.Id=@AccountID
END

--13
CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(100))
RETURNS TABLE
AS
RETURN SELECT SUM(Cash) AS SumCash FROM
	(
		SELECT g.Name, ug.Cash,
			ROW_NUMBER() OVER (PARTITION BY g.Name ORDER BY ug.Cash DESC) AS RowNum
		FROM Games g
		JOIN UsersGames AS ug ON g.Id = ug.GameId
		WHERE g.Name = @gameName
	) AS RowNumQuery
	WHERE RowNum % 2 != 0
