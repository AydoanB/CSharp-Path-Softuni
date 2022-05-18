--1
SELECT FirstName, LastName
FROM Employees
WHERE LEFT(FirstName,2)='Sa'


--2
SELECT FirstName, LastName FROM Employees
WHERE LastName LIKE '%ei%'

--3
SELECT FirstName FROM Employees
	WHERE DepartmentID=3
	OR 
	DepartmentID=10
	AND
	HireDate>=1995 OR HireDate<=2005

--4
SELECT FirstName,LastName FROM Employees
WHERE CHARINDEX('engineer',JobTitle)=0

--5
SELECT Name FROM Towns
WHERE LEN(Name)=5 OR LEN(Name) = 6
ORDER BY Name ASC

--6
SELECT TownID, Name FROM Towns
WHERE LEFT(Name,1)='M' OR
LEFT(Name,1)='K' OR
LEFT(Name,1)='B' OR
LEFT(Name,1)='E'
ORDER BY Name ASC

--7 
SELECT TownID, Name FROM Towns
WHERE
LEFT(Name,1) != 'R' AND
LEFT(Name,1) != 'B' AND
LEFT(Name,1) != 'D'
ORDER BY Name ASC

--8
CREATE VIEW V_EmployeesHiredAfter2000 
AS
SELECT FirstName,LastName,HireDate FROM Employees
WHERE YEAR(HireDate)>2000 

--9 
SELECT FirstName,LastName FROM Employees
WHERE LEN(LastName)=5

--10
SELECT * FROM
(
		SELECT EmployeeID, FirstName, LastName, Salary,
			DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
		FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000 
) AS [Rank Table]
WHERE [Rank] = 2
ORDER BY Salary DESC



--12
SELECT CountryName AS [Country Name], IsoCode AS [Iso Code] FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode

--13
SELECT p.PeakName, r.RiverName, LOWER(CONCAT(SUBSTRING(PeakName,1,LEN(PeakName)-1),RiverName)) AS Mix 
FROM Peaks AS p, Rivers AS r
WHERE RIGHT(PeakName,1)=LEFT(RiverName,1)
ORDER BY Mix

--14
SELECT TOP(50) [Name], FORMAT(Start, 'yyyy-MM-dd','en-EN') AS [Start] FROM Games
WHERE YEAR(games.Start)>=2011 and YEAR(games.Start)<=2012
ORDER BY Start, Name

--15
SELECT Username,
SUBSTRING(Email,(CHARINDEX('@',Email)+1),LEN(Email)) AS [Email Provider] 
FROM Users
ORDER BY [Email Provider], Username

--16
SELECT Username,IpAddress FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username


--17 SELECT GETDATE() 'Today', DATEPART(hour,GETDATE()) 'Hour Part'

--CASE
--    WHEN condition1 THEN result1
--    WHEN condition2 THEN result2
--    WHEN conditionN THEN resultN
--    ELSE result
--END;
SELECT Name AS Game,
CASE 
WHEN DATEPART(HOUR,Start)>=0 AND DATEPART(HOUR,Start)<12 THEN 'Morning' 
WHEN DATEPART(HOUR,Start)>=12 AND DATEPART(HOUR,Start)<18 THEN 'Afternoon' 
WHEN DATEPART(HOUR,Start)>=18 AND DATEPART(HOUR,Start)<24 THEN 'Afternoon' 
END AS [Part of the Day],
CASE 
WHEN Games.Duration<=3 THEN 'Extra Short'
WHEN Games.Duration>=4 AND Games.Duration<=6 THEN 'Short'
WHEN Games.Duration>6 THEN 'Long'
ELSE 'Extra Long'
END AS Duration
FROM Games
ORDER BY Name, Duration,[Part of the Day]

SELECT * FROM Games

--18 
SELECT ProductName, OrderDate, DATEADD(DAY,3,OrderDate) AS [Pay due], DATEADD(MONTH,1,OrderDate) AS [Deliver due] FROM Orders

--19
CREATE TABLE People(
ID INT IDENTITY PRIMARY KEY,
Name VARCHAR(15),
Birthday DATETIME
)
SELECT Name,
DATEDIFF(YEAR,Birthday, GETDATE()) AS [Age in Years],
DATEDIFF(MONTH,Birthday, GETDATE()) AS [Age in Months],
DATEDIFF(DAY,Birthday, GETDATE()) AS [Age in Days],
DATEDIFF(MINUTE,Birthday, GETDATE()) AS [Age in Minutes]
FROM People
