--1
SELECT SUBSTRING(Email,CHARINDEX('@',Email)+1,LEN(Email)) [Email Provider],COUNT(*) AS [Number Of Users] FROM Users
GROUP BY SUBSTRING(Email,CHARINDEX('@',Email)+1,LEN(Email))
ORDER BY COUNT(*) DESC, [Email Provider] ASC

--2
SELECT g.Name, gt.Name [Game Type], u.Username, us.Level, us.Cash, c.Name Character  FROM Users u
	JOIN UsersGames us ON us.UserId=u.Id
	JOIN Games g ON g.Id=us.GameId
	JOIN GameTypes gt ON gt.Id=g.GameTypeId
	JOIN Characters c ON c.Id=us.CharacterId
ORDER BY us.Level DESC, u.Username, g.Name

--3
SELECT u.Username,g.Name, COUNT(i.Id) [Items Count], SUM(i.Price) [Items Price] FROM Users u
	JOIN UsersGames us ON us.UserId=u.Id
	JOIN Games g ON g.Id=us.GameId
	JOIN UserGameItems ugt ON ugt.UserGameId=us.Id
	JOIN Items i ON i.Id=ugt.ItemId
GROUP BY u.Username,g.Name
HAVING COUNT(i.Id) >= 10 
ORDER BY [Items Count] DESC, [Items Price] DESC,u.Username ASC


--4


--5
WITH AVGStats_CTE(AVGMind, 
                  AVGLuck, 
                  AVGSpeed)
     AS (SELECT AVG(Mind) AS AVGMind, 
                AVG(Luck) AS AVGLuck, 
                AVG(Speed) AS AVGSpeed
         FROM [Statistics])

     SELECT i.[Name], 
            i.Price, 
            i.MinLevel, 
            s.Strength, 
            s.Defence, 
            s.Speed, 
            s.Luck, 
            s.Mind
     FROM Items AS i
          JOIN [Statistics] AS s ON s.Id = i.StatisticId
     WHERE s.Mind >
     (
         SELECT AVGMind
         FROM AVGStats_CTE
     )
	  AND s.Luck >
     (
         SELECT AVGLuck
         FROM AVGStats_CTE
     )
	 AND s.Speed >
     (
         SELECT AVGSpeed
         FROM AVGStats_CTE
     )
     ORDER BY i.[Name]