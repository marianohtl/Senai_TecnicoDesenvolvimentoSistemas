using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FuncionarioController : ControllerBase
    {


        private IFuncionarioRepository _funcionarioRepository { get; set; }
        
        public FuncionarioController() {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.ListarFuncionarios();
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            FuncionarioDomain FuncionarioEncontrado = _funcionarioRepository.BuscarFuncionario(id);
            if (FuncionarioEncontrado == null) {
                return NotFound("Não há funcionário regitrado com este número.");
            }
            return Ok(FuncionarioEncontrado);
        }

        [HttpGet("buscar/{name}")]
        public IActionResult GetByName(string name)
        {
            FuncionarioDomain FuncionarioEncontrado = _funcionarioRepository.BuscarFuncionarioPorNome(name);
            if (FuncionarioEncontrado == null)
            {
                return NotFound("Não há funcionário regitrado com este nome.");
            }
            return Ok(FuncionarioEncontrado);
        }

        


        [HttpGet("ordenacao/{ordem}")]
        public IActionResult GetByOrdem(string ordem)
        {

            List<FuncionarioDomain> funcionariosOrdenamos = _funcionarioRepository.ListaOrdenada(ordem);
           
            if (funcionariosOrdenamos != null)
            {
                return Ok(funcionariosOrdenamos);
                
            }


            return BadRequest("Parâmetro inválido!");
        }
        //[HttpGet("ordenacao/{ordem}")]
        //public IEnumerable<FuncionarioDomain> GetByOrdem(string ordem)
        //{

        //    List<FuncionarioDomain> funcionariosOrdenamos = _funcionarioRepository.ListaOrdenada(ordem);

        //    if (funcionariosOrdenamos != null)
        //    {
        //        return funcionariosOrdenamos;
        //    }


        //    return null;
        //}

        [HttpGet("nomescompletos")]
        public IEnumerable<FuncionarioDomain> GetCompleteName()
        {
            return _funcionarioRepository.ListarNomeSobrenome();
        }
    

        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {

            if (novoFuncionario.Nome == null || novoFuncionario.Sobrenome == null)
            {
                return BadRequest("Nome e sobrenome do funcionário é um dado obrigatório para cadastro.");
            }

            _funcionarioRepository.CadastrarFuncionario(novoFuncionario);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, FuncionarioDomain FuncionarioAtualizado)
        {

            FuncionarioDomain FuncionarioEncontrado = _funcionarioRepository.BuscarFuncionario(id);

            if (FuncionarioEncontrado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Funcionario não encontrado",
                            erro = true
                        }
                    );
            }

            try
            {

                _funcionarioRepository.AtualizarFuncionario(id, FuncionarioAtualizado);


                return Ok();
            }

            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _funcionarioRepository.DeletarFuncionario(id);
            return StatusCode(201);
        }




    }
}
