using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> Listar();

        string Inserir(UsuarioDomain usuario);

        string Atualizar(int id, UsuarioDomain usuario);

        string Deletar(int id);

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
