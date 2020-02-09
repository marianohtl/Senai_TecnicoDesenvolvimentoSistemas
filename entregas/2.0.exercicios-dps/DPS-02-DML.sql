INSERT INTO Departamentos(Nome) VALUES('Design'),('Desenvolvimento');

INSERT INTO Habilidades(Nome) VALUES('HTML'),('Desenhar interfaces'),('Java'),('CSS'),('Kotlin');

INSERT INTO Funcionarios(Nome,CPF,Salario,IdDepartamento) VALUES('Erik','444.444.444-40',1000.5,1),('Helena','111.444.444-40',1222.90,2),('Jucelino','222.444.444-40',2000,2);

INSERT INTO FuncionariosHabilidades(IdFuncionario,IdHabilidade) VALUES(1,1),(2,1),(1,2),(3,5),(3,2),(2,4);
