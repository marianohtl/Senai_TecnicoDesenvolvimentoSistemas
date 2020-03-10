using Microsoft.AspNetCore.Mvc;
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
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuariosRepository _usuarioRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuariosRepository();
        }

        /// <summary>
        /// Lista todos os usuários
        /// </summary>
        /// <returns>Uma lista de usuários e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            // Retorna a resposta da requisição fazendo a chamada para o método
            return Ok(_usuarioRepository.ListarUsuarios());
        }
    }
}
