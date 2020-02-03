/*
DML 
�Inserir no m�nimo 5 dados em cada tabela
�Alterar Nome de um G�nero
�Alterar G�nero de um Livro
�Apagar um Autor
DQL
�Selecionar todos os autores;
�Selecionar todos os g�neros;
�Selecionar todos os livros;
�Selecionar todos os livros e seus respectivos autores;
�Selecionar todos os livros e seus respectivos g�neros;
�Selecionar todos os livros e seus respectivos autores e g�neros;
*/

-- DDL - COMANDOS DE CRIA��O
CREATE DATABASE RoteiroLivros;

USE RoteiroLivros;

CREATE TABLE Generos(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome varchar(200) NOT NULL
);


CREATE TABLE Autores(
	IdAutor INT PRIMARY KEY IDENTITY,
	NomeAutor varchar(200)
);

CREATE TABLE Livros(
	IdLivro INT PRIMARY KEY IDENTITY,
	Titulo varchar(255),
	IdGenero INT FOREIGN KEY REFERENCES Generos(IdGenero),
	IdAutor INT FOREIGN KEY REFERENCES Autores(IdAutor)
);

-- DML - COMANDOS DE MANIPULA��O

-- Inserir 5 dados em cada tabela

-- 1.Autores
INSERT INTO Autores(NomeAutor)
VALUES ('Monteiro Lobato');

INSERT INTO Autores(NomeAutor)
VALUES ('Stephen king');

INSERT INTO Autores(NomeAutor)
VALUES ('Jos� de Alencar');

INSERT INTO Autores(NomeAutor)
VALUES ('Cec�lia Meireles');

INSERT INTO Autores(NomeAutor)
VALUES ('Carlos Drummond de Andrade');


-- 2.Generos
INSERT INTO Generos(Nome)
VALUES ('INFANTIL');

INSERT INTO Generos(Nome)
VALUES ('ROMANCE');

INSERT INTO Generos(Nome)
VALUES ('TERROR');

INSERT INTO Generos(Nome)
VALUES ('TERROR++');

INSERT INTO Generos(Nome)
VALUES ('SUSPENSE');

-- 3.Livros
INSERT INTO Livros(Titulo,IdGenero,IdAutor)
VALUES ('O Choque das Ra�as',1,1);

INSERT INTO Livros(Titulo,IdGenero,IdAutor)
VALUES ('Carrie',3,2);


INSERT INTO Livros(Titulo,IdGenero,IdAutor)
VALUES ('Espectros',4,1);

INSERT INTO Livros(Titulo, IdGenero,IdAutor)
VALUES ('O Guarani',3,1);


INSERT INTO Livros(Titulo, IdGenero,IdAutor)
VALUES ('A Rosa do Povo',4,1);


--TRUNCATE TABLE Generos;

-- Alterar o nome de um g�nero
UPDATE Generos 
SET Nome = 'ROMANCE'
WHERE IdGenero = 1;

UPDATE Generos 
SET Nome = 'INFANTIL'
WHERE IdGenero = 2;

-- Alterar o g�nero de um livro
UPDATE Livros
SET IdGenero = 4
WHERE IdGenero = 3;

UPDATE Autores
SET NomeAutor = 'Monteiro Lobato Jr'
WHERE NomeAutor = 'Monteiro Lobato';

-- Apagar um autor (est� relacionado na tabela livro)
DELETE Livros 
WHERE IdLivro = 2;

DELETE Autores
WHERE IdAutor = 2;

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
-- �Selecionar todos os livros e seus respectivos g�neros;
SELECT Titulo, IdGenero FROM Livros;
--�Selecionar todos os livros e seus respectivos autores e g�neros;
SELECT Titulo, IdGenero, IdAutor FROM Livros;
