SELECT * FROM Colaboradores 

SELECT * FROM PedidosColaboradores

SELECT * FROM Pedidos
SELECT * FROM Clientes
SELECT * FROM Itens
SELECT * FROM TiposConsertos

SELECT Colaboradores.Nome AS NomeColaborador, Colaboradores.Salario, Pedidos.NumeroEquipamento,Pedidos.Entrada,Pedidos.Saida, Clientes.Nome AS NomeCliente, Itens.Descricao AS Equipamento,TiposConsertos.Descricao AS DescriçãoConserto FROM PedidosColaboradores
INNER JOIN Colaboradores ON PedidosColaboradores.IdColaborador = Colaboradores.IdColaborador
INNER JOIN Pedidos ON PedidosColaboradores.IdPedido = Pedidos.IdPedido
INNER JOIN Clientes ON Pedidos.IdCliente = Clientes.IdCliente
INNER JOIN Itens ON Pedidos.IdItem = Itens.IdItem
INNER JOIN TiposConsertos ON Pedidos.IdTipo = TiposConsertos.IdTipo;

