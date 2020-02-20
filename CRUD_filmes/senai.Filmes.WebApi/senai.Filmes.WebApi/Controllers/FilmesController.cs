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
/*
        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {

            return _filmeRepository.ListarFilme();
        }
*/
        [HttpGet]
        public IEnumerable<FilmeDomain> FilmeComGenero()
        {

            return _filmeRepository.ListarFilmeComGenero();
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

        [HttpPut("{id}")]
        public IActionResult PutTitulo(int id, FilmeDomain TituloAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            FilmeDomain FilmeBuscado = _filmeRepository.BuscarFilmeId(id);

            // Verifica se nenhum gênero foi encontrado
            if (FilmeBuscado == null)
            {
                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para representar que houve erro
                return NotFound
                    (
                        new
                        {
                            mensagem = "Gênero não encontrado",
                            erro = true
                        }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl();
                _filmeRepository.AtualizarFilme(id, TituloAtualizado);

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


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _filmeRepository.DeletarFilme(id);

            return Ok("Gênero deletado");
        }

    }
}
