using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repository;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        /// <summary>
        /// Recebendo a Interface
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Interface recebendo Repository
        /// </summary>
        public FuncionarioController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        /// <summary>
        /// Método GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }

        /// <summary>
        /// Método POST
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(FuncionarioDomain funcionario)
        {
            // Validação
            if (funcionario.Nome == null || funcionario.Sobrenome == null)
            {
                return BadRequest("Faltou algum campo!");
            }
            else
            {

            return Ok(_funcionarioRepository.Inserir(funcionario));
            }

          
        }

        /// <summary>
        /// Método POST
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="funcionario">Nome e Sobrenome</param>
        /// <returns>Funcionário Atualizado</returns>
        [HttpPut("{id}")]
        public string Put(int id , FuncionarioDomain funcionario)
        {
            return _funcionarioRepository.Atualizar(id, funcionario);
        }

        /// <summary>
        /// Método Delete
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Funcionario Deletado</returns>
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _funcionarioRepository.Deletar(id);
        }

        /// <summary>
        /// Método Get por ID
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Funcionario</returns>
        [HttpGet("{id}")]
        public IActionResult GetBydId(int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.ListarPorId(id);

            if(funcionarioBuscado == null)
            {
                return NotFound("Funcionario não encontrado!");
            }

            return Ok(funcionarioBuscado);
        }

        /// <summary>
        /// Método Get por Nome
        /// </summary>
        /// <param name="nome">Nome</param>
        /// <returns>Funcionario</returns>
        [HttpGet("buscar/{nome}")]
        public IActionResult GetPorNome(FuncionarioDomain nome)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.ListarPorNome(nome);

            if(funcionarioBuscado == null)
            {
                return NotFound("Funcionario não encontrado!");
            }

            return Ok(funcionarioBuscado);
        }

        /// <summary>
        /// Método Get por Nome Completo
        /// </summary>
        /// <returns>Funcionarios</returns>
        [HttpGet("nomescompletos")]
        public IEnumerable<FuncionarioDomain> GetNomeCompleto()
        {
            return _funcionarioRepository.ListarPorNomeCompleto();
        }

    }
}