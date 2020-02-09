-- DML 
INSERT INTO EMPRESA(Nome) VALUES ('Wenceslau Automóveis'),('Rosana Automóveis'),('Armando Froz');

INSERT INTO Cliente(Nome, CPF) VALUES ('Amanda de Oliveira','333333333-33'),('Roberto Nihwsheg','222.222.222.22'),('Alberto de Nóbrega','11111111111'); 

INSERT INTO Marca(Nome) VALUES('Ford'),('Honda'),('Mercedes-Benz');

INSERT INTO Modelo(Nome,IdMarca) VALUES('Uno',1),('HB20',1),('Corsa Sedan',2);

INSERT INTO Veiculo(Placa,IdEmpresa,IdModelo) VALUES ('RIO02A1',1,1),('QWET12F3',1,3),('EBY9514',2,2);

INSERT INTO Aluguel(DataInicio,DataFim,IdCliente,IdVeiculo) VALUES ('01/02/2020','01/03/2001',1,1),('01/02/2020','01/03/2001',2,1);
INSERT INTO Aluguel(DataInicio,IdCliente,IdVeiculo) VALUES ('01/02/2020',2,3);


-- DROP DATABASE LocadoraM;

-- DROP TABLE Aluguel;
-- DROP TABLE Veiculo;
-- DROP TABLE Marca; 
-- DROP TABLE Empresa;
-- DROP TABLE Cliente;
-- DROP TABLE Marca;

