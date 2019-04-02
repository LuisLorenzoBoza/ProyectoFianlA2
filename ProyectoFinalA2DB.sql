create database ProyectoFinalA2Db
go
use ProyectoFinalA2Db
go

Create Table Usuarios
(
	IdUsuario int primary key identity(1,1),
	Username varchar(30),
	Password varchar(8),
	Fecha date,
	Nombre varchar(max),
	Comentario varchar(max)
);

set dateformat dmy;
insert into Usuarios values('Luis','123','root','02/04/2019','Developer')

select * from Usuarios
go

Create Table Articulos
(
	IdArticulos int primary key identity(1,1),
	IdCategorias int,
	NombreArticulo varchar(max),
	Existencia int,
	Precio money
);

select * from Articulos
go



create table Clientes 
(
	IdCliente int primary key identity(1,1),
	Nombre varchar(30),
	Telefono varchar(15),
	Email varchar(15)
);

select * from Clientes
go

create table Facturas
(
	IdFactura int primary key identity(1,1),
	IdCliente int,
	IdUsuario int,
	Devuelta money,
	EfectivoRecibido money,
	Fecha date,
	Monto money,
	Observacion varchar(max),
	Cantidad money,
	
);

select * from Facturas
go

create table FacturaDetalles
(
	Id int primary key identity(1,1),
	FacturaId int,
	IdArt int,
	Cantidad int,
	NombreArticulo varchar(30),
	Precio money,
	Importe money

)

truncate table FacturaDetalle

select *from FacturaDetalles
select * from facturas



go
