-- DDL - COMANDOS DE CRIAÇÃO
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
	IdAautor INT FOREIGN KEY REFERENCES Autores(IdAutor)
);

-- DML - COMANDOS DE MANIPULAÇÃO

-- Inserir 5 dados em cada tabela

-- 1.Autores
INSERT INTO Autores(NomeAutor)
VALUES ('Monteiro Lobato');

INSERT INTO Autores(NomeAutor)
VALUES ('Stephen king');

INSERT INTO Autores(NomeAutor)
VALUES ('José de Alencar');

INSERT INTO Autores(NomeAutor)
VALUES ('Cecília Meireles');

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
INSERT INTO Livros(Titulo,IdGenero,IdAautor)
VALUES ('O Choque das Raças',1,1);

INSERT INTO Livros(Titulo,IdGenero,IdAautor)
VALUES ('Carrie',3,2);


INSERT INTO Livros(Titulo,IdGenero,IdAautor)
VALUES ('Espectros',4,1);

INSERT INTO Livros(Titulo, IdGenero,IdAautor)
VALUES ('O Guarani',3,1);


INSERT INTO Livros(Titulo, IdGenero,IdAautor)
VALUES ('A Rosa do Povo',4,1);


TRUNCATE TABLE Generos;

-- Alterar o nome de um gênero
UPDATE Generos 
SET Nome = 'ROMANCE'
WHERE IdGenero = 1;

UPDATE Generos 
SET Nome = 'INFANTIL'
WHERE IdGenero = 2;

-- Alterar o gênero de um livro
UPDATE Livros
SET IdGenero = 4
WHERE IdGenero = 3;

UPDATE Autores
SET NomeAutor = 'Monteiro Lobato Jr'
WHERE NomeAutor = 'Monteiro Lobato';

-- Apagar um autor (está relacionado na tabela livro)
DELETE Livros 
WHERE IdLivro = 2;

DELETE Autores
WHERE IdAutor = 2;

-- DQL - COMANDOS DE CONSULTA
SELECT * FROM Autores;
SELECT * FROM Livros;
SELECT * FROM Generos;

