CREATE DATABASE TimeKeeper;

SELECT * FROM TimeKeeper.INFORMATION_SCHEMA.TABLES;

CREATE TABLE Competitors (
    Id SMALLINT NOT NULL CHECK (Id > 0),
    Name VARCHAR(50) NOT NULL,
    StartNo SMALLINT NOT NULL CHECK (StartNo > 0),
    Team VARCHAR(50),
    BicycleType VARCHAR(50),
    CONSTRAINT PK_Competitor PRIMARY KEY (Id)
    )


CREATE TABLE Races (
    Id SMALLINT NOT NULL CHECK (Id > 0),
    Name VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Races PRIMARY KEY (Id)
    )


CREATE TABLE Stages (
    Id SMALLINT NOT NULL CHECK (Id > 0),
    Name VARCHAR(50) NOT NULL,
    RaceId SMALLINT NOT NULL CHECK (RaceId > 0),
    CONSTRAINT PK_Stages PRIMARY KEY (Id),
    CONSTRAINT FK_Stages FOREIGN KEY (RaceId) REFERENCES Races(Id)
    )


 CREATE TABLE Results (
    CompetitorId SMALLINT NOT NULL CHECK (CompetitorId > 0),
    StageId SMALLINT NOT NULL CHECK (StageId > 0),
    StageTime NVARCHAR(12) DEFAULT '00:00:00.000',
    CONSTRAINT FK1_Results FOREIGN KEY (CompetitorId) REFERENCES Competitors(Id),
    CONSTRAINT FK2_Results FOREIGN KEY (StageId) REFERENCES Stages(Id)
    )   
                    

ALTER TABLE Competitors ADD Category VARCHAR(10);


INSERT INTO Competitors VALUES (34, 'Jerome Daniels', 1, 'club name', 'Enduro', 'Men'),
                          (2, 'Asher Masse', 2, 'club name', '', 'Men'),
                          (88, 'Orson Olson', 3, 'club name', 'Downhill', 'Men'),
                          (30, 'Melyssa Chaneys', 4, 'club name', 'Enduro', 'Women'),
                          (161, 'Lilah Alvarez', 5,'club name', 'Enduro', 'Women'),
                          (6, 'Mary Mack', 6, 'club name', '', 'Women');


INSERT INTO Races VALUES (1, 'Split'),
                         (2, 'Omis'),
                         (3, 'Trogir');

UPDATE Races SET Id = 11 WHERE Name = 'Split';
UPDATE Races SET Id = 22 WHERE Name = 'Omis';
UPDATE Races SET Id = 33 WHERE Name = 'Trogir';


INSERT INTO Stages VALUES (1, 'S1', 11),
                          (2, 'S2', 11),
                          (3, 'S3', 11),
                          (4, 'S4', 22),
                          (5, 'S5', 11);



INSERT INTO Results VALUES (34, 3, '00:01:34.522'),
                     (34, 1, '00:01:27.630'),
                     (34, 2, '00:02:01.054'),
                     (34, 5, '00:03:40.733'),
                     (161, 4, '00:02:29.970'),
                     (6, 4, '00:02:56.821');


SELECT * FROM Competitors ORDER BY StartNo ASC;
SELECT * FROM Races;
SELECT * FROM Stages;
SELECT * FROM Results;

SELECT * FROM Races
INNER JOIN Stages
ON Stages.RaceId = Races.Id
INNER JOIN Results
ON Results.StageId = Stages.Id AND Results.CompetitorId = 34;

SELECT * FROM Competitors WHERE Category = 'Women';
UPDATE Competitors SET Team = 'no club' WHERE StartNo = 1;

DELETE FROM Competitors WHERE StartNo = 1;
