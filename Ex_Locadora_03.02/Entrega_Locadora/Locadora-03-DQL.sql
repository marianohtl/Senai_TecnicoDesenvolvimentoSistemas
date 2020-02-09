-- DQL 
--  Exibir todos os alugueis com seus respectivos campos preenchidos (sem ID)
SELECT DataInicio AS Data_Início_Contratação ,DataFim AS Data_Fim_Contratação,Cliente.Nome AS Nome_Cliente,Cliente.CPF AS CPF_Cliente, Veiculo.Placa AS Placa_Veiculo, Modelo.Nome AS Modelo_Veiculo, Marca.Nome AS Marca_Veiculo FROM Aluguel 
INNER JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente 
INNER JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo
INNER JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo
INNER JOIN Marca ON Modelo.IdMarca = Marca.IdMarca;

SELECT * FROM Aluguel;
SELECT * FROM Veiculo;
SELECT * FROM Marca;
SELECT * FROM Empresa;
SELECT * FROM Cliente;
SELECT * FROM Marca;

