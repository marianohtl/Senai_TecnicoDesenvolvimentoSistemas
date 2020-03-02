CREATE DATABASE InLock_Manha;
USE InLock;


CREATE TABLE Estudios (IdEstudio INT IDENTITY PRIMARY KEY, NomeEstudio varchar(200))

CREATE TABLE Jogos (IdJogo INT IDENTITY PRIMARY KEY, NomeJogo varchar(200), Descricao varchar(200), DataLancamento DATE, Valor DECIMAL, IdEstudio INT FOREIGN KEY REFERENCES Estudios(IdEstudio));

CREATE TABLE TipoUsuario (IdTipo INT IDENTITY PRIMARY KEY, Titulo varchar(200))

CREATE TABLE Usuario (IdUsuario INT IDENTITY PRIMARY KEY, Email varchar(200), Senha nvarchar(200), IdTipo INT FOREIGN KEY REFERENCES TipoUsuario(IdTipo))