using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repository;

namespace Senai.Peoples.WebApi.Controllers
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
        public IEnumerable<UsuarioDomain> Get()
        {
            return _usuarioRepository.Listar();
        }

        [HttpGet("{id}")]
        public UsuarioDomain GetById(int id)
        {
            return _usuarioRepository.ListarPorId(id);
        }

        [HttpPost]
        public string Post(UsuarioDomain usuario)
        {
            return _usuarioRepository.Inserir(usuario);
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _usuarioRepository.Deletar(id);
        }

        [HttpPut("{id}")]
        public string Put(int id, UsuarioDomain usuario)
        {
            return _usuarioRepository.Atualizar(id, usuario);
        }
    }
}