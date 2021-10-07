create database PolicyDB

use PolicyDB


create table Consumer
(
ConsumerId int Identity(1,1) Primary Key,
ConsumerName varchar(100) not NULL,
DateOfBirth datetime not NULL,
Email varchar(100) not NULL,
PanNumber varchar(100) not NULL,
AgentId int not NULL,
AgentName varchar(100) not NULL
);

create table BusinessMaster
(
BusinessMasterId int Identity(1,1) Primary Key,
BusinessValue int not NULL,
BusinessTurnOver int not NULL,
CapitalInvest int not NULL
);


create table PropertyMaster
(
PropertyMasterId int Identity(1,1) Primary Key,
CostOfAssest int not NULL,
SalvageValue int not NULL,
UsefulLifeOfAssest int not NULL,
PropertyValue int not NULL
);

create table Business
(
BusinessId int Identity(1,1) Primary Key,
BusinessName varchar(100) not NULL,
BusinessType varchar(100) not NULL,
TotalEmployees int not NULL,
BusinessMasterId int not NULL FOREIGN KEY REFERENCES [BusinessMaster](BusinessMasterId),
ConsumerId int not NULL FOREIGN KEY REFERENCES [Consumer](ConsumerId)
);

create table Property
(
PropertyId int Identity(1,1) Primary Key,
BuildingType varchar(100) not NULL,
BuildingStoreys int not NULL,
BuildingAge int not NULL,
BusinessId int not NULL FOREIGN KEY REFERENCES [Business](BusinessId),
PropertyMasterId int not NULL FOREIGN KEY REFERENCES [PropertyMaster](PropertyMasterId)
);

create table PolicyMaster
(
PolicyMasterId int Identity(1,1) Primary Key,
PropertyType varchar(255) not null,
ConsumerType varchar(255) not null,
AssuredSum decimal(10,3) not null,
Tenure int not null,
BusinesssValue int not null,
PropertyValue int not null,
BaseLocation varchar(255) not null,
PolicyType varchar(255) not null
);

create table Quote
(
QuoteId int Identity(1,1) Primary Key,
PropertyValueFrom int not null,
PropertyValueTo int not null,
BusinesssValueFrom  int not null,
BusinesssValueTo int not null,
PropertyType varchar(50) not null,
QuoteValue decimal(8,2) not null
);

create table ConsumerPolicy
(
PolicyId int Identity(1,1) Primary Key,
PropertyId int not null FOREIGN KEY REFERENCES [Property](PropertyId),
QuoteId int not null FOREIGN KEY REFERENCES [Quote](QuoteId),
PolicyStatus varchar(255) not null,
PolicyMasterId int not null FOREIGN KEY REFERENCES [PolicyMaster](PolicyMasterId)
);


INSERT INTO Consumer (ConsumerName, DateOfBirth, Email, PanNumber, AgentId, AgentName)
VALUES 
('Vamshi','2000-01-01', 'vamshi@gmail.com', 'VAMSHI1234Q', 1, 'RajKumar'),
('Sathvik','2000-02-01', 'sathvik@gmail.com', 'SATHVIK1234Q', 4, 'RajKumar'),
( 'Shivangi','2000-03-01', 'shivangi@gmail.com', 'SHIVANGI1234Q', 1, 'RajKumar'),
( 'Vasavi','2000-04-01', 'vasavi@gmail.com', 'VASAVI1234Q', 3, 'RajKumar'),
( 'Ram','2000-05-01', 'ram@gmail.com', 'RAM1234Q', 2, 'RajKumar');

INSERT INTO BusinessMaster (BusinessValue,BusinessTurnOver,CapitalInvest)
VALUES 
(5,50000,5000),
(2,30000,4000),
(4,40000,8000),
(7,70000,7000),
(4,45000,4500),
(6,65000,6500),
(8,65000,6500);

