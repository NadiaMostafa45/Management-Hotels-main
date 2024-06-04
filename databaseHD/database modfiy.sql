use HotelManagement
Go
create schema  Hotel_Service;
Go

CREATE TABLE Hotel_Service.Staffs (
  staffId INT ,
  salary INT,
  firstName VARCHAR (50) ,
  lastName VARCHAR (50) ,
  email VARCHAR (255) NOT NULL ,
  phone VARCHAR (25),
 password VARCHAR(255),
username VARCHAR(255),
  position varchar(20),
  departmentType varchar(20),
  image VARCHAR(255),
  constraint staffsPk primary key (staffId),
  constraint staffsUq unique (email),
 
 );
CREATE TABLE Hotel_Service.Room(
 roomId INT  ,
  roomType  VARCHAR(20),
  price int,
  roomSize VARCHAR(255),
  maintenanceState VARCHAR (255),
 cleaningState VARCHAR (50),
  reservationState VARCHAR (50),
  constraint roomPk primary key(roomId)
);
CREATE TABLE Hotel_Service.Customer(
 customerId INT  ,
  roomId INT,
  customerName  VARCHAR(20),
  customerAge int ,
  customerType varchar(50),
  phone varchar(50),
  constraint customerPk primary key(customerId),
  constraint customerFk foreign key (roomId) references Hotel_Service.Room (roomId)
);
create table Hotel_Service.customerRoom
( duration int,startReservation Date,finishReservation Date,customerId int references Hotel_Service.Customer (customerId ),
roomId int references Hotel_Service.Room(  roomId ),
primary key(roomId,customerId));

create TABLE Hotel_Service.StaffRoom(
roomId int references Hotel_Service.Room(roomId ),
staffId int references Hotel_Service.Staffs (staffId  ),
primary key(roomId,staffId));