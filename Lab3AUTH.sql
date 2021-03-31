USE [AUTH]
GO


CREATE TABLE Person(
UserID int IDENTITY (1,1) NOT NULL,
FirstName varchar(20) NOT NULL,
LastName varchar(30) NOT NULL,
Username varchar (80) NOT NULL,
Employee bit NOT NULL,
CustHear varchar(255),
CustAddress varchar(255),
CustPhone varchar(255),
PRIMARY KEY (UserID));

CREATE TABLE tblFiles
(
	id int IDENTITY(1,1) NOT NULL,
	CustomerID int REFERENCES Person(UserID),
	Name varchar(50) NOT NULL,
	ContentType nvarchar(200) NOT NULL,
	Data varbinary(max) NOT NULL,
)	ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE Pass(
UserID int FOREIGN KEY references Person(UserID) NOT NULL,
Username varchar(30) NOT NULL,
PasswordHash varchar(256) NOT NULL,
PRIMARY KEY (UserID));

GO

INSERT INTO Person(FirstName, LastName, Username, Employee) VALUES
	('Jay', 'Thurn', 'Thurnjb', 1);
INSERT INTO Person(FirstName, LastName, Username, Employee) VALUES
	('John', 'Lee', 'Lee8jh', 1);
INSERT INTO Person(FirstName, LastName, Username, Employee) VALUES
	('Ryan', 'Booth', 'Boothrr', 1);
INSERT INTO Person(FirstName, LastName, Username, Employee) VALUES
	('Test', 'Person', 'admin', 1);

INSERT INTO Pass VALUES
	(1, 'Thurnjb', '1000:UGmNEIloWB3dtxN9qa+pphTqgS+XQTrF:/kXMIc+QN8aQT5a2NLu4lpNsCzs=');
INSERT INTO Pass VALUES
	(2, 'Lee8jh', '1000:hVQ5apmx8Kp836Ip8L6ws+ze3RVyox+Q:YJRcDEsKW25IVSoaTUO62LEzaT4=');
INSERT INTO Pass VALUES
	(3, 'Boothrr', '1000:hVQ5apmx8Kp836Ip8L6ws+ze3RVyox+Q:YJRcDEsKW25IVSoaTUO62LEzaT4=');
INSERT INTO Pass VALUES
	(4, 'admin', '1000:hVQ5apmx8Kp836Ip8L6ws+ze3RVyox+Q:YJRcDEsKW25IVSoaTUO62LEzaT4=');

Select * from person;
Select * from pass;