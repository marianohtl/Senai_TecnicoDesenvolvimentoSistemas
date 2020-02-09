use ECommerce

SELECT * FROM Pedidos
SELECT * FROM Clientes

SELECT * FROM PedidosProdutos

SELECT * FROM Produtos
SELECT * FROM Subcategorias
SELECT * FROM Categorias
SELECT * FROM Lojas


SELECT Pedidos.NrPedido, Pedidos.DataPedido, Pedidos.StatusP AS StatusPedido, Clientes.Nome AS NomeCLiente, Produtos.Nome AS NomeProduto ,Produtos.Valor AS Preço,Subcategorias.Nome AS SubCategoria, Categorias.Nome AS Categoria, Lojas.Nome AS Loja FROM PedidosProdutos
INNER JOIN Pedidos ON PedidosProdutos.IdPedido = Pedidos.IdPedido
INNER JOIN Clientes ON Pedidos.IdCliente = Clientes.IdCliente
INNER JOIN Produtos ON PedidosProdutos.IdProduto = Produtos.IdProduto
INNER JOIN Subcategorias ON Produtos.IdSubcategoria = Subcategorias.IdSubcategoria
INNER JOIN Categorias ON Subcategorias.IdCategoria = Categorias.IdCategoria
INNER JOIN Lojas ON Categorias.IdLoja = Lojas.IdLoja;



