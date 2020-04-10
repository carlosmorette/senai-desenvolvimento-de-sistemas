using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.DataBaseFirst.Repositories;

namespace Senai.InLock.WebApi.DataBaseFirst.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            _tipoUsuarioRepository.Cadastrar(tipoUsuario);

            return StatusCode(201, "Tipo Usuario cadastrado!");
        }

        [HttpPut]
        public IActionResult Put(TipoUsuario tipoUsuario)
        {
            _tipoUsuarioRepository.Atualizar(tipoUsuario);

            return StatusCode(204, "Tipo Usuario atualizado!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tipoUsuarioRepository.Deletar(id);

            return StatusCode(204, "Tipo Usuario deletado!");
        }
    }
}