using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
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

        [HttpGet("{id}")]
        public TipoUsuarioDomain GetByID(int id)
        {
            return _tipoUsuarioRepository.ListarPorId(id);
        }

        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain titulo)
        {
            return Ok(_tipoUsuarioRepository.Inserir(titulo));
        }

        [HttpPut("{id}")]
        public string Put(int id, TipoUsuarioDomain titulo)
        {
            return _tipoUsuarioRepository.Atualizar(id, titulo);
        }

        [HttpDelete("{id}")]
        public string Delete (int id)
        {
            return _tipoUsuarioRepository.Deletar(id);
        }
    }
}
