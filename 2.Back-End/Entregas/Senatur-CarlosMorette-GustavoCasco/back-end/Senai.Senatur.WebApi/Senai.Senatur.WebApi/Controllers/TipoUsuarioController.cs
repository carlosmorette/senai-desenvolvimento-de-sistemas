using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class TipoUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Todos os tipos de usuário</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _tipoUsuarioRepository.Listar());
        }

        /// <summary>
        /// Cadastra tipo de usuário
        /// </summary>
        /// <param name="novoTipoUser"></param>
        /// <returns>Tipo de usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Post(TipoUsuario novoTipoUser)
        {
            _tipoUsuarioRepository.Cadastrar(novoTipoUser);

            return StatusCode(201, novoTipoUser);
        }

        /// <summary>
        /// Atualiza um tipo de usuário
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="atualizaTipoUser">Tipo de Usuário atualizado</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id,TipoUsuario atualizaTipoUser)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, atualizaTipoUser);

                return StatusCode(204, atualizaTipoUser);
               
            }catch(Exception err)
            {
                return BadRequest(err);
            }
        }

        /// <summary>
        /// Deleta tipo de usuário
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>Tipo de usuário deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoUsuario usuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if(usuarioBuscado != null)
            {
                _tipoUsuarioRepository.Deletar(id);

                return StatusCode(200, $"Tipo Usuario Id:{id} deletado");
            }

            return StatusCode(404, "Nenhum tipo usuário encontrado");
        }

        /// <summary>
        /// Um tipo de usuário
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Um tipo de usuário</returns>
        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            return StatusCode(200, _tipoUsuarioRepository.BuscarPorId(id));
        }
    }
}