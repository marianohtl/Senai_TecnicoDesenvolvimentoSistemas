using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IEnumerable<JogosDomain> Get()
        {
            return _jogosRepository.ListarJogos();
        }


        [HttpPost]
        public IActionResult Post(JogosDomain novoJogo)
        {
            _jogosRepository.CadastrarJogo(novoJogo);
            return StatusCode(201);
        }

    }
}