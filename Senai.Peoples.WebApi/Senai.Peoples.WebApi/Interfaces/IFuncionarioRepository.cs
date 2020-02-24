using Senai.Peoples.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> ListarFuncionarios();
        List<FuncionarioDomain> ListarNomeSobrenome();
        List<FuncionarioDomain> ListaOrdenada(string ordem);

        FuncionarioDomain BuscarFuncionario(int id);
        FuncionarioDomain BuscarFuncionarioPorNome(string name);


        void CadastrarFuncionario(FuncionarioDomain funcionarios);

        void AtualizarFuncionario(int id, FuncionarioDomain FuncionarioAtualizado);
       
        void DeletarFuncionario(int id);
       
    }
}
