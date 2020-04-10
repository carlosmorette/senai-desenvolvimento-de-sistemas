using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;

namespace senai.Filmes.WebApi.Controllers
{

    /*
     Passamos a privacidade do método, o que ele retorna o nome e os retornos
    */

    /// <summary>
    /// Controller responsável pelos endpoints referentes aos generos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class GenerosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _generoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        /// dominio/api/Generos
        [HttpGet]
        public IEnumerable<GeneroDomain> Get()
        {
            // IEnumerable é o que a função vai retornar do GeneroDomain
            // Faz a chamada para o método .Listar();
            return _generoRepository.Listar();
        }

        /// <summary>
        /// Cadastra um genero
        /// </summary>
        /// <param name="genero">Nome do genero</param>
        /// <returns>Genero cadastrado</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain genero)
        {
            _generoRepository.Cadastrar(genero);

            return Ok("Filme Cadastrado");
        }

        /// <summary>
        /// Exclui um genero
        /// </summary>
        /// <param name="id">Id do genero</param>
        /// <returns>Genero excluido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _generoRepository.Deletar(id);
            
            return Ok("Filme Deletado");

        }

        /// <summary>
        /// Atualiza genero
        /// </summary>
        /// <param name="genero">Nome do genero</param>
        /// <returns>Genero atualizado</returns>
        [HttpPut]
        public IActionResult Put(GeneroDomain genero)
        {
            _generoRepository.Atualizar(genero);

            return Ok("Filme Alterado");
        }

        /// <summary>
        /// Listar genero por id
        /// </summary>
        /// <param name="id">Id do genero</param>
        /// <returns>Retorna o genero correspondente ao ID</returns>
        [HttpGet("{id}")]
        public IActionResult GetporID(int id)
        {
            GeneroDomain generoBuscado = _generoRepository.ListarPorId(id);

            if(generoBuscado == null)
            {
                // Passamos um objeto como mensagem
                return NotFound(new
                {
                    mensagem= "Nenhum gênero encontrado!",
                    erro = true
                });
            }

            // Retornamos o status code e o genero buscado
            return StatusCode(200, generoBuscado);
        }
    }
}