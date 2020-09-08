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
    public class UsuarioController : ControllerBase
    {
        private IUsuariosRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Listar todos os usuários
        /// </summary>
        /// <returns>Todos os usuários</returns>
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _usuarioRepository.Listar());
        }

        /// <summary>
        /// Cadastrar usuário
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns>Usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201, novoUsuario);
        }

        /// <summary>
        /// Atualizar usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="attUsuario"></param>
        /// <returns>Usuário alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario attUsuario)
        {
            try
            {
                _usuarioRepository.Atualizar(id, attUsuario);

                return StatusCode(204, attUsuario);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        /// <summary>
        /// Deletar usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Usuário deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado != null)
            {
                _usuarioRepository.Deletar(id);

                return StatusCode(200, $"Usuario Id:{id} deletado");
            }

            return StatusCode(404, "Nenhum usuário encontrado");
        }

        /// <summary>
        /// Lista usuário pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um usuário</returns>
        [Authorize(Roles = "1")]
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            return StatusCode(200, _usuarioRepository.BuscarPorId(id));
        }
    }
}