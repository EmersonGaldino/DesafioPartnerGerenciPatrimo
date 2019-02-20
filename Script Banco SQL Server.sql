use master;

CREATE TABLE Marca (
    MarcaId int,
    Nome varchar(255)
);

CREATE TABLE Patrimonio (
    PatrimonioId int,
	Nome varchar(255),
	MarcaId int,
    Descricao varchar(255),
	NrTombo int
);