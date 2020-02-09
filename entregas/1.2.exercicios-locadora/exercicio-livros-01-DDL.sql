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
