USE AUTH;

ALTER PROCEDURE [dbo].[sp_JeremyEzellLab3] @Username AS NVARCHAR(50)
AS 
BEGIN
SET NOCOUNT ON;
SELECT Pass.Username, PasswordHash, Person.Employee
FROM Pass
INNER JOIN Person ON Pass.UserID = Person.UserID
WHERE Pass.Username=@Username
END