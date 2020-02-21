using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FuncionarioController : ControllerBase
    {


        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionarioController(){
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


        [HttpPost("{id}")]
        public IActionResult Post(int id,FuncionarioDomain novoFuncionario)
        {
            _funcionarioRepository.CadastrarFuncionario(novoFuncionario);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutTitulo(int id,FuncionarioDomain FuncionarioAtualizado)
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
               
                _funcionarioRepository.AtualizarFuncionario( id,FuncionarioAtualizado);


                return Ok();
            }
          
            catch (Exception erro)
            {
        
                return BadRequest(erro);
            }
        }



    }
}
