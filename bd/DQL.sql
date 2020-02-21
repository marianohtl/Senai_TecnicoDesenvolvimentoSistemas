USE M_Peoples;

SELECT * FROM Funcionarios

SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios

SELECT IdFuncionario, Nome,Sobrenome FROM Funcionarios Where IdFuncionario = 1

  UPDATE Funcionarios SET Nome=@nome, Sobrenome=@sobrenome WHERE IdFuncionario=@ID

	   	   UPDATE Funcionarios SET Nome='lagartixinha', Sobrenome='atômica' WHERE IdFuncionario=3