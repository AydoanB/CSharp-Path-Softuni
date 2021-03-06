CREATE TABLE Owners(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes(
Id INT PRIMARY KEY IDENTITY,
AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
Id INT PRIMARY KEY IDENTITY,
AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
BirthDate DATE NOT NULL,
OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages(
CageId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
AnimalId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id),
PRIMARY KEY(CageId,AnimalId)
)

CREATE TABLE VolunteersDepartments(
Id INT PRIMARY KEY IDENTITY,
DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
PhoneNumber VARCHAR(15) NOT NULL,
[Address] VARCHAR(50),
AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

--2 
INSERT INTO Volunteers(Name,PhoneNumber,Address,AnimalId,DepartmentId) VALUES
('Anita Kostova','0896365412','Sofia, 5 Rosa str.',15,1),
('Dimitur Stoev','0877564223',null,42,4),
('Kalina Evtimova','0896321112','Silistra, 21 Breza str.',9,7),
('Stoyan Tomov','0898564100','Montana, 1 Bor str.',18,8),
('Boryana Mileva','0888112233',null,31,5)

INSERT INTO Animals(Name,BirthDate,OwnerId,AnimalTypeId) VALUES
('Giraffe','2018-09-21',21,1),
('Harpy Eagle','2015-04-17',15,3),
('Hamadryas Baboon','2017-11-02',null,1),
('Tuatara','2021-06-30',2,4)

--3
UPDATE Animals
SET OwnerId=(SELECT Id FROM Owners o
				WHERE o.Name='Kaloqn Stoqnov')
WHERE OwnerId IS NULL

--4
DELETE FROM Volunteers 
WHERE DepartmentId=2

DELETE FROM VolunteersDepartments
WHERE DepartmentName='Education program assistant'

--5
SELECT Name,PhoneNumber,Address,AnimalId,DepartmentId FROM Volunteers
ORDER BY Name,AnimalId,DepartmentId

--6
SELECT a.Name, at.AnimalType,FORMAT(a.BirthDate,'dd.MM.yyyy') FROM Animals a
	JOIN AnimalTypes at ON at.Id=a.AnimalTypeId
	ORDER BY a.Name

--7 
SELECT TOP(5) 
o.Name Owner, COUNT(*)[CountOfAnimals]
FROM Owners O
	JOIN Animals a ON a.OwnerId=o.Id
GROUP BY o.Name
ORDER BY COUNT(*) DESC, Owner

--8

SELECT 
		CONCAT_WS('-',o.Name,a.Name) OwnersAnimals,
		o.PhoneNumber,
		ac.CageId
FROM Owners o 
	JOIN Animals a ON a.OwnerId=o.Id
	JOIN AnimalTypes at ON at.Id=a.AnimalTypeId
	JOIN AnimalsCages ac ON ac.AnimalId=a.Id
WHERE at.AnimalType='Mammals'
ORDER BY o.Name ASC, a.Name DESC

--9
SELECT 
v.Name,
v.PhoneNumber,
SUBSTRING(v.Address, CHARINDEX(',', v.Address)+1,LEN(v.Address)) [Address]
FROM Volunteers v
	JOIN VolunteersDepartments vd ON vd.Id=v.DepartmentId
WHERE TRIM(SUBSTRING(v.Address,0, CHARINDEX(',', v.Address))) ='Sofia' AND vd.DepartmentName='Education program assistant' 
ORDER BY v.Name

--10
SELECT 
a.Name,DATEPART(YEAR,a.BirthDate) [BirthYear],at.AnimalType
FROM Animals a
	JOIN AnimalTypes at ON at.Id=a.AnimalTypeId
	WHERE a.OwnerId IS NULL AND DATEDIFF(YEAR, a.BirthDate, '2022/01/01')<5 AND at.AnimalType!='Birds'
ORDER BY a.Name

--11
CREATE OR ALTER FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(50))
RETURNS INT 
	BEGIN
	DECLARE @DepId INT =(SELECT vd.Id FROM VolunteersDepartments vd
			WHERE vd.DepartmentName=@VolunteersDepartment)
	RETURN (SELECT COUNT(*) FROM Volunteers v
			WHERE v.DepartmentId=@DepId)
			
	END

--12 
CREATE OR ALTER PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS 
BEGIN
		SELECT a.Name,
		CASE
			WHEN a.OwnerId IS NULL THEN 'For adoption'
			ELSE o.Name
		END [OwnersName]
		FROM Owners o
		LEFT JOIN Animals a ON a.OwnerId=o.Id
		WHERE a.Name=@AnimalName
END

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'

SELECT * FROM Animals a
WHERE a.Name='Hippo'