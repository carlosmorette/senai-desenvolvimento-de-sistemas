using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface ITiposUsuarioRepository
    {
        List<TipoUsuario> Listar();

        void Cadastrar(TipoUsuario novoTipoUser);

        void Atualizar(int Id, TipoUsuario attTiposUser);

        void Deletar(int Id);

        TipoUsuario BuscarPorId(int id);
    }
}
