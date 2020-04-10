using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> Listar();

        string Inserir(TipoUsuarioDomain nome);

        string Atualizar(int id,TipoUsuarioDomain tipoUsu);

        string Deletar(int id);
    }
}
