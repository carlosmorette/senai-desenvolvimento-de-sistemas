USE M_Peoples;
GO

SELECT * FROM Funcionario;
GO

-- Proc para Listar os funcionários
CREATE PROCEDURE listarFuncionarios
AS
SELECT * FROM Funcionario;

EXEC listarFuncionarios;


-- Proc para listar funcionario pelo ID
CREATE PROCEDURE listarFuncionarioPorId
@ID INT
AS 
SELECT * FROM Funcionario
WHERE Id_Funcionario = @ID;

EXEC listarFuncionarioPorId 2


-- Proc para listar funcionario pelo Nome
CREATE PROCEDURE listarFuncionarioPorNome
@Nome VARCHAR(200)
AS
SELECT * FROM Funcionario
WHERE Nome = @Nome;

EXEC listarFuncionarioPorNome Tadeu;

-- Proc para listar funcionario pelo Nome e Sobrenome
CREATE PROCEDURE listarFuncionarioPorNomeCompleto
AS
SELECT CONCAT(Nome,' ',Sobrenome) AS NomeCompleto FROM Funcionario

EXEC listarFuncionarioPorNomeCompleto;

-- TOKEN
SELECT * FROM TipoUsuario WHERE IdTipoUsuario = 1

SELECT * FROM Usuario;