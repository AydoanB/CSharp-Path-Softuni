--1
SELECT COUNT(*)
 FROM WizzardDeposits w

--2
 SELECT MAX(MagicWandSize) AS LongestMagicWand
 FROM WizzardDeposits

--3
  SELECT  DepositGroup ,MAX(MagicWandSize) AS LongestMagicWand
 FROM WizzardDeposits
 GROUP BY DepositGroup

--4
SELECT TOP(2) w.DepositGroup
FROM WizzardDeposits w
GROUP BY w.DepositGroup
ORDER BY AVG(w.MagicWandSize)

--5
SELECT w.DepositGroup ,SUM(w.DepositAmount)
FROM WizzardDeposits w
GROUP BY w.DepositGroup

--6
SELECT w.DepositGroup ,SUM(w.DepositAmount)
FROM WizzardDeposits w
WHERE w.MagicWandCreator LIKE '%Ollivander%'
GROUP BY w.DepositGroup

--7
SELECT w.DepositGroup ,SUM(w.DepositAmount) AS TotalSum
FROM WizzardDeposits w
WHERE w.MagicWandCreator LIKE '%Ollivander%'
GROUP BY w.DepositGroup
HAVING SUM(w.DepositAmount)<150000
ORDER BY TotalSum DESC

--8
SELECT DepositGroup,MagicWandCreator,MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--9
WITH t AS (SELECT CASE 
WHEN w.Age>=0 AND w.Age<=10 THEN '[0-10]'
WHEN w.Age>=11 AND w.Age<=20 THEN '[11-20]'
WHEN w.Age>=21 AND w.Age<=30 THEN '[21-30]'
WHEN w.Age>=31 AND w.Age<=40 THEN '[31-40]'
WHEN w.Age>=41 AND w.Age<=50 THEN '[41-50]'
WHEN w.Age>=51 AND w.Age<=60 THEN '[51-60]'
WHEN w.Age>=61 THEN '[61+]'
END as AgeGroup
FROM WizzardDeposits w)
SELECT t.AgeGroup,COUNT(*)
FROM t
GROUP BY t.AgeGroup

--10
SELECT LEFT(FirstName,1) AS FirstLetter
FROM WizzardDeposits
WHERE (DepositGroup)='Troll Chest'
GROUP BY LEFT(FirstName,1)
ORDER BY FirstLetter ASC

--11
SELECT DepositGroup,IsDepositExpired,AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits w
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC, w.IsDepositExpired ASC

--12
SELECT SUM(Difference) AS SumDifference FROM
(
	SELECT FirstName AS [Host Wizard], 
			DepositAmount AS [Host Wizard Deposit],
			LEAD(FirstName) OVER(ORDER BY Id ASC) AS [Guest Wizard],
			LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Guest Wizard Deposit],
			DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Difference]
	FROM WizzardDeposits
) AS LeadQuery
WHERE [Guest Wizard] IS NOT NULL

--13
SELECT DepartmentID, SUM(Salary)
FROM Employees
GROUP BY DepartmentID

--14
SELECT DepartmentID, MIN(Salary)
FROM Employees
WHERE HireDate>'01/01/2000'
GROUP BY DepartmentID
HAVING DepartmentID IN (2,5,7)

--15
SELECT *
INTO EmployeesAvgSalaries 
FROM Employees
WHERE Salary>30000;

DELETE FROM EmployeesAvgSalaries WHERE ManagerID=42

UPDATE EmployeesAvgSalaries
SET Salary+=5000
WHERE DepartmentID=1

SELECT DepartmentID ,AVG(Salary) AS AverageSalary
FROM EmployeesAvgSalaries
GROUP BY DepartmentID

--16
SELECT DepartmentID ,MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary)<30000 OR MAX(Salary)>70000

--17
SELECT COUNT(*) AS Count
FROM Employees
WHERE ManagerID IS NULL

--18
SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary FROM
(
	SELECT DepartmentID, Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	FROM Employees
) AS SalaryRankQuery
WHERE SalaryRank = 3

--19
SELECT TOP(10) e1.FirstName, e1.LastName, e1.DepartmentID
FROM Employees AS e1
WHERE e1.Salary > (
			SELECT AVG(Salary) AS AverageSalary
			FROM Employees AS e2
			WHERE e2.DepartmentID = e1.DepartmentID
			GROUP BY DepartmentID
)
ORDER BY DepartmentID