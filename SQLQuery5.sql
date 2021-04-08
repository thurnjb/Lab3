use auth;

GO
CREATE PROCEDURE sp_JeremyEzellLab3
@UserName AS NVARCHAR(255),
@PasswordHash AS NVARCHAR(255)

as
BEGIN

SET NOCOUNT ON;

SELECT Username, PasswordHash
FROM Pass
WHERE Username = @UserName
AND PasswordHash = @PasswordHash;






END;