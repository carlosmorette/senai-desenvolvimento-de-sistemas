USE Filmes
GO

INSERT INTO Genero(NomeGenero)()
VALUES ('Romance'), 
	   ('Terror'),
	   ('Comedia')


INSERT INTO Filme(NomeFilme, DataLancamento, Diretor, IdGenero)
VALUES ('A volta dos que não foram', '1987-09-14', 'Carlos Alberto de Nobrega', 3),
	   ('Poeira em alto mar', '2002-07-14', 'Carlos Morette', 2)


INSERT INTO Usuario(Nome, Email, Senha, AdminUser)
VALUES ('Carlos Morette', 'carlos@email.com', 'carlinho', 1),
	   ('Erica Sobral', 'erica@email.com', 'erica', 0),
	   ('Henrique Barreiro', 'henrique@email.com', 'henrique', 0)