DROP TABLE Pass;
DROP TABLE Person;


USE [AUTH]
GO

CREATE TABLE Person(
UserID int IDENTITY (1,1) NOT NULL,
FirstName varchar(20) NOT NULL,
LastName varchar(30) NOT NULL,
Username varchar (20) NOT NULL,
PRIMARY KEY (UserID));

CREATE TABLE Pass(
UserID int FOREIGN KEY references Person(UserID) NOT NULL,
Username varchar(30) NOT NULL,
PasswordHash varchar(256) NOT NULL,
PRIMARY KEY (UserID));

GO

INSERT INTO Person(FirstName, LastName, Username) VALUES
	('Jay', 'Thurn', 'Thurnjb');
INSERT INTO Person(FirstName, LastName, Username) VALUES
	('John', 'Lee', 'Lee8jh');
INSERT INTO Person(FirstName, LastName, Username) VALUES
	('Ryan', 'Booth', 'Boothrr');
INSERT INTO Person(FirstName, LastName, Username) VALUES
	('Test', 'Person', 'admin');

INSERT INTO Pass VALUES
	(1, 'Thurnjb', '1000:UGmNEIloWB3dtxN9qa+pphTqgS+XQTrF:/kXMIc+QN8aQT5a2NLu4lpNsCzs=');
INSERT INTO Pass VALUES
	(2, 'Lee8jh', '1000:hVQ5apmx8Kp836Ip8L6ws+ze3RVyox+Q:YJRcDEsKW25IVSoaTUO62LEzaT4=');
INSERT INTO Pass VALUES
	(3, 'Boothrr', '1000:hVQ5apmx8Kp836Ip8L6ws+ze3RVyox+Q:YJRcDEsKW25IVSoaTUO62LEzaT4=');
INSERT INTO Pass VALUES
	(4, 'admin', '1000:hVQ5apmx8Kp836Ip8L6ws+ze3RVyox+Q:YJRcDEsKW25IVSoaTUO62LEzaT4=');