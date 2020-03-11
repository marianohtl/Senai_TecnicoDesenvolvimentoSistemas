using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IUsuariosRepository
    {
        ///<summary>
        /// Lista todos os usuários mostrando o título do tipo de usuário 
        ///</summary>
        ///<returns>Uma lista de usuários mostrando o título do tipo de usuário</returns>
        List<Usuarios> ListarUsuarios();

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Um usuário autenticado</returns>
        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}
