
--1 CREATE FK AFTER CREATION

CREATE TABLE Persons
(
PersonID TINYINT NOT NULL IDENTITY PRIMARY KEY,
FirstName VARCHAR(50),
Salary DECIMAL(10,2),
PassportID TINYINT UNIQUE NOT NULL
)

CREATE TABLE Passports
(
PassportID TINYINT NOT NULL FOREIGN KEY REFERENCES Persons(PassportID),
PassportNumber VARCHAR(8) NOT NULL, 
)

INSERT INTO dbo.Persons(FirstName,Salary, PassportID) VALUES
('Roberto',43300,102),
('Tom',56100,103),
('Yana',60200,101)

INSERT INTO Passports(PassportID,PassportNumber) VALUES 
(101,'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

--2 66/100

CREATE TABLE Models
(
ModelId INT PRIMARY KEY NOT NULL IDENTITY(100,1),
[Name] VARCHAR(50),
ManufacturerId TINYINT NOT NULL
)

CREATE TABLE Manufacturers
(
ManufacturerId TINYINT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50),
EstablishedOn DATETIME
)

INSERT INTO Models(Name,ManufacturerId) VALUES 
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3)

INSERT INTO Manufacturers(Name,EstablishedOn) VALUES 
('BMW',1916/07/03),
('Tesla',2003/01/01),
('Lada',1966/01/05)

ALTER TABLE Models ADD FOREIGN KEY (ManufacturerId) REFERENCES  Manufacturers(ManufacturerId)

SELECT Manufacturers.Name, Models.Name FROM Models 
INNER JOIN Manufacturers ON Models.ManufacturerId=Manufacturers.ManufacturerId

--3 66/100

CREATE TABLE Students
(
StudentId INT PRIMARY KEY IDENTITY,
Name VARCHAR(20)
)

CREATE TABLE Exams
(
ExamId INT PRIMARY KEY IDENTITY(101,1),
Name VARCHAR(20)
)

CREATE TABLE StudentsExams
(
StudentId INT,
ExamId INT,
PRIMARY KEY(StudentId,ExamId)
)

INSERT INTO Students(Name)
VALUES 
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams(Name)
VALUES 
('SpringMVC'),
('Neo4j'),
('Oracle 11g')


INSERT INTO StudentsExams(StudentId,ExamId)
VALUES 
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

ALTER TABLE StudentsExams ADD FOREIGN KEY (StudentId) REFERENCES Students(StudentId)
ALTER TABLE StudentsExams ADD FOREIGN KEY (ExamId) REFERENCES Exams(ExamId)

--5
USE [Table Relations]

CREATE TABLE Orders
(OrderId INT PRIMARY KEY IDENTITY,
CustomerId INT)

CREATE TABLE Customers
(CustomerId INT PRIMARY KEY IDENTITY,
Name VARCHAR(50),
Birthday DATETIME,
CityId INT)

DROP TABLE Customers
CREATE TABLE Cities
(CityId INT PRIMARY KEY IDENTITY,
Name VARCHAR(50))


CREATE TABLE OrderItems
(OrderId INT,
ItemId INT,
PRIMARY KEY(OrderId,ItemId)
)

CREATE TABLE Items
(ItemId INT PRIMARY KEY,
Name VARCHAR(50),
ItemTypeId INT,
)

CREATE TABLE ItemTypes
(ItemTypeId INT PRIMARY KEY IDENTITY,
Name VARCHAR(50))

ALTER TABLE OrderItems ADD CONSTRAINT FK_OneOrderManyItems FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
ALTER TABLE Orders ADD CONSTRAINT FK_OneCustomerManyOrders FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
ALTER TABLE Customers ADD CONSTRAINT FK_OneCustomerOneCity FOREIGN KEY (CityId) REFERENCES Cities(CityId)
ALTER TABLE OrderItems ADD CONSTRAINT FK_OneOrderManyOrderItems FOREIGN KEY (ItemId) REFERENCES Items(ItemId)
ALTER TABLE Items ADD CONSTRAINT FK_ManyItemsOneType FOREIGN KEY (ItemTypeId) REFERENCES ItemTypes(ItemTypeId)


--6
CREATE TABLE Majors (
MajorID INT PRIMARY KEY IDENTITY,
Name VARCHAR(15),
)

CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY,
[Student Number] VARCHAR(10) UNIQUE NOT NULL,
[Student Name] VARCHAR(15), 
MajorID INT NOT NULL
)

CREATE TABLE Agenda(
StudentID INT NOT NULL,
SubjectID INT NOT NULL,
PRIMARY KEY(StudentID,SubjectID)
)

CREATE TABLE Payments(
PaymentID INT PRIMARY KEY IDENTITY,
[Payment Date] DATETIME,
[Payment Amount] DECIMAL(10,2),
StudentID INT -- EXPECT ERROR THERE
)
DROP TABLE Payments
CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY IDENTITY,
[Subject Name] NVARCHAR(30)
)

ALTER TABLE Students ADD CONSTRAINT FK_StudentsToMajors FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)
ALTER TABLE Payments ADD CONSTRAINT FK_StudentsToPayments FOREIGN KEY (StudentID) REFERENCES Students(StudentID)

ALTER TABLE Agenda ADD CONSTRAINT FK_StudentToAgenda FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
ALTER TABLE Agenda ADD CONSTRAINT FK_SubjectsToAgenda FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)

--9 
USE Geography

SELECT m.MountainRange,p.PeakName,p.Elevation
FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId=m.Id
WHERE m.MountainRange='Rila'
ORDER BY p.Elevation DESC

--SELECT m.MountainRange, p.PeakName, p.Elevation 
--    FROM Mountains AS m
--    JOIN Peaks As p ON p.MountainId = m.Id
--   WHERE m.MountainRange = 'Rila'
--ORDER BY p.Elevation DESC

