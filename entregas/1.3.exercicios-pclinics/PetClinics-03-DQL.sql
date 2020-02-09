-- DATA QUERY LANGUAGE

SELECT * FROM Dono
SELECT * FROM Clinica
SELECT * FROM TipoPet
SELECT * FROM Raca
SELECT * FROM Veterinario
SELECT * FROM Pet
SELECT * FROM Atendimento


SELECT DataAtendimento,Descricao, Veterinario.Nome, Veterinario.CRMV, Pet.Nome, Pet.Telefone, Raca.Titulo, TipoPet.Titulo, Clinica.RazaoSocial,Clinica.Endereco, Dono.Nome FROM Atendimento
ON Atendimento.IdVet = ;


SELECT DataAtendimento,Descricao, Veterinario.Nome, Veterinario.CRMV , Pet.Nome, Pet.Telefone, Raca.Titulo, TipoPet.Titulo, Dono.Nome FROM Atendimento
INNER JOIN Veterinario ON Atendimento.IdVet = Veterinario.IdVet
INNER JOIN Pet ON Atendimento.IdPet = Pet.IdPet
INNER JOIN Raca ON Pet.IdRaca = Raca.IdRaca
INNER JOIN TipoPet ON Raca.IdTipoPet = TipoPet.IdTipoPet
INNER JOIN Dono ON Pet.IdDono = Dono.IdDono;


SELECT * FROM Raca
SELECT * FROM Pet
