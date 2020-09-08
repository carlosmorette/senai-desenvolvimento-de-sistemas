using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.DataBaseFirst.Repositories;

namespace Senai.InLock.WebApi.DataBaseFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository;

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_estudioRepository.BuscarPorId(id));
            }
            catch
            {
                return BadRequest("Estudio não encontrado!");
            }
        }

        [HttpPost]
        public IActionResult Post(Estudio novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201, "Estudio cadastrado!");
        }

        [HttpPut]
        public IActionResult Put(Estudio estudio)
        {
            _estudioRepository.Atualizar(estudio);

            return StatusCode(202, "Estudio atualizado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {   
            _estudioRepository.Deletar(id);

            return StatusCode(200, "Estudio deletado!");
        }
    }
}