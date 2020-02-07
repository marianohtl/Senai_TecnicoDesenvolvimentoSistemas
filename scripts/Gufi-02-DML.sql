-- Define o banco de dados que será utilizado
USE Gufi_Manha;
GO

-- Criação das tabelas
INSERT INTO TipoUsuario (TituloTipoUsuario) VALUES ('Administrador'),('Comum');
GO

INSERT INTO TipoEvento (TituloTipoEvento)  VALUES ('C#'),('React'),('SQL');
GO

INSERT INTO  Instituicao (CNPJ, NomeFantasia ,Endereco) VALUES ('11111111111111','Escola SENAI de Informática','Alameda Barão de Limeira, 538');
GO

INSERT INTO  Usuario (Nome ,Email ,Senha ,DataCadastro ,Genero ,IdTipousuario) VALUES('Administrador','adm@adm.com','adm123','2020-02-06','Não Informado',1),('Carol','carol@email.com','carol123','2020-02-06','Feminino',2),('Saulo','saulo@email.com','saulo123', '2020-02-06','Masculino',2);
GO


INSERT INTO Evento (NomeEvento, DataEvento, Descricao, AcessoLivre ,IdInstituicao,IdTipoEvento) VALUES ('Introdução ao C#', '2020-02-07','Conceitos sobre os pilares da programação orientada a objetos',1,1,1),
('Ciclo de vida','2020-02-07','Como utilizar o ciclo de vida com ReactJs',	0	,1	,2),
('Optimização de banco de dados','2020-02-07','Aplicação de índices clusterizados e não clusterizados',	1,	1,	3);
GO

INSERT INTO Presenca (IdUsuario,IdEvento ,Situacao) VALUES (16,2,'Agendada'),(16,3,'Confirmada'),(17,1,'Não compareceu');
GO

	