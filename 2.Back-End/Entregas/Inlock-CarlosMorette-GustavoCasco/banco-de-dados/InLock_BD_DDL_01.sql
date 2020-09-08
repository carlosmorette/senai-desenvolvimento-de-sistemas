
-- Criação da estrutura do banco
CREATE DATABASE  InLock_Games_Manha;
GO

USE InLock_Games_Manha;
GO

CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(200) UNIQUE
);
GO

CREATE TABLE Estudio(
	IdEstudio INT PRIMARY KEY IDENTITY,
	NomeEstudio VARCHAR(200)
);
GO

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(200) UNIQUE,
	Senha VARCHAR(100),
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
);
GO

CREATE TABLE Jogo(
	IdJogo INT PRIMARY KEY IDENTITY,
	NomeJogo VARCHAR(200),
	Descricao VARCHAR(MAX),
	DataLancamento DATE,
	Valor DECIMAL(10,2),
	IdEstudio INT FOREIGN KEY REFERENCES Estudio(IdEstudio)
);
GO