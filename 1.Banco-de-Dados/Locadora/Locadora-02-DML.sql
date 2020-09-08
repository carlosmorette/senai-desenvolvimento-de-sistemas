USE Locadora;

INSERT INTO Cliente(Nome, CPF)
VALUES('Carlos Morette', 12365478965),
	  ('Albuquerque Barreira', 32145632145);

INSERT INTO Empresa(Nome)
VALUES ('Cristal do ABC'),
	   ('Agua Raza Magnum');

INSERT INTO Marca(Nome)
VALUES ('Chevrolet'),
	   ('Volkswagen'),
	   ('Ford'),
	   ('FIAT');

INSERT INTO Modelo(IdMarca, Nome)
VALUES (1, 'Montana'),
	   (2, 'Santana'),
	   (3, 'Ka'),
	   (4, 'Weekend');

INSERT INTO Veiculo (IdEmpresa, IdModelo)
VALUES (1,3),
	   (2,4),
	   (1,2),
	   (2,1);

INSERT INTO Aluguel (IdCliente,IdVeiculo,DataInicio, DataFim)
VALUES (7, 2, '2020-01-02', '2020-01-20'),
	   (8,4, '2020-01-03', '2020-01-19');