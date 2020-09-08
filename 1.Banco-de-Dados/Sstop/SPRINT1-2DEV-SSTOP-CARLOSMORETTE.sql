CREATE DATABASE SstopMusicas_Manha;

USE SstopMusicas_Manha;

CREATE TABLE EstiloMusical(
	IdEstiloMusical 	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200) NOT NULL,
);

CREATE TABLE Artistas(
	IdArtistas 	INT PRIMARY KEY IDENTITY,
	Nome	   	VARCHAR(200),
	IdEstiloMusical INT FOREIGN KEY REFERENCES EstiloMusical (IdEstiloMusical),
);

-- Adicionando nova Coluna
ALTER TABLE EstiloMusical
ADD Descricao VARCHAR(200);


--DML Linguagem de Manipulacao de Dados
-- INSERT
INSERT INTO EstiloMusical(Nome, Descricao)
VALUES	('Samba', 'Musica Brasileira'),
		('Jazz', 'Estilo top'),
		('Pop', 'Estilo popular')

INSERT INTO Artistas(Nome,IdEstiloMusical)
VALUES ('Zeca Pagodinho', 2),
		('Frank Sinatra', 3);

INSERT INTO Artistas(Nome, IdEstiloMusical)
VALUES ('Zeca Pagodinho', 1)

SELECT * FROM EstiloMusical
SELECT * FROM Artistas

-- UPDATE
UPDATE Artistas SET
	Nome='Frank Sinatra'
WHERE IdArtistas=2;

-- DELETE
DELETE FROM Artistas
WHERE IdArtistas = 1;

-- DDL
-- Alteracao: Adicionar coluna
ALTER TABLE Artistas
ADD DataNascimento DATE;

-- Alteracao: Modificar coluna
ALTER TABLE Artistas
ALTER COLUMN Nome VARCHAR(200);

-- Alteracao: Excluir coluna
ALTER TABLE Artistas
DROP COLUMN DataNascimento;

-- Alteracao: Apagar 
DROP TABLE EstiloMusical -- Não possivel pois tem uma chave estrangeira
DROP TABLE Artistas

-- Excluir banco de dados
DROP DATABASE SstopMusicas_Manha;