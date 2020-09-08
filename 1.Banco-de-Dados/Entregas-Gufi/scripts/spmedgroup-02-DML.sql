USE SpMedGroup_Manha;

INSERT INTO TipoUsuario (Titulo)
VALUES ('Administrador'),
	   ('Paciente'),
	   ('Medico')
GO

INSERT INTO Especialidade (NomeEspecialidade)
VALUES	('Acupuntura'),
		('Anestesiologia'),
		('Angiologia'),
		('Cardiologia'),
		('Cirurgia Cardiovascular'),
		('Cirurgia da Mão'),
		('Cirurgia do Aparelho Digestivo'),
		('Cirurgia Geral'),
		('Cirurgia Pediátrica'),
		('Cirurgia Plástica'),
		('Cirurgia Torácica'),
		('Cirurgia Vascular'),
		('Dermatologia'),
		('Radioterapia'),
		('Urologia'),
		('Pediatria'),
		('Psiquiatria')
GO

SELECT * FROM TipoUsuario;
SELECT * FROM Especialidade;
SELECT * FROM Clinica;
SELECT * FROM Medico;
SELECT * FROM Usuario;
SELECT * FROM Consulta;

INSERT INTO Clinica (NomeFantasia, RazaoSocial, CNPJ,CEP, Bairro,Logradouro, Numero, HorarioAbre, HorarioFecha)
VALUES				('Clinica Possarle', 'SP Medical Group', '86400902000130','09660-050','Vila Cecilia','Av. Barão Limeira',432, '11:00:00', '18:00:00'),
					('Clinica Possarle', 'SP Medical Group', '86400902000430','09345-090', 'Vila Lobos','Av. Albuquerque', 5670, '11:00:00', '18:00:00')
GO

INSERT INTO Medico (IdEspecialidade, IdClinica, IdTipoUsuario, CRM, Nome, Email, Senha)
VALUES			   (4, 2, 3,'54356-SP','Ricardo Lemos', 'ricardo.lemos@spmedicalgroup.com.br', 'ricardinhomika'),
				   (14, 1, 3,'53452-SP', 'Roberto Possarle', 'roberto.possarle@spmedicalgroup.com.br','possarlinho123'),
				   (2, 1, 3, '65463-SP','Helena Strada','helena.souza@spmedicalgroup.com.br', 'helenana'),
				   (4,2,3,'	12345', 'Lucas Simplicio', 'simplicio@email.com', 'diademasimplicio123')
GO

INSERT INTO Usuario (IdTipoUsuario, Nome, Sexo, RG, CPF, Telefone, DataNascimento, Email, Senha, CEP, Bairro, Logradouro, Numero)
VALUES			    (1, 'Carlos Roberto', 'Masculino', '542294560','50912345609', '1196246-9873', '2002-07-14', 'carlos@email.com','carlosadm123','00000','Vila Harguesa','Rua Adm',2 ),
					(2, 'Maria Lurdes', 'Feminino', '345567650','12365468909', '2294567-1234','1954-09-09', 'maria.lurdes@email.com','marialuderdes123', '09668-123', 'Vila Matilde' ,'Rua das Mulheres', 123)
GO

INSERT INTO Consulta (IdUsuario, IdMedico, DataConsulta, Situacao, Descricao)
VALUES		(2,2,'03-03-2020 12:30:00', 'Confirmada','Paciente Doente'),
			(1,3,'03-03-2020 14:00:00','Pendente','Paciente Doido'),
			(2,1, '20-01-2020 11:25:00', 'Cancelada','Paciente Alcolizado');
GO