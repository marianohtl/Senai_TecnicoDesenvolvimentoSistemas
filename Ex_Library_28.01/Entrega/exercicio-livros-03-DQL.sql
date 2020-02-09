-- DQL - COMANDOS DE CONSULTA
SELECT * FROM Autores;
SELECT * FROM Livros;
SELECT * FROM Generos;

-- � Selecionar todos os autores
SELECT NomeAutor FROM Autores;

-- �Selecionar todos os g�neros
SELECT Nome FROM Generos;

--�Selecionar todos os livros;
SELECT Titulo FROM Livros;

-- �Selecionar todos os livros e seus respectivos autores;
SELECT Titulo, IdAutor FROM Livros;
-- COM INNER JOIN 
SELECT Titulo, Autores.NomeAutor FROM Livros 
INNER JOIN Autores ON Livros.IdAutor = Autores.IdAutor;

-- �Selecionar todos os livros e seus respectivos g�neros;
SELECT Titulo, IdGenero FROM Livros;
-- COM INNER JOIN 
SELECT Titulo,Generos.Nome FROM Livros 
INNER JOIN Generos ON Livros.IdGenero = Generos.IdGenero;

--�Selecionar todos os livros e seus respectivos autores e g�neros;
SELECT Titulo, IdGenero, IdAutor FROM Livros;
-- COM INNER JOIN 

SELECT Titulo, Autores.NomeAutor, Generos.Nome FROM Livros
INNER JOIN Autores ON Livros.IdAutor = Autores.IdAutor
INNER JOIN Generos ON Livros.IdGenero = Generos.IdGenero;



