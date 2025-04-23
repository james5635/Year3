-- CREATE DATABASE test
-- GO
-- USE test
-- GO
-- IF OBJECT_ID('dbo.Numbers', 'U') IS NOT NULL
--     DROP TABLE dbo.Numbers
-- CREATE TABLE dbo.Numbers
-- (
--     Num INT,
--     Description VARCHAR(50)
-- )
-- DECLARE @i INT = 1

-- WHILE @i <= 10
-- BEGIN
--     INSERT INTO dbo.Numbers
--         (num)
--     VALUES(@i)
--     SET @i = @i + 1
-- END

-- UPDATE dbo.Numbers
-- SET Description = 'Even'
-- WHERE Num % 2 = 0

-- SELECT *
-- FROM dbo.Numbers
-- GO

EXEC SP_WHO 
-- KILL 65
