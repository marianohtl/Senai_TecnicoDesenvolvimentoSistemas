CREATE DATABASE M_Peoples;

USE M_Peoples;


CREATE TABLE Funcionarios(
IdFuncionario INT PRIMARY KEY IDENTITY,
Nome VARCHAR(255) NOT NULL,
Sobrenome VARCHAR(255) NOT NULL
);


ALTER TABLE Funcionarios ADD DataNascimento DATE;