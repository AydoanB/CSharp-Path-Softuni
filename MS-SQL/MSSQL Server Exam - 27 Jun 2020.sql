CREATE TABLE Clients(
ClientId INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics(
MechanicId INT NOT NULL PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(255) NOT NULL
)


CREATE TABLE Models(
ModelId INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) UNIQUE NOT NULL
)


CREATE TABLE Jobs(
JobId INT PRIMARY KEY IDENTITY,
ModelId INT NOT NULL FOREIGN KEY REFERENCES Models(ModelId),
[Status] NVARCHAR(11) NOT NULL CHECK([Status] IN ('Pending','In Progress','Finished')) DEFAULT('Pending'),
ClientId INT NOT NULL FOREIGN KEY REFERENCES Clients(ClientId),
MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
IssueDate DATE NOT NULL,
FinishDate DATE
)

CREATE TABLE Orders(
OrderId INT PRIMARY KEY IDENTITY,
JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
IssueDate DATE,
Delivered BIT NOT NULL DEFAULT 0
)

CREATE TABLE Vendors(
VendorId INT PRIMARY KEY IDENTITY,
Name NVARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Parts(
PartId INT PRIMARY KEY IDENTITY,
SerialNumber NVARCHAR(50) NOT NULL UNIQUE,
Description NVARCHAR(255),
Price MONEY NOT NULL CHECK(Price>0),
VendorId INT NOT NULL FOREIGN KEY REFERENCES Vendors(VendorId),
StockQty INT NOT NULL CHECK(StockQty>=0) DEFAULT 0
)

CREATE TABLE OrderParts(
OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
Quantity INT NOT NULL CHECK(Quantity>0) DEFAULT 1
PRIMARY KEY(OrderId,PartId)
)

CREATE TABLE PartsNeeded(
JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
Quantity INT NOT NULL CHECK(Quantity > 0) DEFAULT 1
PRIMARY KEY(JobId,PartId)
)



--2
INSERT INTO Clients(FirstName,LastName,Phone) 
VALUES
('Teri','Ennaco',570-889-5187),
('Merlyn','Lawler',201-588-7810),
('Georgene','Montezuma',925-615-5185),
('Jettie','Mconnell',908-802-3564),
('Lemuel','Latzke',631-748-6479),
('Melodie','Knipp',805-690-1682),
('Candida','Corbley',908-275-8357)

INSERT INTO Parts(SerialNumber,Description,Price,VendorId) VALUES
('WP8182119','Door Boot Seal',117.86,2),
('W10780048','Suspension Rod',42.81,1),
('W10841140','Silicone Adhesive',6.77,4),
('WPY055980','High Temperature Adhesive',13.94,3)

--3
SELECT m.MechanicId, m.FirstName FROM Mechanics m
WHERE m.FirstName ='RYAN' AND m.LastName='HARNOS'

UPDATE Jobs
SET Status='In Progress',
MechanicId=
(
	SELECT TOP(1) m.MechanicId FROM Mechanics m
		WHERE CONCAT_WS(' ',m.FirstName,m.LastName)='Ryan Harnos'
)
WHERE Status='Pending'

--4 
DELETE FROM OrderParts 
WHERE OrderId=19

DELETE FROM Orders
WHERE OrderId=19


--5
SELECT CONCAT_WS(' ', m.FirstName,m.LastName) AS Mechanic,
j.Status,
j.IssueDate
FROM Mechanics m
	JOIN Jobs j ON j.MechanicId=m.MechanicId
ORDER BY m.MechanicId,j.IssueDate,j.JobId

--6
SELECT CONCAT_WS(' ', c.FirstName,c.LastName) AS Client,
 DATEDIFF(DAY, IssueDate, '24 April 2017') AS [Days going],
j.Status
	FROM Clients c
		JOIN Jobs j ON j.ClientId=c.ClientId
		WHERE j.Status!='Finished'
			ORDER BY [Days going] DESC,c.ClientId ASC

--7
SELECT CONCAT_WS(' ', m.FirstName,m.LastName) AS Mechanic,
AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average days]
FROM Mechanics m
	JOIN Jobs j ON j.MechanicId=m.MechanicId
