using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    [ApiController]
    public class FilmesController : ControllerBase
    {

        private IFilmesRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmesRepository();
        }

        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {

            return _filmeRepository.ListarFilme();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarFilmeId(id);

            if (filmeBuscado == null)
            {
                return NotFound("O filme não foi encontrado :(");
            }

            return Ok(filmeBuscado);
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.CadastrarFilme(novoFilme);
            return StatusCode(201);

          }


    }
}
