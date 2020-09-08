using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório Genero
    /// </summary>
    interface IGeneroRepository
    {
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        List<GeneroDomain> Listar();

        /// <summary>
        /// Cadastra um gênero
        /// </summary>
        /// <returns>Retorna um gênero cadastrado</returns>
        void Cadastrar(GeneroDomain genero);

        /// <summary>
        /// Deletar um genero
        /// </summary>
        /// <param name="id">Id do genero</param>
        void Deletar(int id);

        /// <summary>
        /// Atualizar um genero
        /// </summary>
        /// <param name="nome">Nome do genero</param>
        void Atualizar(GeneroDomain genero);

        /// <summary>
        /// Listar generos por id
        /// </summary>
        /// <param name="id">Id do genero</param>
        /// <returns></returns>
        GeneroDomain ListarPorId(int id);
    }
}
