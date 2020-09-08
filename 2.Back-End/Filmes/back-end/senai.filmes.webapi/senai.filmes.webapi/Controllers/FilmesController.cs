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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmesRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }

        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            return _filmeRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(FilmeDomain filme)
        {
            _filmeRepository.Cadastrar(filme);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(FilmeDomain filme, int id)
        {
            _filmeRepository.Atualizar(filme, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _filmeRepository.Deletar(id);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            FilmeDomain filmeBuscado = _filmeRepository.ListarPorID(id);

            if(filmeBuscado == null)
            {
                return NotFound(new
                {
                    mensagem = "Filme não encontrado!",
                    erro= true
                });
            }

            return StatusCode(200, filmeBuscado);
        }

        [HttpGet("filme")]
        public FilmeDomain GetInnerJoin()
        {
            return _filmeRepository.ListarFilmesGeneros();
        }

    }
}