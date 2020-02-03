CREATE DATABASE OptusM;

USE OptusM;

CREATE TABLE TipoUsuario(
IdTipoUsuario INT PRIMARY KEY IDENTITY,
Titulo VARCHAR(30) NOT NULL
);

CREATE TABLE Usuarios(
IdUsuario INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255) NOT NULL,
IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
);

CREATE TABLE Artistas(
IdArtista INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255) NOT NULL
);



CREATE TABLE Estilos(
IdEstilo INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255) NOT NULL
);

CREATE TABLE Albuns(
IdAlbum INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255) NOT NULL,
DataLancamento Date NOT NULL,
QtdMinutos FLOAT NOT NULL,
Visualizacao INT NOT NULL,
IdArtista INT FOREIGN KEY REFERENCES Artistas(IdArtista) NOT NULL,
IdEstilo INT FOREIGN KEY REFERENCES Estilos(IdEstilo) NOT NULL
);

-- 1. INSERIR NO MÍNIMO 5 DADOS EM CADA TABELA
INSERT INTO TipoUsuario(Titulo)
VALUES ('1'),
	   ('2'),
	   ('3'),
	   ('4'),
	   ('5');


INSERT INTO Usuarios(Nome, IdTipoUsuario)
VALUES ('Maria Cabral do Amaral',1),
	   ('Beatriz dos Santos Manso',1),
	   ('Thalita Mariano',2),
	   ('Fernando Rebelo',3),
	   ('José Alencar Filho',4);


INSERT INTO Artistas(Nome)
VALUES ('Non Blondes'),
	   ('Aline Barros'),
	   ('André Matos'),
	   ('Ed Sheeran'),
	   ('Gusttavo Lima'),
	   ('Elvis Presley');

INSERT INTO Estilos(Nome)
VALUES ('Rock'),
	   ('Pop'),
	   ('Sertanejo'),
	   ('Metal'),
	   ('Eletrônica');

INSERT INTO Albuns(Nome, DataLancamento, QtdMinutos,Visualizacao,IdArtista, IdEstilo)
VALUES	('Rebirth','01/01/2001',30.40,0,3,1),
		('Angels Cry','01/01/1993',20.15,0,3,1),
		('Temple of Shadows','01/01/2004',5.00,1,3,1),
		('Omni','01/01/2018',30.10,1,3,1),
		('Holy Land','01/01/1996',18.14,0,3,1);


INSERT INTO Albuns(Nome, DataLancamento, QtdMinutos,Visualizacao,IdArtista, IdEstilo)
VALUES	('Rebirth 2','01/01/2001',30.40,0,3,1);


INSERT INTO Albuns(Nome, DataLancamento, QtdMinutos,Visualizacao,IdArtista, IdEstilo)
VALUES	('Rebirth 3','01/01/2001',30.40,0,3,2);

INSERT INTO Albuns(Nome, DataLancamento, QtdMinutos,Visualizacao,IdArtista, IdEstilo)
VALUES	('Rebirth 4','01/01/2001',30.40,0,3,3);
-- 2. ALTERAR O NOME DE UM ARTISTA
UPDATE Artistas
SET Nome = 'Gusttavo Lima e Você'
WHERE Nome = 'Gusttavo Lima'

-- 3. ALTERAR UM TIPO DE USUÁRIO
UPDATE TipoUsuario
SET Titulo = 'administrador'
WHERE Titulo = '1';

-- 4. ALTERAR A QUANTIDADE DE VISUALIZAÇÃO DE UM ALBUM
UPDATE Albuns 
SET Visualizacao = 80001
WHERE Visualizacao = 0;

UPDATE Albuns 
SET Visualizacao = 9000
WHERE IdAlbum = 1;

-- 5.APAGAR UM ÁLBUM
DELETE Albuns
WHERE IdAlbum = 5;

-- DQL
SELECT * FROM TipoUsuario;
SELECT * FROM Usuarios;
SELECT * FROM Artistas;
SELECT * FROM Albuns;
SELECT * FROM Estilos;

-- DQL

-- 1. Selecionar os álbuns do mesmo artista.
SELECT * FROM Albuns WHERE IdArtista = 3;
-- JOIN
SELECT * FROM Artistas INNER JOIN Albuns ON Artistas.IdArtista = Albuns.IdArtista WHERE Artistas.IdArtista = 3;

-- 2. Selecionar os álbuns lançados na mesma data
SELECT * FROM Albuns WHERE DataLancamento = '2001-01-01';
-- COM INNER JOIN
SELECT * FROM Artistas INNER JOIN Albuns ON Artistas.IdArtista = Albuns.IdArtista WHERE DataLancamento = '2001-01-01';
-- Utilizando alias 
SELECT Artistas.Nome AS NOMEARTISTA ,Albuns.Nome, Albuns.DataLancamento FROM Artistas INNER JOIN Albuns ON Artistas.IdArtista = Albuns.IdArtista WHERE DataLancamento = '2001-01-01';

-- 3. Selecionar os artistas do mesmo estilo musical
SELECT IdArtista, IdEstilo FROM Albuns WHERE IdEstilo = 1;

--INNER JOIN COM TRÊS TABELAS
SELECT Artistas.Nome, Estilos.Nome FROM Albuns INNER JOIN Artistas ON Artistas.IdArtista = Albuns.IdArtista  
INNER JOIN Estilos ON Estilos.IdEstilo = Albuns.IdEstilo WHERE Estilos.IdEstilo = 1; 

Select * from Estilos;
Select * from Artistas;

-- 4. Selecionar álbuns e artistas e ordenar a data de lançamento da mais recentes para o mais antiga
SELECT IdArtista, Nome, DataLancamento FROM Albuns ORDER BY Nome DESC;