INSERT INTO PropertyMaster(CostOfAssest,SalvageValue,UsefulLifeOfAssest,PropertyValue)
VALUES 
(50000,5000,30000,4),
(70000,2000,40000,5),
(70000,1000,30000,1),
(40000,8000,70000,2),
(50000,6000,90000,7),
(30000,1000,60000,9);

INSERT INTO Business(BusinessName,BusinessType,TotalEmployees,BusinessMasterId,ConsumerId)
VALUES 
('Ram Stores','SoleProprietorship',15,1,3),
('Pk Mart','SoleProprietorship',20,2,2),
('Kr Mart','SoleProprietorship',60,3,2),
('Mayank BookStore','SoleProprietorship',40,4,4),
('May Hospital','SoleProprietorship',180,2,2),
('Mankind Store','SoleProprietorship',40,7,4),
('Raul Shop','Patnership',75,5,1),
('Yrk Stores','Patnership',100,6,2);

INSERT INTO Property(BuildingType,BuildingStoreys,BuildingAge,BusinessId,PropertyMasterId)
VALUES
('Office Building',5,3,1,1),
('Factory',5,1,1,5),
('Industrial Building',10,3,2,2),
('Mill',5,1,2,6),
('Warehouse',6,4,3,3),
('BookStore',6,2,3,5),
('Factory',2,9,4,5),
('Office Building',4,6,4,4);


insert into [PolicyMaster](PropertyType, ConsumerType, AssuredSum, Tenure, BusinesssValue, 
PropertyValue, BaseLocation, PolicyType) values
('Building','Owner',2000000,3,8,5,'Chennai','Replacement'),
('Mill','Owner',2000000,4,2,5,'Chennai','Replacement'),
('Hospital','Owner',2000000,5,7,4,'Chennai','Replacement'),
('School','Owner',2000000,2,4,9,'Chennai','Replacement'),
('BookStore','Owner',2000000,6,4,5,'Chennai','Replacement'),
('Factory Equipment','Owner',400000,1,7,6,'Chennai','Replacement'),
('Property in Transit','Owner',200000,1,7,9,'Pune','Pay Back'),
('Property','Owner',200000,1,9,9,'Pune','Pay Back'),
('Building','Owner',500000,1,3,3,'Kolkata','Pay Back');

insert into [Quote](PropertyValueFrom, PropertyValueTo, BusinesssValueFrom,
BusinesssValueTo, PropertyType, QuoteValue) values
(0,2,0,2,'Equipment',30000),
(3,5,3,5,'Equipment',50000),
(6,8,6,8,'Equipment',70000),
(9,10,9,10,'Equipment',90000),
(3,5,0,2,'Equipment',40000),
(0,2,3,5,'Equipment',40000),
(3,5,6,8,'Equipment',60000),
(3,5,9,10,'Equipment',80000);


insert into ConsumerPolicy(PropertyId, QuoteID, PolicyStatus, PolicyMasterId) values
(1,2,'Initiated',2);

select * from Consumer
select * from BusinessMaster
select * from PropertyMaster
select * from Business
select * from Property
select * from PolicyMaster
select * from Quote
select * from ConsumerPolicy

-- delete from Consumer


--insert into [Consumer] values(1,'Raj','20120618 10:34:09 AM','raj@email.com','ABCDEF1234',1,'Vinod');
--insert into [Consumer] values(2,'Ram','20120920 11:12:13 AM','ram@email.com','BCDEFG1234',1,'Vinod');

--insert into BusinessMaster values(1,8,'Replacement',4,10000);
--insert into BusinessMaster values(2,5,'Replacement',2,20000);

--insert into PropertyMaster values(1,80000,50000,5,5);
--insert into PropertyMaster values(2,100000,70000,5,8);

--insert into Property values(1,'Replacement',5,10,1);
--insert into Property values(2,'Replacement',8,7,2);

--insert into Business values(1,'Goods',5000,'Replacement',50000,1,1,1);
--insert into Business values(2,'Coal',10000,'Replacement',100000,2,1,2);

