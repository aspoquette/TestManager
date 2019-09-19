Create TABLE Companies(
Id Integer NOT NULL Identity Primary Key,
Number Integer,
StationsCompleted Integer
);
Create TABLE Stations(
Id Integer NOT NULL Identity Primary Key,
StationNumber varchar(255),
StationName varchar(255),
);

Create TABLE CompletedStations(
Id Integer NOT NULL Identity Primary Key,
StationId Integer FOREIGN KEY REFERENCES Stations(Id),
CompanyId Integer FOREIGN KEY REFERENCES Companies(Id),
);

Create TABLE Settings(
TestDate varchar(255),
TableVersion varchar(255),
DemoDataVersion varchar(255),
ClosedStatus varchar(255),
);
