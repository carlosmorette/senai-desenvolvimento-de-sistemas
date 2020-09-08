USE InLock_Games_Manha;

-- Alimentando as tabelas
INSERT INTO TipoUsuario(Titulo)
VALUES ('Administrador'),
	   ('Cliente')
GO

INSERT INTO Usuario(Email,Senha,IdTipoUsuario)
VALUES ('admin@admin.com', 'admin', 1),
       ('cliente@cliente.com', 'cliente', 2)
GO

INSERT INTO Estudio(NomeEstudio)
VALUES ('Blizzard'),
	   ('Rockstar Studios'),
	   ('Square Enix')
GO

INSERT INTO Jogo(NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)
VALUES ('Diablo 3', ' é um jogo que contém bastante ação e é
viciante, seja você um novato ou um fã', '2012-05-15', 99.00, 1),
	   ('Red Dead Redemption II', 'jogo eletrônico de ação-aventura western', '2018-10-26', 120, 2)
GO

SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;
SELECT * FROM Estudio;
SELECT * FROM Jogo;