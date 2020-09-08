using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        /// <summary>
        /// String de conexão com o SGBD e o Banco de Dados
        /// </summary>
        private string StringConexao = "Data Source=N-1S-DEV-10\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132;";

        /// <summary>
        /// Método de listar
        /// </summary>
        /// <returns>Lista dos Funcionários</returns>
        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> list_funcionario = new List<FuncionarioDomain>();

            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string select = "EXEC listarFuncionarios";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(select, conexao))
                {
                    conexao.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        list_funcionario.Add(funcionario);
                    }
                }
            }

            return list_funcionario;

        }

        /// <summary>
        /// Inserir funcionario
        /// </summary>
        /// <param name="funcionario">Nome e Sobrenome</param>
        /// <returns>Funcionario Cadastrado</returns>
        public string Inserir(FuncionarioDomain funcionario)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string insert = "EXEC cadastrarFuncionario @Nome, @Sobrenome;";


                using (SqlCommand cmd = new SqlCommand(insert, conexao))
                {

                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            return "Funcionário Cadastrado!";
        }

        /// <summary>
        /// Atualizar funcionario
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="funcionario">Nome e Sobrenome</param>
        /// <returns>Funcionario Atualizado</returns>
        public string Atualizar(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string insert = "EXEC atualizarFuncionario @Nome, @Sobrenome, @ID";

                using (SqlCommand cmd = new SqlCommand(insert, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);

                    cmd.ExecuteNonQuery();
                }
            }

            return "Atualização Completa!";
        }

        /// <summary>
        /// Deletar funcionario
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Funcionario Deletado</returns>
        public string Deletar(int id)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string delete = "EXEC deletarFuncionario @ID";

                using (SqlCommand cmd = new SqlCommand(delete, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }
            }

            return "Funcionário Deletado!";
        }

        /// <summary>
        /// Listar funcionario por ID
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Funcionario</returns>
        public FuncionarioDomain ListarPorId(int id)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string selectWId = "EXEC listarFuncionarioPorId @ID";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(selectWId, conexao))
                {
                    conexao.Open();
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain func = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };
                        return func;
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// Listar funcionario por Nome
        /// </summary>
        /// <param name="functionario">Nome</param>
        /// <returns>Funcionario</returns>
        public FuncionarioDomain ListarPorNome(FuncionarioDomain funcionario)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string selectWNome = "EXEC listarFuncionarioPorNome @Nome";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(selectWNome, conexao))
                {
                    conexao.Open();
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FuncionarioDomain func = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };
                        return func;
                    }
                    return null;

                }
            }
        }

        /// <summary>
        /// Listar funcionario por Nome Completo
        /// </summary>
        /// <param name="funcionario">Nome Completo</param>
        /// <returns>Funcionario</returns>
        public List<FuncionarioDomain> ListarPorNomeCompleto()
        {
            List<FuncionarioDomain> list_funcionario = new List<FuncionarioDomain>();

            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string selectWNomeSobrenome = "EXEC listarFuncionarioPorNomeCompleto";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(selectWNomeSobrenome, conexao))
                {
                    conexao.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain func = new FuncionarioDomain
                        {

                            Nome = rdr["NomeCompleto"].ToString()
                        };
                        list_funcionario.Add(func);
                    }

                }
            }
            return list_funcionario;
        }
    }
}
