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
        [HttpGet]
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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(_pacoteRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="novoPacote">Objeto novoPacote que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            // Faz a chamada para o método
            _pacoteRepository.CadastrarPacote(novoPacote);

            // Retorna um status code
            return StatusCode(201);
        }
    }
}
