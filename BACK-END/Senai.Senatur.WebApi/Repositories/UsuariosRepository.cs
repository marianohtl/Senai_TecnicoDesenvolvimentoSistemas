﻿using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Contexts;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        SenaturContext ctx = new SenaturContext();

        ///<summary>
        /// Lista todos os usuários mostrando o título do tipo de usuário 
        ///</summary>
        ///<returns>Uma lista de usuários mostrando o título do tipo de usuário</returns>
        public List<Usuarios> ListarUsuarios()
        {
            return ctx.Usuarios.ToList();
        }

        ///<summary>
        ///Busca um usuário passando o seu email e senha
        ///</summary>
        ///<param name="Email">Email do pacote que será buscado</param>
        ///<param name="Senha">Senha do pacote que será buscado</param>
        ///<returns>Um pacote buscado</returns>
        public Usuarios BuscarPorEmailSenha(string Email, string Senha)
        {
            //Retorna o primeiro pacote encontrado para o id informado
            return ctx.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
        }

        /// <summary>
        /// Lista todos os usuários com os respectivos tipos de usuários
        /// </summary>
        /// <returns>Uma lista de usuários com os tipos de usuários</returns>
        public List<Usuarios> ListarTiposUsuario()
        {
            // Retorna uma lista de estúdios com seus jogos
            return ctx.Usuarios.Include(e => e.TiposUsuarios).ToList();
        }
    }
}
