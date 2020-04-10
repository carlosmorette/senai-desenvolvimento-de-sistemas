using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IUsuariosRepository
    {
        List<Usuario> Listar();

        void Cadastrar(Usuario novoUser);

        void Atualizar(int Id, Usuario attUser);

        void Deletar(int Id);

        Usuario BuscarPorId(int id);

        Usuario BuscarSenhaEmail(string email, string senha);
    }
}
