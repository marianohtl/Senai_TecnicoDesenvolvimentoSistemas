INSERT INTO Lojas(Nome) VALUES ('SenaiShop');

INSERT INTO Clientes(Nome) VALUES ('Fernando'),('Helena');

INSERT INTO Categorias(Nome,IdLoja) VALUES ('Cursos',1),('Acessórios',1);

INSERT INTO Pedidos(NrPedido,DataPedido,StatusP,IdCliente) VALUES ('11111','2020-01-01','Em Andamento', 1),('22222','2020-02-02','Entregue', 2);

INSERT INTO Subcategorias(Nome,IdCategoria) VALUES ('Informática Básica',1),('Desenvolvimento',1),('Meio Ambiente',2),('Camisetas',2);

INSERT INTO Produtos(Nome,Valor,IdSubCategoria) VALUES ('Copo para Café',20.0,3),('Jaqueta',25.0,4),('Excel Básico',99.99,1),('C#',1.99,2);

INSERT INTO PedidosProdutos(IdPedido,IdProduto) VALUES (1,1), (1,2),(2,3),(2,4);
