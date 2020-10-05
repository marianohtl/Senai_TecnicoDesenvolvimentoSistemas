	-- Define o banco de dados que ser� utilizado
	USE Filmes;
	GO

	-- Insere dois g�neros na tabela Generos
	INSERT INTO Generos	(Nome)
	VALUES				('A��o')
						,('Drama');
	GO

	-- Insere dois filmes na tabela Filmes
	INSERT INTO Filmes	(Titulo, IdGenero)
	VALUES				('A vida � bela', 2)
						,('Rambo', 1)
						,('kimi no na wa', 2)
						,('koe no katachi', 2)
						,('Duro de matar', 1);
	GO


	-- Insere dois novos usu�rios
	INSERT INTO Usuarios (Nome,Email, Senha, Permissao)
	VALUES				 ('Saulo','saulo@email.com', '123', 'Comum')
						,('Administrador','adm@adm.com', '123', 'Administrador');
	GO
