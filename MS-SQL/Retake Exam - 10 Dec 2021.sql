
CREATE TABLE Passengers(
Id INT PRIMARY KEY IDENTITY,
FullName VARCHAR(100) UNIQUE NOT NULL,
Email VARCHAR(50) UNIQUE NOT NULL
)


CREATE TABLE Pilots(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30) UNIQUE NOT NULL,
LastName VARCHAR(30) UNIQUE NOT NULL,
Age TINYINT NOT NULL CHECK(Age>=21 AND Age<=62),
Rating FLOAT CHECK(Rating>=0.0 AND Rating<=10.0)
)

CREATE TABLE AircraftTypes(
Id INT IDENTITY PRIMARY KEY,
TypeName VARCHAR(30) NOT NULL UNIQUE
)


CREATE TABLE Aircraft(
Id INT IDENTITY PRIMARY KEY,
Manufacturer VARCHAR(25) NOT NULL,
Model VARCHAR(30) NOT NULL,
Year INT NOT NULL,
FlightHours INT,
Condition CHAR(1) NOT NULL,
TypeId INT NOT NULL FOREIGN KEY REFERENCES AircraftTypes(Id)
)
--PROB ERROR IN UNIQUE
CREATE TABLE PilotsAircraft(
AircraftId INT  NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
PilotId INT  NOT NULL FOREIGN KEY REFERENCES Pilots(Id),
PRIMARY KEY(AircraftId,PilotId)
)

CREATE TABLE Airports(
Id INT PRIMARY KEY IDENTITY,
AirportName VARCHAR(70) UNIQUE NOT NULL,
Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations(
Id INT PRIMARY KEY IDENTITY,
AirportId INT NOT NULL FOREIGN KEY REFERENCES Airports(Id),
[Start] DATETIME NOT NULL,
AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id),
PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
)

--2
INSERT INTO Passengers(FullName, Email)
SELECT CONCAT_WS(' ',FirstName, LastName), FirstName+LastName +'@gmail.com'  FROM Pilots
WHERE Pilots.Id BETWEEN 5 AND 15

--3
UPDATE Aircraft
SET Condition='A'
WHERE Condition IN ('C','B') AND (FlightHours IS NULL OR  FlightHours<=100) AND Year>=2013

--4
DELETE FROM Passengers
WHERE LEN(FullName)<=10

--5
SELECT a.Manufacturer, a.Model,a.FlightHours,a.Condition FROM Aircraft a
ORDER BY a.FlightHours DESC

--6
SELECT p.FirstName,p.LastName, a.Manufacturer,a.Model, a.FlightHours FROM Pilots p
	JOIN PilotsAircraft pa ON pa.PilotId=p.Id
	JOIN Aircraft a ON a.Id=pa.AircraftId
WHERE a.FlightHours <= 304
ORDER BY FlightHours DESC, p.FirstName ASC

--7
SELECT TOP(20)  
fd.Id AS DestinationId, fd.Start,p.FullName, a.AirportName, fd.TicketPrice
FROM FlightDestinations fd
	JOIN Airports a ON a.Id= fd.AirportId
	JOIN Passengers p ON p.Id=fd.PassengerId
WHERE DAY(fd.Start)%2=0
ORDER BY fd.TicketPrice DESC, a.AirportName ASC

--8
SELECT a.Id AS AircraftId, a.Manufacturer, a.FlightHours,COUNT(*) AS FlightDestinationCount, ROUND(AVG(fd.TicketPrice),2) AS AvgPrice 
FROM Aircraft a
	JOIN FlightDestinations fd ON fd.AircraftId=a.Id
GROUP BY a.Id, a.Manufacturer, a.FlightHours
HAVING COUNT(*)>=2
ORDER BY FlightDestinationCount DESC, a.Id ASC

--9
SELECT p.FullName, COUNT(*) AS CountOfAircraft,SUM(fd.TicketPrice) AS TotalPayed FROM Passengers p
	JOIN FlightDestinations fd ON fd.PassengerId=p.Id
WHERE SUBSTRING(p.FullName,2,1)='a'
GROUP BY p.Id, p.FullName
HAVING COUNT(*)>=2
ORDER BY  p.FullName

--10
SELECT a.AirportName, fd.Start AS DayTime,fd.TicketPrice, pass.FullName, air.Manufacturer,air.Model  FROM Airports a
	JOIN FlightDestinations fd ON fd.AirportId=a.Id
	JOIN Aircraft air ON air.Id=fd.AircraftId
	JOIN Passengers pass ON pass.Id=fd.PassengerId
WHERE (DATEPART(HOUR,fd.Start) BETWEEN 6 AND 20) AND fd.TicketPrice>2500
ORDER BY air.Model ASC

--11
CREATE OR ALTER FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(100))
RETURNS INT 
AS
BEGIN
	DECLARE @RES INT =(SELECT COUNT(*) FROM FlightDestinations fd
	JOIN Passengers p ON p.Id = fd.PassengerId
	GROUP BY p.Email
	HAVING p.Email=@email
	)

	IF @RES IS NULL RETURN 0;
	ELSE RETURN @RES;
	RETURN NULL
END

--12
CREATE OR ALTER PROC usp_SearchByAirportName (@airportName VARCHAR(70))
AS
BEGIN
		SELECT air.AirportName,
			   p.FullName,
		CASE 
			WHEN fd.TicketPrice<=400 THEN 'Low'
			WHEN fd.TicketPrice<=1500 THEN 'Medium'
			WHEN fd.TicketPrice>1500 THEN 'High'
		END AS LevelOfTickerPrice,
				a.Manufacturer,
				a.Condition,
				at.TypeName
		FROM Airports air
		JOIN FlightDestinations fd ON fd.AirportId = air.Id
		JOIN Passengers p ON p.Id = fd.PassengerId
		JOIN Aircraft a ON a.Id = fd.AircraftId
		JOIN AircraftTypes [at] ON at.Id = a.TypeId
	WHERE air.AirportName=@airportName
	ORDER BY a.Manufacturer, p.FullName
END

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'
