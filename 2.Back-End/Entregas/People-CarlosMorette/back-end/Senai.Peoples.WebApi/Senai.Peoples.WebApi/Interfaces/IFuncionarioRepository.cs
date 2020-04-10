using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        /// <summary>
        /// Listar
        /// </summary>
        /// <returns>Lista dos funcionarios</returns>
        List<FuncionarioDomain> Listar();

        /// <summary>
        /// Inserir funcionario
        /// </summary>
        /// <param name="funcionario">Nome e Sobrenome</param>
        /// <returns>Funcionario Cadastrado</returns>
        string Inserir(FuncionarioDomain funcionario);

        /// <summary>
        /// Atualizar funcionario
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="funcionario">Nome e Sobrenome</param>
        /// <returns>Funcionario Atualizado</returns>
        string Atualizar(int id, FuncionarioDomain funcionario);

        /// <summary>
        /// Deletar funcionario
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Funcionario Deletado</returns>
        string Deletar(int id);

        /// <summary>
        /// Listar funcionario por ID
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Funcionario</returns>
        FuncionarioDomain ListarPorId(int id);

        /// <summary>
        /// Listar funcionario por Nome
        /// </summary>
        /// <param name="functionario">Nome</param>
        /// <returns>Funcionario</returns>
        FuncionarioDomain ListarPorNome(FuncionarioDomain functionario);


        /// <summary>
        /// Listar funcionario por Nome Completo
        /// </summary>
        /// <param name="funcionario">Nome Completo</param>
        /// <returns>Funcionario</returns>
        List<FuncionarioDomain> ListarPorNomeCompleto();
    }
}
