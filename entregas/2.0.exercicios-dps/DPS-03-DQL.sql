
SELECT * FROM Departamentos
SELECT * FROM Habilidades
SELECT * FROM Funcionarios
SELECT * FROM FuncionariosHabilidades

SELECT Funcionarios.Nome, Funcionarios.CPF , Funcionarios.Salario, Habilidades.Nome AS Habilidade, Departamentos.Nome AS Departamento FROM FuncionariosHabilidades
INNER JOIN Funcionarios ON FuncionariosHabilidades.IdFuncionario = Funcionarios.IdFuncionario
INNER JOIN Habilidades ON FuncionariosHabilidades.IdHabilidade =  Habilidades.IdHabilidade
INNER JOIN Departamentos ON Funcionarios.IdDepartamento = Departamentos.IdDepartamento;
