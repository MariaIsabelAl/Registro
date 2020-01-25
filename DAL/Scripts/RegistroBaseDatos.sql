use PersonasDb

create table Personas
(
	ID int primary key identity,
	Nombre varchar(30),
	Telefono varchar(15),
	Cedula varchar(15),
	Direccion varchar(max)
)
