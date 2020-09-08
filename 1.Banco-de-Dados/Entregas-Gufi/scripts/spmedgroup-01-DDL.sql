-- Criação do banco
CREATE DATABASE SpMedGroup_Manha;
GO

USE SpMedGroup_Manha;
GO

-- Region
-- Criacação das tabelas
CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR (200) UNIQUE
);
GO

CREATE TABLE Especialidade (
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	NomeEspecialidade VARCHAR (200)
);
GO

CREATE TABLE Clinica (
	IdClinica INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(200),
	RazaoSocial VARCHAR(200),
	CNPJ VARCHAR(20),
	CEP VARCHAR(30),
	Bairro VARCHAR (200),
	Logradouro VARCHAR (255),
	Numero INT,
	HorarioAbre TIME,
	HorarioFecha TIME,
);
GO

CREATE TABLE Medico (
	IdMedico INT PRIMARY KEY IDENTITY,
	IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade (IdEspecialidade),
	IdClinica INT FOREIGN KEY REFERENCES Clinica (IdClinica),
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario),
	CRM VARCHAR(20),
	Nome VARCHAR(200),
	Email VARCHAR(200) UNIQUE,
	Senha VARCHAR(200)
);
GO

CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario),
	Nome VARCHAR(200),
	Sexo VARCHAR (200),
	RG VARCHAR(40),
	CPF VARCHAR(40),
	Telefone VARCHAR(20),
	DataNascimento DATE,
	Email VARCHAR(200) UNIQUE,
	Senha VARCHAR (200),
	CEP VARCHAR (30),
	Bairro VARCHAR (200),
	Logradouro VARCHAR(255),
	Numero INT
);
GO

CREATE TABLE Consulta (
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
	IdMedico INT FOREIGN KEY REFERENCES Medico (IdMedico),
	DataConsulta DATETIME2,
	Situacao VARCHAR(200),
	Descricao VARCHAR (MAX)
);
GO