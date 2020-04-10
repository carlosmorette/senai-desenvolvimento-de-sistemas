using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<UsuarioDomain> Listar();

        UsuarioDomain ListarPorId(int id);

        string Inserir(UsuarioDomain usuario);

        string Atualizar(int id, UsuarioDomain usuario);

        string Deletar(int id);

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
