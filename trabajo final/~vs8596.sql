CREATE DATABASE ITLA
GO
USE  ITLA
go
Create Table Users(
UserID int identity(1,1) primary key,
LoginName Nvarchar(100) unique not null,
Password Nvarchar(100) not null,
FirtName Nvarchar (100)not null,
LastName Nvarchar (100) not null,
Position Nvarchar (100) not null,
Email Nvarchar (150) not null
)
insert into Users values ('Kathy','abc123456','Kathrine','Smith','CFO','KathySmith@MyCompany.com')
insert into Users values ('admin','admin','Eudy','Gonzalez','Position','Eudygonzalezvizcaino@gmail.com')
insert into Users values ('Ben','abc123456','Benjamin','Thompson','Manager','BenThompson@MyCompany.com')

select * from Users
go

create proc SP_Login
@user Nvarchar(100),
@Pass Nvarchar(100)
as

Select * from Users where LoginName=@user and Password=@Pass

go

create proc SP_Recuperar
@user Nvarchar(100),
@mail Nvarchar(100)
as

Select * from Users where LoginName=@user and Email=@mail


go
 create proc SP_actualizar
@userName Nvarchar(100),
@Pass Nvarchar(100),
@name Nvarchar (100),
@lastName Nvarchar (100),
@mail Nvarchar (150),
@id int 
 as
update Users set LoginName= @userName,Password=@pass,FirtName=@name,LastName=@lastName,Email=@mail where UserID=@id

go
create proc SP_insertar 
@userName Nvarchar(100),
@Pass Nvarchar(100),
@name Nvarchar (100),
@lastName Nvarchar (100),
@Position Nvarchar (100),
@mail Nvarchar (150)
as
insert into Users values (@userName,@Pass,@name,@lastName,@Position,@mail)

Create Table Users(
UserID reference 
LoginName Nvarchar(100) unique not null,
Password Nvarchar(100) not null,
FirtName Nvarchar (100)not null,
LastName Nvarchar (100) not null,
Position Nvarchar (100) not null,
Email Nvarchar (150) not null
)