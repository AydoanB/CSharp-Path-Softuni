--1
SELECT TOP(5) EmployeeID, JobTitle, e.AddressID, a.AddressText
FROM Employees e
JOIN Addresses a ON a.AddressID=e.AddressID
ORDER BY AddressID ASC

--2
SELECT TOP(50) FirstName,LastName, t.Name AS Town, a.AddressText
FROM Employees
JOIN Addresses a ON a.AddressID= Employees.AddressID
JOIN Towns t ON t.TownID= a.TownID
ORDER BY FirstName ASC, LastName 

--3
SELECT EmployeeID, FirstName,LastName, d.Name AS DeptName
FROM Employees
JOIN Departments d ON d.DepartmentID=Employees.DepartmentID
WHERE d.Name LIKE '%Sales%'
ORDER BY EmployeeID

--4
SELECT TOP(5) e.EmployeeID, FirstName,Salary,d.Name AS DepartmentName
FROM Employees e
JOIN Departments d ON d.DepartmentID=E.DepartmentID
WHERE e.Salary>15000
ORDER BY e.DepartmentID 


--5

SELECT TOP(3) e.EmployeeID, FirstName
FROM Employees e
LEFT JOIN EmployeesProjects ep ON ep.EmployeeID=e.EmployeeID
WHERE eP.ProjectID IS NULL
ORDER BY e.EmployeeID ASC

--6
SELECT FirstName,LastName,HireDate, d.Name AS DeptName
FROM Employees e
JOIN Departments d ON d.DepartmentID=e.DepartmentID
WHERE e.HireDate > 1999-01-01 AND d.Name IN ('Sales', 'Finance')
ORDER BY HireDate ASC

--7
SELECT TOP(5) e.EmployeeID, FirstName, p.Name AS ProjectName
FROM Employees e
JOIN EmployeesProjects ep ON ep.EmployeeID=e.EmployeeID
JOIN Projects p ON p.ProjectID=ep.ProjectID
WHERE p.StartDate > 1999-08-13 AND p.EndDate IS NULL 
ORDER BY e.EmployeeID ASC

--8
SELECT e.EmployeeID,FirstName,
CASE 
WHEN DATEPART(YEAR, p.StartDate)>=2005 THEN NULL
ELSE p.Name
END AS ProjectName
FROM Employees e
JOIN EmployeesProjects ep ON ep.EmployeeID=e.EmployeeID
JOIN Projects p ON p.ProjectID=ep.ProjectID
WHERE e.EmployeeID = 24

--9 
SELECT e.EmployeeID, e.FirstName,e.ManagerID, ep.FirstName AS ManagerName
FROM Employees e
JOIN Employees ep ON e.ManagerID=ep.EmployeeID
WHERE e.ManagerID IN (3,7)
ORDER BY EmployeeID ASC

--10
SELECT TOP(50)
e.EmployeeID, e.FirstName + ' ' + e.LastName AS EmployeeName,  ep.FirstName + ' ' + ep.LastName AS ManagerName, d.Name AS DepartmentName
FROM Employees e
JOIN Employees ep ON e.ManagerID=ep.EmployeeID
JOIN Departments d ON d.DepartmentID=e.DepartmentID
ORDER BY EmployeeID ASC

--11
SELECT MIN(a.AverageSalary)AS MinSalary FROM
(
SELECT e.DepartmentID, 
	AVG(e.Salary) AS AverageSalary
	FROM Employees AS e
	GROUP BY e.DepartmentID
) AS a

--12
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Peaks p 
JOIN Mountains m ON m.Id=p.MountainId
JOIN MountainsCountries mc ON mc.MountainId=m.Id
JOIN Countries c ON c.CountryCode= mc.CountryCode
WHERE c.CountryCode= 'BG' AND p.Elevation>2835
ORDER BY p.Elevation DESC

--13
SELECT CountryCode, COUNT(MountainId) AS MountainRanges
FROM MountainsCountries AS mc
WHERE mc.CountryCode IN ('BG', 'US', 'RU')
GROUP BY CountryCode

--14
SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries c 
 LEFT JOIN CountriesRivers cr ON cr.CountryCode=c.CountryCode
 LEFT JOIN Rivers r ON r.Id=cr.RiverId
WHERE c.ContinentCode ='AF'
ORDER BY c.CountryName


--15 
SELECT ContinentCode, CurrencyCode, CurrencyCount AS CurrencyUsage FROM
(
	SELECT ContinentCode, CurrencyCode, CurrencyCount, 
	DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS CurrencyRank
	FROM
	(
		SELECT ContinentCode, CurrencyCode, 
		COUNT(*) AS CurrencyCount
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode
	) AS CurrencyCountQuery
	WHERE CurrencyCount > 1
) AS CurrencyRankingQuery
WHERE CurrencyRank = 1


--16 
SELECT COUNT(*)
FROM Countries c
LEFT JOIN MountainsCountries mc ON mc.CountryCode=c.CountryCode
LEFT JOIN Mountains m ON m.Id=mc.MountainId
WHERE m.MountainRange IS NULL