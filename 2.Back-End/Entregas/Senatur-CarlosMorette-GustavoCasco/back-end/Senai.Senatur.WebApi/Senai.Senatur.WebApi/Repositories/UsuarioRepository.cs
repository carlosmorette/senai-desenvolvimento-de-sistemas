using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        SenaturContext ctx = new SenaturContext();
        
        public void Atualizar(int Id, Usuario attUser)
        {
            Usuario usuariosBuscado = ctx.Usuario.Find(Id);

            usuariosBuscado.Email = attUser.Email;

            usuariosBuscado.Senha = attUser.Senha;

            usuariosBuscado.IdTipoUsuario = attUser.IdTipoUsuario;

            ctx.Update(usuariosBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
           return ctx.Usuario.FirstOrDefault(user => user.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUser)
        {
            ctx.Usuario.Add(novoUser);

            ctx.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Usuario usuariosBuscado = ctx.Usuario.Find(Id);

            ctx.Usuario.Remove(usuariosBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.Include(e => e.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario BuscarSenhaEmail(string email, string senha)
        {         
            return ctx.Usuario.FirstOrDefault(user => user.Email == email && user.Senha == senha);
        }
    }
}
