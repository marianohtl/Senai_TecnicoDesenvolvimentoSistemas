-- Data Manipulation Query

INSERT INTO Clinica(RazaoSocial, Endereco)
VALUES ('PetShop 01', 'Avenida Randon nº 1'),
	   ('PetShop 02', 'Avenida Randon nº 2'),
	   ('PetShop 03', 'Avenida Randon nº 3');


INSERT INTO Dono(Nome)
VALUES ('Beatriz Manso'),
   	   ('Kayke Eduardo'),
	   ('Débora Muriele'),
	   ('Marcos Paulo');

INSERT INTO TipoPet(Titulo)
VALUES ('Marsupial'),
	   ('Cobaia'),
	   ('Cobra');


INSERT INTO Raca(Titulo,IdTipoPet)
VALUES ('Diabo-da-Tasmânia',1),
	   ('Twister',2),
	   ('Jararaca',3);

INSERT INTO Veterinario(Nome,CRMV,IdClinica)
VALUES ('Arnaldo Francisco Costa','000000',1),
	   ('Fernanda Rebelo','111111',2),
	   ('Ordis Regiz de Sá', '222222',3);

INSERT INTO Pet(Nome, Telefone,IdDono,IdRaca)
VALUES ('Biscoito', '01100000-0000',1,1),
	   ('Pré-Pago', '011911111111',1,3),
	   ('Mia','02192222-2222',3,1);

INSERT INTO Atendimento(DataAtendimento,Descricao, IdVet,IdPet)
VALUES ('2020-02-03','Bichinho Curado',1,1),
	   ('2020-02-04','Bichinho Morreu',1,2),
       ('2020-02-03','Bichinho Comeu o Veterinário',3,2);

INSERT INTO Atendimento(DataAtendimento,Descricao,IdVet,IdPet)
VALUES ('2020-02-03','Bichinho Comeu o Veterinário',2,2);

INSERT INTO Atendimento(DataAtendimento,Descricao,IdVet,IdPet)
VALUES ('2020-02-10','Bichinho Comeu o Veterinário',1,1);

INSERT INTO Atendimento(DataAtendimento,Descricao,IdVet,IdPet)
VALUES ('2020-02-10','Ressuscitou o Veterinário',1,3);