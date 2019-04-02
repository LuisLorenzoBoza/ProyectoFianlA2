create database ProyectoFinalA2Db
go

use ProyectoFinalA2Db
go



Create Table Usuarios
(
	IdUsuario int primary key identity(1,1),
	Nombres varchar(max),
	Contraseña varchar(10),
	Fecha date,
	NombreUsuario varchar(max),
	TipoUsuario varchar(10)

);

set dateformat dmy;
insert into Usuarios values('Luis Lorenzo','123','04/02/2019','Luiso','Admin')

select * from Usuarios
go

Create Table Productos
(
	ProductoId int primary key identity(1,1),
    NombreProducto varchar(max),
	Precio money,
	Descripcion varchar(15),
	Fecha date
);

select * from Productos
go



create table ProductosDetalle
(
	ProductosDetalleId int primary key identity(1,1),
	ProductoId int,
	NombreProducto varchar(30),
	Precio money,
	Descripcion varchar(30)
);

select * from ProductosDetalle
go

create table Ventas
(
	VentaId int primary key identity(1,1),
	TotalAPagar money,
	Efectivo money,
	Devuelta money,
	Fecha date
	
);

select * from Ventas
go

create table VentaProductosDetalles
(
	VentaProductosDetallesId int primary key identity(1,1),
	VentaId int,
	NombreProducto varchar(30),
	Precio money, 
	Descripcion varchar(30)

);

select * from VentaProductosDetalles
go

--truncate table VentaProductosDetalles

--select *from FacturaDetalles
--select * from facturas




