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

        FuncionarioDomain BuscarFuncionario(int id);
      

        void CadastrarFuncionario(FuncionarioDomain funcionarios);

        void AtualizarFuncionario(int id, FuncionarioDomain FuncionarioAtualizado);
        /*
                     void DeletarFuncionario();
                 */
    }
}
