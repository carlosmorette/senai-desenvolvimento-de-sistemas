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