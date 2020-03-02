SELECT * FROM Usuario;

SELECT * FROM Estudios;

SELECT * FROM Jogos;

SELECT Jogos.NomeJogo, Estudios.NomeEstudio FROM Jogos
INNER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio

SELECT Estudios.NomeEstudio, Jogos.NomeJogo FROM Estudios
LEFT JOIN Jogos ON Jogos.IdEstudio = Estudios.IdEstudio

SELECT * FROM Usuario WHERE Usuario.Email = 'admin@admin.com' AND Usuario.Senha = 'admin'; 

SELECT * FROM Jogos WHERE IdJogo = 1;

SELECT * FROM Estudios WHERE IdEstudio = 1;