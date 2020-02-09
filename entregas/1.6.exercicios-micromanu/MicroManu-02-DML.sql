INSERT INTO Clientes(Nome) VALUES ('Carol'),('Saulo');
INSERT INTO Itens(Descricao) VALUES ('Computador'),('Notebook'),('Video game'),('Televisão'),('Celular');
INSERT INTO TiposConsertos(Descricao) VALUES ('Manutenção'),('Limpeza');
INSERT INTO Colaboradores(Nome,Salario) VALUES ('Henrique',200.00),('Juliano',280.00),('Fernando',100.00),('Sorocaba',500.00);
INSERT INTO Pedidos(NumeroEquipamento,Entrada,IdCliente,IdItem,IdTipo) VALUES ('555','2020-02-02',2,3,1),('123','2020-03-20',2,4,2);
INSERT INTO Pedidos(NumeroEquipamento,Entrada,Saida,IdCliente,IdItem,IdTipo) VALUES ('123','2020-01-01','2020-01-01',1,1,1);
INSERT INTO PedidosColaboradores(IdPedido,IdColaborador) VALUES (1,1),(2,2),(2,3);

