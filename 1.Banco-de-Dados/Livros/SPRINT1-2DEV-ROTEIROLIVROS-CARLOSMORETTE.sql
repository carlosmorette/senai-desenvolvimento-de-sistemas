-- Comando para criar banco de dados
CREATE DATABASE RoteiroLivros;

-- Usar o banco de dados
USE RoteiroLivros;

-- Criar tabela (entidade)
CREATE TABLE Genero (
	IdGenero INT PRIMARY KEY IDENTITY NOT NULL,
	Nome	 VARCHAR(200) NOT NULL,
);

CREATE TABLE Autores (
	IdAutor	  INT PRIMARY KEY IDENTITY,
	NomeAutor VARCHAR(200)
);

CREATE TABLE Livros (
	IdLivro  INT PRIMARY KEY IDENTITY,
	Titulo	 VARCHAR(255),
	IdGenero INT FOREIGN KEY REFERENCES Genero (IdGenero),
	IdAutor  INT FOREIGN KEY REFERENCES Autores(IdAutor)
);

-- DQL comando de consulta
SELECT * FROM Genero;
SELECT * FROM Autores;
SELECT * FROM Livros;

-- DML
-- Inserindo dados
INSERT INTO Genero(Nome)
VALUES  ('Romance'),
		('Aventura'),
		('Suspense'),
		('Desenvolvimento Pessoal'),
		('Terror');

INSERT INTO Autores(NomeAutor)
VALUES	('Stephen King'),
		('Brian Selznick'),
		('John Green'),
		('Robert Greene'),
		('Jussi Adler-Olsen')

INSERT INTO Livros(Titulo, IdGenero,IdAutor)
VALUES ('48 Leis do Poder',4,4 ),
		('A Caça', 5,5),
		('It a Coisa', 7,1),
		('A invenção de Hugo Cabret',4,2),
		('A culpa é das estrelas',3,3);


-- Alterar o nome de um Genero
UPDATE Genero SET
	Nome= 'Erotico'
WHERE IdGenero=3;

-- Alterar o Genero de um Livro
UPDATE Livros SET
	IdGenero= 3
WHERE IdLivro = 4;

-- Apagar um Autor
INSERT INTO Autores(NomeAutor)
VALUES('Desconhecido');

DELETE FROM Autores
WHERE IdAutor=6

SELECT * FROM Livros;

-- Limpa todos os dados da tabela
TRUNCATE TABLE Livros;

-- Apagar mais de um ID
DELETE FROM Livros
WHERE IdLivro BETWEEN 1 AND 3;

-- Alterar mais de um ID
UPDATE Livros SET
	Titulo = 'A volta dos que não foram'
WHERE IdLivro BETWEEN 4 AND 6;

SELECT * FROM Livros;

-- Alterando varios dados de uma linha
UPDATE Livros SET
	Titulo= 'A invenção de Hubo Cabrero',
	IdGenero = 5
WHERE IdLivro = 4;

-- DQL
-- Selecione todos os autores, generos, livros
SELECT * FROM Autores;
SELECT * FROM Genero;
SELECT * FROM Livros;

-- Selecionar todos os livros e seus respectivos Autores
SELECT * FROM Livros WHERE IdAutor = 3;

-- Selecionar todos os livros e seus respectivos Generos
SELECT * FROM Livros WHERE IdGenero = 4;

-- Selecionar todos os livros e seus respectivos autores e generos
SELECT * FROM Livros
WHERE (IdGenero = 5) AND (IdAutor = 5);

-- Selecionar mais de um ID
SELECT * FROM Livros 
WHERE IdLivro IN (4,5,6,7);