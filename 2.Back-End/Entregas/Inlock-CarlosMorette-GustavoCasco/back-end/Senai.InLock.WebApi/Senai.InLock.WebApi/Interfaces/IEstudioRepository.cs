using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IEstudioRepository 
    {
        List<EstudioDomain> Listar();

        void Cadastrar(EstudioDomain novoestudio);

        void Atualizar(int id, EstudioDomain estudioadd);

        void Delete(int id);

        EstudioDomain GetporId(int id);
    }
}
