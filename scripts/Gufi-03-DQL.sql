SELECT Nome As NomeUsuario, Email, Senha,DataCadastro,Genero,TipoUsuario.TituloTipoUsuario FROM Usuario
INNER JOIN TipoUsuario ON Usuario.IdTipousuario = TipoUsuario.IdTipoUsuario;

SELECT CNPJ, NomeFantasia, Endereco FROM Instituicao;

SELECT TituloTipoEvento FROM TipoEvento;

SELECT NomeEvento, DataEvento,Descricao,AcessoLivre, TipoEvento.TituloTipoEvento , Instituicao.NomeFantasia, Instituicao.Endereco FROM Evento	
INNER JOIN TipoEvento ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao;

SELECT NomeEvento, DataEvento,Descricao,AcessoLivre, Instituicao.NomeFantasia, TipoEvento.TituloTipoEvento FROM Evento	
INNER JOIN TipoEvento ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento
INNER JOIN Instituicao ON Evento.IdInstituicao = Instituicao.IdInstituicao
WHERE AcessoLivre = 1;


SELECT Usuario.Nome,Usuario.Email,Usuario.DataCadastro,Usuario.Genero,  TipoEvento.TituloTipoEvento , Evento.NomeEvento, Evento.DataEvento, Evento.Descricao, 
Evento.AcessoLivre , Situacao, Instituicao.NomeFantasia, CNPJ, Instituicao.Endereco  
from Presenca 
INNER JOIN  Usuario ON Presenca.IdUsuario = Usuario.IdUsuario
INNER JOIN Evento ON Presenca.IdEvento = Evento.IdEvento 
INNER JOIN TipoEvento ON Evento.IdTipoEvento = TipoEvento.IdTipoEvento
INNER JOIN Instituicao ON Evento.IdInstituicao = Evento.IdInstituicao
WHERE Presenca.IdUsuario = 17;

as +

]



SELECT NomeEvento,DataEvento,Descricao, AcessoLivre  =  
      CASE Evento.AcessoLivre  
         WHEN 1 THEN 'Public'  
         ELSE 'Private'  
      END
FROM Evento

select * from evento

select * from evento
CREATE VIEW Customers  
AS  
SELECT *  
FROM CompanyData.dbo.Customers_33  
UNION ALL  
--Select from member table on Server2. 

SELECT * FROM PRESENCA
SELECT * FROM Usuario
SELECT * FROM Evento
SELECT * FROM Instituicao
SELECT * FROM TipoEvento




