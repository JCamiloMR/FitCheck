
create database FitCheck;
use FitCheck;

create table Usuarios (
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Cedula VARCHAR(20) UNIQUE NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Contrasena VARCHAR(MAX) NOT NULL,
	Edad INT NOT NULL,
	Rol VARCHAR(100) NOT NULL
);


alter table Usuarios add Edad int, Rol varchar(100)

select * from Usuarios

drop table Usuarios