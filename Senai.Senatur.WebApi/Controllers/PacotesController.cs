using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos estudios
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    //[Authorize]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _pacoteRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IPacotesRepository _pacoteRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public PacotesController()
        {
            _pacoteRepository = new PacotesRepository();
        }

        /// <summary>
        /// Lista todos os pacotes
        /// </summary>
        /// <returns>Uma lista de pacotes e um status code 200 - Ok</returns>
        /// <response code="200">Requisição bem sucedidada</response>
        [Authorize(Roles = "1")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_pacoteRepository.ListarPacotes());
        }

        /// <summary>
        /// Busca um pacote através do ID
        /// </summary>
        /// <param name="id">id do pacote que será buscado</param>
        /// <returns>Um pacote buscado e um status code 200 - Ok</returns>
        /// <response code="200">Requisição bem sucedidada</response>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetById(int id)
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_pacoteRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="novoPacote">Objeto novoPacote que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        /// <response code="201">Requisição bem sucedida e um novo recurso foi criado(novoPacote)</response>
        [Authorize(Roles = "1")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(Pacotes novoPacote)
        {
            // Faz a chamada para o método
            _pacoteRepository.CadastrarPacote(novoPacote);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um pacote existente
        /// </summary>
        /// <param name="id">id do pacote que será atualizado</param>
        /// <param name="pacoteAtualizado">Objeto pacoteAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Pacotes/1
        /// <response code="200">Requisição bem sucedidada</response>
        [Authorize(Roles = "1")]    // Somente o tipo de usuário 1 (administrador) pode acessar o endpoint
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Put(int id, Pacotes pacoteAtualizado)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            Pacotes pacoteBuscado = _pacoteRepository.BuscarPorId(id);

            // Verifica se algum jogo foi encontrado
            if (pacoteBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .Atualizar();
                    _pacoteRepository.AtualizarPacote(id, pacoteAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna BadRequest e o erro
                    return BadRequest(erro);
                }

            }

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "Pacote não encontrado",
                        erro = true
                    }
                );
        }
    }
}
