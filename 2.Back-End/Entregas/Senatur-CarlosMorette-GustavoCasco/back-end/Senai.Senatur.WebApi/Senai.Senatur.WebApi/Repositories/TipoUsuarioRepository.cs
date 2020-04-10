using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITiposUsuarioRepository
    {
        SenaturContext ctx = new SenaturContext();

        public void Atualizar(int Id, TipoUsuario attTiposUser)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuario.Find(Id);

            tipoBuscado.Titulo = attTiposUser.Titulo;

            ctx.Update(tipoBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(tp => tp.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUser)
        {
            ctx.TipoUsuario.Add(novoTipoUser);

            ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            TipoUsuario tiposBuscado = ctx.TipoUsuario.Find(Id);

            ctx.TipoUsuario.Remove(tiposBuscado);

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
