USE Filmes;
GO

SELECT * FROM Genero;

SELECT * FROM Filme;

SELECT Nome, Email, Senha,
CASE 
	WHEN AdminUser = 1 THEN 'Administrador'
	WHEN AdminUser = 0 THEN 'Comum'
	ELSE 'Usuario fora do comum'
END AS TipoUsuario
FROM Usuario;