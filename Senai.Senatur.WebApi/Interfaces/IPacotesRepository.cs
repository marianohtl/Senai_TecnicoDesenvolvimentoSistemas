using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacotesRepository
    {
        ///<summary>
        ///Lista todos os pacotes
        ///</summary>
        ///<returns>Uma lista de pacotes</returns>
        List<Pacotes> ListarPacotes();

        ///<summary>
        ///Busca um pacote passando o seu id
        ///</summary>
        ///<param name="id">id do pacote que será buscado</param>
        ///<returns>Um pacote buscado</returns>
        Pacotes BuscarPorId(int id);

        ///<summary>
        ///Altera um Pacote (apenas um campo ou todos)
        ///</summary>
        ///<param name="id">id do pacote que será atualizado</param>
        ///<param name="pacoteAtualizado">Objeto com as novas informações</param>
        void AtualizarPacote(int id, Pacotes pacoteAtualizado);

        ///<summary>
        ///Cadastra um novo pacote
        ///</summary>
        ///<param name="novoPacote">Objeto novoPacote que será cadastrado</param>
        void CadastrarPacote(Pacotes novoPacote);
    }
}
