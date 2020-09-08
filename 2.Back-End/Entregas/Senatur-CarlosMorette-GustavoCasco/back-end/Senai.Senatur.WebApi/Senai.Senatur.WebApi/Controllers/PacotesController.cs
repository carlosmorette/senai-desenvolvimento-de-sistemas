using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacoteRepository;

        public PacotesController()
        {
            _pacoteRepository = new PacotesRepository();
        }

        /// <summary>
        /// Listar pacotes
        /// </summary>
        /// <returns>Todos os Pacotes</returns>
        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacoteRepository.Listar());
        }

        /// <summary>
        /// Cadastra um pacote
        /// </summary>
        /// <param name="novoPacote">Pacote novo</param>
        /// <returns>Pacote cadastrado</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            _pacoteRepository.Cadastrar(novoPacote);

            return StatusCode(201, novoPacote);
        }

        /// <summary>
        /// Atualiza um pacote
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="attPacote">Pacote atualizado</param>
        /// <returns>Pacote atualizado</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pacotes attPacote)
        {
            try{
                _pacoteRepository.Atualizar(id, attPacote);

                return StatusCode(204, attPacote);

            } catch(Exception err)
            {
                return BadRequest(err);
            }
        }

        /// <summary>
        /// Deleta um pacote
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Pacote deletado</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pacotes pacoteBuscado = _pacoteRepository.BuscarPorId(id);

            if(pacoteBuscado != null)
            {
                _pacoteRepository.Deletar(id);

                return StatusCode(200, $"Pacote Id:{id} deletado");
            }

            return StatusCode(404, "Nenhum pacote encontrado");
        }

        /// <summary>
        /// Lista um pacote
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Um pacote</returns>
        [Authorize(Roles = "1,2")]
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            return StatusCode(200, _pacoteRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Lista pacotes ativos
        /// </summary>
        /// <returns>Pacotes ativos</returns>
        [HttpGet("ativo")]
        public IActionResult GetAtivos()
        {
            return StatusCode(200, _pacoteRepository.BuscarAtivo());
        }

        /// <summary>
        /// Lista pacotes inativos
        /// </summary>
        /// <returns>Pacotes inativos</returns>
        [HttpGet("inativo")]
        public IActionResult GetInativos()
        {
            return StatusCode(200, _pacoteRepository.BuscarInativo());
        }

        /// <summary>
        /// Lista pacotes de determinada cidade
        /// </summary>
        /// <param name="nomeCidade">Nome da cidade</param>
        /// <returns>Pacotes de determinado cidade</returns>
        [HttpGet("cidade/{nomeCidade}")]
        public IActionResult GetCidade(string nomeCidade)
        {
            return StatusCode(200, _pacoteRepository.BuscarCidade(nomeCidade));
        }

        /// <summary>
        /// Lista pacotes ordenado pelos valores, do maior para o menor
        /// </summary>
        /// <returns>Pacotes ordenados</returns>
        [HttpGet("valor")]
        public IActionResult GetMaiorMenor()
        {
            return StatusCode(200, _pacoteRepository.ListaOrdenadaMaiorMenor());
        }

        /// <summary>
        /// Lista pacotes ordenado pelos valores, do menor para o maior
        /// </summary>
        /// <returns>Pacotes ordenados</returns>
        [HttpGet("valorMenor")]
        public IActionResult GetMenorMaior()
        {
            return StatusCode(200, _pacoteRepository.ListaOrdenadoMenorMaior());
        }


    }
}