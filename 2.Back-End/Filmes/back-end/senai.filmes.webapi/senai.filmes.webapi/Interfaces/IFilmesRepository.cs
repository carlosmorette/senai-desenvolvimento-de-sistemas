using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    interface IFilmesRepository
    {
        List<FilmeDomain> Listar();

        string Cadastrar(FilmeDomain filme);

        string Atualizar(FilmeDomain filme , int id);

        string Deletar(int id);

        FilmeDomain ListarPorID(int id);

        FilmeDomain ListarFilmesGeneros();
    }
}
