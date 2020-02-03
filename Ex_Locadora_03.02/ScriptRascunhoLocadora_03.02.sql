-- DDL
CREATE DATABASE LocadoraM;

USE LocadoraM;


CREATE TABLE Empresa(
IdEmpresa INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255) NOT NULL
);

CREATE TABLE Cliente(
IdCliente INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255) NOT NULL,
CPF VARCHAR(16) NOT NULL
);

CREATE TABLE Marca(
IdMarca INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255) NOT NULL
);

CREATE TABLE Modelo(
IdModelo INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255) NOT NULL,
IdMarca INT FOREIGN KEY REFERENCES  Marca(IdMarca) 
);

CREATE TABLE Veiculo(
IdVeiculo INT PRIMARY KEY IDENTITY,
Placa VARCHAR(10) NOT NULL,
IdEmpresa INT FOREIGN KEY REFERENCES Empresa(IdEmpresa),
IdModelo INT FOREIGN KEY REFERENCES Modelo(IdModelo)
);

CREATE TABLE Aluguel(
IdAluguel INT PRIMARY KEY IDENTITY,
DataInicio DATE NOT NULL,
DataFim DATE,
IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente),
IdVeiculo INT FOREIGN KEY REFERENCES Veiculo(IdVeiculo)
);

-- DML 
INSERT INTO EMPRESA(Nome) VALUES ('Wenceslau Automóveis'),('Rosana Automóveis'),('Armando Froz');

INSERT INTO Cliente(Nome, CPF) VALUES ('Amanda de Oliveira','333333333-33'),('Roberto Nihwsheg','222.222.222.22'),('Alberto de Nóbrega','11111111111'); 

INSERT INTO Marca(Nome) VALUES('Ford'),('Honda'),('Mercedes-Benz');

INSERT INTO Modelo(Nome,IdMarca) VALUES('Uno',1),('HB20',1),('Corsa Sedan',2);

INSERT INTO Veiculo(Placa,IdEmpresa,IdModelo) VALUES ('RIO02A1',1,1),('QWET12F3',1,3),('EBY9514',2,2);

INSERT INTO Aluguel(DataInicio,DataFim,IdCliente,IdVeiculo) VALUES ('01/02/2020','01/03/2001',1,1),('01/02/2020','01/03/2001',2,1);
INSERT INTO Aluguel(DataInicio,IdCliente,IdVeiculo) VALUES ('01/02/2020',2,3);





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


-- Exercício DML
-- DROP DATABASE LocadoraM;
-- DROP TABLE Aluguel;
-- DROP TABLE Veiculo;
-- DROP TABLE Marca; 
-- DROP TABLE Empresa;
-- DROP TABLE Cliente;
-- DROP TABLE Marca;
