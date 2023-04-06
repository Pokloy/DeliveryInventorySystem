Create Database CardinalInventoryDB;



Create Table DeliveryTable.CardinalInventoryDB(
DeliveryID int Identity(1,1), 
RequestProd varchar(255),
DeliveryDate varchar(255),
DeliveryStats varchar(255),
Remarks varchar(255)
);


Create Table ProdInfo(
ProductID int Identity(1,1), 
SerialNo varchar(255),
ProductName varchar(255),
ProductType varchar(255),
ProductExpiry varchar(255),
ProductManufac varchar(255)
);

Create Table Users(
UserID int, 
UserType varchar(255),
Username varchar(255),
Password varchar(255),
RQuestion varchar(255),
RAnswer varchar(255)
);