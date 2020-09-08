USE SpMedGroup_Manha;


SELECT * FROM TipoUsuario;
SELECT * FROM Clinica;
SELECT * FROM Especialidade;
SELECT * FROM Medico;
SELECT * FROM Usuario;
SELECT * FROM Consulta;

-- Mostrando os nome do usuario e do medico
SELECT Usuario.Nome, Medico.Nome, Consulta.DataConsulta, Consulta.Situacao, Consulta.Descricao FROM Consulta
INNER JOIN Usuario ON Consulta.IdUsuario = Usuario.IdUsuario
INNER JOIN Medico ON Consulta.IdMedico = Medico.IdMedico

-- 11
-- Converteu a data de nascimento do usuário para o formato (mm-dd-yyyy)
SELECT CONVERT(VARCHAR(10), DataNascimento, 110) AS [MM/DD/YY]
FROM Usuario

-- Mostrou a quantidade de usuários
SELECT COUNT(IdUsuario) AS Quantidade_de_Usuarios FROM Usuario

-- 12
-- Criou uma função para retornar à quantidade de médicos de uma determinada especialidade
CREATE PROCEDURE RetornaMedicoEspecialidade
@ID INT
AS
SELECT Medico.CRM, Medico.Nome, Especialidade.NomeEspecialidade FROM Medico
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
WHERE Especialidade.IdEspecialidade = @ID

EXECUTE RetornaMedicoEspecialidade 4 -- Executando Procedure

-- Criou uma função para que retorne à idade do usuário a partir de uma determinada stored procedure
CREATE PROCEDURE RetornaIdade
@ID INT
AS
SELECT YEAR(GETDATE())-YEAR(DataNascimento)-IIF(MONTH(GETDATE())*32+DAY(GETDATE())<MONTH(DataNascimento)*32+DAY(DataNascimento),1,0) AS Idade
FROM Usuario
WHERE IdUsuario = @ID

EXECUTE RetornaIdade 1 -- Executando Procedure