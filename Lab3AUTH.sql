--DROP TABLES
DROP TABLE Credentials;

--CREATE TABLES

CREATE TABLE Credentials
	(CredentialID int NOT NULL PRIMARY KEY IDENTITY(1,1),
	UserName varchar(255),
	Password varchar(255)
	);

INSERT INTO Credentials(UserName, Password) VALUES 
	('Thurnjb', 'dukedog');
INSERT INTO Credentials(UserName, Password) VALUES
	('Boothrr', 'password');
INSERT INTO Credentials(UserName, Password) VALUES
	('Lee8jh', 'password');

SELECT * FROM Credentials;