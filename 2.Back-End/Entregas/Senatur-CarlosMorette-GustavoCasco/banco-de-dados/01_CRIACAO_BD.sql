CREATE DATABASE Senatur_Manha;
GO

USE Senatur_Manha;
GO

CREATE TABLE Pacotes (
	IdPacote INT PRIMARY KEY IDENTITY,
	NomePacote VARCHAR(200),
	Descricao TEXT,
	DataIda DATE,
	DataVolta DATE,
	Valor DECIMAL (18,2),
	Ativo BIT DEFAULT 0,
	NomeCidade VARCHAR(200)
);
GO

CREATE TABLE TipoUsuario(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(200)
);
GO

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(200),
	Senha VARCHAR(200),
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);
GO