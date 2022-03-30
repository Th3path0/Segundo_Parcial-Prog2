-- creaccion de BD
Create Database Agenda2;

-- Creación de tabla
Create Table Agenda(
IDcontacto int identity(1,1)primary key not null,
Nombre Nvarchar(30),
Apellido Nvarchar(30) not null,
Celular int,
Fecha_nacimiento datetime

);


-- Insert
Insert Into Agenda VALUES('Juan','Guarnizo','8290012','2022-03-30');

-- select
Select * from Agenda;

--Store Procedure
--1- Buscar
Create PROC SP_BuscarContacto
@Buscar Nvarchar(25)
AS
Select * From Agenda
Where Nombre Like @Buscar + '%'

go

--Insertar
Create PROC SP_InsertarContacto
@Nombre Nvarchar(30),
@Apellido Nvarchar(30),
@Celular int,
@Fecha_nacimiento datetime
AS
Insert Into Agenda Values (@Nombre, @Apellido, @Celular, @Fecha_nacimiento)
 
 go

--Editar
Create PROC SP_editarContacto
@IDcontacto INT,
@Nombre Nvarchar(30),
@Apellido Nvarchar(30),
@Celular int,
@Fecha_nacimiento datetime
AS
Update Agenda Set Nombre = @Nombre, Apellido = @Apellido, Celular = @Celular, Fecha_nacimiento=@Fecha_nacimiento
WHERE IDcontacto= @IDcontacto


go

--SP Eliminar
Create PROC SP_eliminarContacto
@IDcontacto INT
AS
Delete Agenda
WHERE IDcontacto = @IDcontacto


