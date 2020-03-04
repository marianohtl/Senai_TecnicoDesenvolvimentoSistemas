using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]

    public class EstudiosController : ControllerBase
    {
     private IEstudiosRepository _estudioRepository { get; set; }

     public EstudioController()
        {
            _estudioRepository = new EstudiosRepository();
        }

         [HttpPost]
        public IActionResult Post(EstudiosDomain novoEstudio)
        {
            _jogosRepository.CadastrarJogo(novoEstudio);
            return StatusCode(201);
        }

    }
}
