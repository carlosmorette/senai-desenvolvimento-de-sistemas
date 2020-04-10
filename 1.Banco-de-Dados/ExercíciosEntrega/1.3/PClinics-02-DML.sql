USE PClinics_Manha;
SELECT * FROM Clinica;
SELECT * FROM TipoPet;
SELECT * FROM Dono;
SELECT * FROM Raca;
SELECT * FROM Atendimento;
SELECT * FROM Pet;

INSERT INTO Clinica(RazaoSocial , Endereco)
VALUES ('Petizinho Do Bem', 'Rua Abobora 132'),
	   ('Amigo do Pet', 'Rua Junqueira 432'),
	   ('Os Pets', 'Rua das Ameixas 78');

INSERT INTO Dono(Nome)
VALUES ('Robilson'),
	   ('Jadilson'),
	   ('Roberto'),
	   ('Andrade');

INSERT INTO TipoPet(Titulo)
VALUES ('Cachorro'),
	   ('Gato'),
	   ('Tartaruga'),
	   ('Passaro');


INSERT INTO Raca(IdTipoPet, Titulo)
VALUES	(1, 'Poddle');
		(2, 'Siamês'),
		(3, 'Tartaruga de Madeira'),
		(4, 'Canário');

INSERT INTO Pet(IdDono, IdRaca, Nome, Telefone)
VALUES (1, 3 , 'Fofo',	12245531);


INSERT INTO Atendimento (IdVet,IdPet,DataAtendimento,Descricao)
VALUES ()