GROUP BY m.FirstName,m.LastName, m.MechanicId
ORDER BY m.MechanicId

--8
 SELECT CONCAT(FirstName, ' ' + LastName) AS Available
FROM Mechanics
WHERE MechanicId NOT IN
(
    SELECT DISTINCT
           m.MechanicId
    FROM Mechanics AS m
         JOIN Jobs AS j ON j.MechanicId = m.MechanicId
    WHERE j.Status = 'In Progress'
)
ORDER BY MechanicId

--9
SELECT j.JobId,
       ISNULL(SUM(p.Price * op.Quantity), 0.00) AS Total
FROM Jobs AS j
     LEFT JOIN Orders AS o ON o.JobId = j.JobId
     LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
     LEFT JOIN Parts AS p ON p.PartId = op.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC,
         j.JobId

--10
SELECT p.PartId,
       p.Description,
       ISNULL(pn.Quantity, 0) AS Required,
       ISNULL(p.StockQty, 0) AS [In Stock],
       ISNULL(CASE
                  WHEN o.Delivered = 0
                  THEN op.Quantity
                  ELSE 0
              END, 0) AS Ordered
FROM Parts AS p
     JOIN PartsNeeded AS pn ON pn.PartId = p.PartId
     LEFT JOIN OrderParts AS op ON op.PartId = p.PartId
     JOIN Jobs AS j ON j.JobId = pn.JobId
     LEFT JOIN Orders AS o ON o.JobId = j.JobId
WHERE pn.Quantity > ISNULL(p.StockQty + CASE
                                            WHEN o.Delivered = 0
                                            THEN op.Quantity
                                            ELSE 0
                                        END, 0)
      AND j.Status != 'Finished'
ORDER BY p.PartId

--11
CREATE PROCEDURE usp_PlaceOrder
(
                 @jobId            INT,
                 @partSerialNumber VARCHAR(50),
                 @quantity         INT
)
AS
     BEGIN
	    -- Params validation
         IF(@quantity <= 0)
             BEGIN
                 THROW 50012, 'Part quantity must be more than zero!', 1
         END
         IF(
           (
               SELECT JobId  
               FROM Jobs
               WHERE JobId = @jobId
           ) IS NULL)
             BEGIN;
                 THROW 50013, 'Job not found!', 1
         END;
         IF(
           (
               SELECT Status
               FROM Jobs
               WHERE JobId = @jobId
           ) = 'Finished')
             BEGIN;
                 THROW 50011, 'This job is not active!', 1
         END;
         IF(
           (
               SELECT SerialNumber
               FROM Parts
               WHERE SerialNumber = @partSerialNumber
           ) IS NULL)
             BEGIN;
                 THROW 50014, 'Part not found!', 1
         END;

	    -- Create Order if not exists
         IF(
           (
               SELECT JobId
               FROM Orders
               WHERE JobId = @jobId
                     AND IssueDate IS NULL
           ) IS NULL)
             BEGIN
                 INSERT INTO Orders(JobId,
                                    IssueDate,
                                    Delivered
                                   )
                 VALUES
                 (
                        @jobId,
                        NULL,
                        0
                 )
         END;

	    -- Add part to order if not exists
         DECLARE @orderId INT=
         (
             SELECT TOP 1 OrderId
             FROM Orders
             WHERE JobId = @jobId
                   AND IssueDate IS NULL
         )
         DECLARE @partId INT=
         (
             SELECT PartId
             FROM Parts
             WHERE SerialNumber = @partSerialNumber
         )
         IF(
           (
               SELECT PartId
               FROM OrderParts
               WHERE PartId = @partId
                     AND OrderId = @orderId
           ) IS NULL)
             BEGIN
                 INSERT INTO OrderParts(OrderId,
                                        PartId,
                                        Quantity
                                       )
                 VALUES
                 (
                        @orderId,
                        @partId,
                        @quantity
                 )
         END
	    -- Part exists in the order - Add quantity
             ELSE
             BEGIN
                 UPDATE OrderParts
                   SET
                       Quantity+=@quantity
                 WHERE PartId = @partId
                       AND OrderId = @orderId
         END
     END

