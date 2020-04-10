SELECT * FROM Aluguel;
SELECT * FROM Cliente;

SELECT Cliente.Nome, Aluguel.DataInicio, Aluguel.DataFim 
FROM Cliente INNER JOIN Aluguel ON Cliente.IdCliente = Aluguel.IdCliente