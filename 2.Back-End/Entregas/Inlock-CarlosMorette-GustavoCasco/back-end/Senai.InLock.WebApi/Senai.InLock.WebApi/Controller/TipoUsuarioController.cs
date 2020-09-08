using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controller
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
        public IEnumerable<TipoUsuarioDomain> Get()
        {
            return _tipoUsuarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain nome)
        {
            return Ok(_tipoUsuarioRepository.Inserir(nome));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id , TipoUsuarioDomain tipoUsu)
        {
            return Ok(_tipoUsuarioRepository.Atualizar(id ,tipoUsu)); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_tipoUsuarioRepository.Deletar(id));
        }
    }
}