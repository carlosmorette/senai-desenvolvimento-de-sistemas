USE M_Peoples;
GO

INSERT INTO Funcionario(Nome, Sobrenome)
VALUES ('Catarina', 'Strada'),
	   ('Tadeu', 'Vitelli');
GO

-- Proc para cadastrar funcionario
CREATE PROCEDURE cadastrarFuncionario
@Nome VARCHAR(200),
@Sobrenome VARCHAR(200)
AS
INSERT INTO Funcionario(Nome, Sobrenome)
VALUES (@Nome, @Sobrenome)

EXEC cadastrarFuncionario 'Adailton', 'Jubento';


-- Proc para atualizar funcionario
CREATE PROCEDURE atualizarFuncionario
@Nome VARCHAR(200),
@Sobrenome VARCHAR(200),
@ID INT
AS
UPDATE Funcionario SET
	Nome = @Nome,
	Sobrenome = @Sobrenome
WHERE Id_Funcionario = @ID;	

EXEC atualizarFuncionario 'Jow', 'asdas', 7

-- Proc para deletar funcionario
CREATE PROCEDURE deletarFuncionario
@ID INT
AS
DELETE FROM Funcionario
WHERE Id_Funcionario = @ID;

EXEC deletarFuncionario 7;

SELECT * FROM Funcionario;
SELECT * FROM Usuario;
SELECT * FROM TipoUsuario;


-- TOKEN
INSERT INTO TipoUsuario (Titulo)
VALUES ('Administrador'),
	   ('Comum');

INSERT INTO Usuario (Nome, Email, Senha, IdTipoUsuario)
VALUES ('Admilson', 'admilson@email.com', 'admilson123', 1),
	   ('Carlos','carlos@email.com', 'carlao123', 2);

INSERT INTO Usuario (Nome, Email, Senha, IdTipoUsuario) VALUES (@Nome, @Email, @Senha, @Id)

UPDATE TipoUsuario SET Titulo = 'Vendedor' WHERE IdTipoUsuario = 3

UPDATE Usuario SET
	Nome = 'Adailton',
	Email = 'adailton@email.com',
	Senha = '123adailton@asd',
	IdTipoUsuario = 2
WHERE IdUsuario = 1;

DELETE FROM TipoUsuario WHERE IdTipoUsuario = 3

DELETE FROM Usuario WHERE IdUsuario = 3

SELECT * FROM Usuario WHERE IdUsuario = 2

SELECT * FROM Usuario WHERE Email = 'teste@teste.com' AND Senha = '123teste'
