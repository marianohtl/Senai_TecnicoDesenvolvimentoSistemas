using Senai.Senatur.WebApi.Contexts;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacotesRepository : IPacotesRepository
    {
        SenaturContext ctx = new SenaturContext();

        ///<summary>
        ///Lista todos os pacotes
        ///</summary>
        ///<returns>Uma lista de pacotes</returns>
        public List<Pacotes> ListarPacotes()
        {
            return ctx.Pacotes.ToList();
        }

        ///<summary>
        ///Busca um pacote passando o seu id
        ///</summary>
        ///<param name="id">id do pacote que será buscado</param>
        ///<returns>Um pacote buscado</returns>
        public Pacotes BuscarPorId(int id)
        {
            //Retorna o primeiro pacote encontrado para o id informado
            return ctx.Pacotes.Find(id);
        }

        ///<summary>
        ///Altera um Pacote (apenas um campo ou todos)
        ///</summary>
        ///<param name="id">id do pacote que será atualizado</param>
        ///<param name="pacoteAtualizado">Objeto com as novas informações</param>
        public void AtualizarPacote(int id, Pacotes pacoteAtualizado)
        {
            //Busca um pacote através do id
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            //Atribui novos valores aos campos existentes caso não for nulo
            if(pacoteAtualizado.NomePacote != null)
            {
                
                pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            }
            if(pacoteAtualizado.Descricao != null)
            {
                pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            }
            if(pacoteAtualizado.DataIda != null)
            {
                pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            }
            if (pacoteAtualizado.DataVolta != null)
            {
                pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            }
            if (pacoteAtualizado.Valor != null)
            {
                pacoteBuscado.Valor = pacoteAtualizado.Valor;
            }
            if (pacoteAtualizado.Ativo != null)
            {
                pacoteBuscado.Ativo = pacoteAtualizado.Ativo;
            }
            if (pacoteAtualizado.NomeCidade != null)
            {
                pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;
            }
        }

        ///<summary>
        ///Cadastra um novo pacote
        ///</summary>
        ///<param name="novoPacote">Objeto novoPacote que será cadastrado</param>
        public void CadastrarPacote(Pacotes novoPacote)
        {
            ctx.Pacotes.Add(novoPacote);
            ctx.SaveChanges();
        }
    }
}
