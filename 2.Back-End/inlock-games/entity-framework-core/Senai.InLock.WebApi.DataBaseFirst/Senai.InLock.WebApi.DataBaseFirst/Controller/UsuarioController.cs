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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }
           
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);

            return StatusCode(201, $"Usuario Id:{usuario.IdUsuario} cadastrado!");
        }

        [HttpPut]
        public IActionResult Put(Usuario usuario)
        {
            _usuarioRepository.Atualizar(usuario);

            return StatusCode(200, usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.Deletar(id);

            return StatusCode(200, $"Usuario Id:{id} deletado!");
        }
    }
}