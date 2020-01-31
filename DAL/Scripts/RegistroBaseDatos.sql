
use PersonasDb

create table Personas
(
	PersonaID int primary key identity,
	Nombre varchar(30),
	Telefono varchar(15),
	Cedula varchar(15),
	Direccion varchar(max),
	FechaNacimiento Date,
	Balance decimal
)

create table Inscripciones
(
	InscripcionId int primary key identity,
	Fecha Date,
	PersonaId int,
	Comentarios varchar(40),
	Monto decimal,
	Balance decimal,
	Deposito decimal
)

select * from Personas
select * from Inscripciones



