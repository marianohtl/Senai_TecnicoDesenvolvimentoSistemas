INSERT INTO TipoUsuario(Titulo) VALUES ('Administrador'), ('Cliente')

INSERT INTO Usuario(Email, Senha, IdTipo) VALUES ('admin@admin.com', 'admin', 1), ('cliente@cliente.com','cliente', 2)

INSERT INTO Estudios(NomeEstudio) VALUES ('Valve'), ('Larian Estudios'), ('Wizards of the Coast')

INSERT INTO Jogos(NomeJogo, Descricao, DataLancamento, IdEstudio, Valor) VALUES ('Baldurs Gate 3', 'O mais novo jogo de RPG Baseado em DND 5E', '04/01/2000', 2, 160.50), ('Dota 2', 'O melhor moba no mercado.', '03/07/2011', 1, 100);