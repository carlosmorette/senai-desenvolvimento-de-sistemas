using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source=N-1S-DEV-10\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132;";

        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> lista_usuario = new List<UsuarioDomain>();

            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string select = "SELECT * FROM Usuario";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(select, conexao))
                {
                    conexao.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr[4])
                        };

                        lista_usuario.Add(usuario);
                    }
                }
            }

            return lista_usuario;
        }

        public UsuarioDomain ListarPorId(int id)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string selectById = "SELECT* FROM Usuario WHERE IdUsuario = @Id";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(selectById, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    conexao.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr[4])
                        };

                        return usuario;
                    }

                    return null;
                }
            }
        }

        public string Inserir(UsuarioDomain usuario)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string inserir = "INSERT INTO Usuario(Nome, Email, Senha, IdTipoUsuario) VALUES(@Nome, @Email, @Senha, @Id)";

                using (SqlCommand cmd = new SqlCommand(inserir, conexao))
                {
                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@Id", usuario.IdTipoUsuario);

                    conexao.Open();

                    cmd.ExecuteNonQuery();
                }

                return "Usuário inserido";
            }
        }

        public string Deletar(int id)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string delete = "DELETE FROM Usuario WHERE IdUsuario = @Id";

                using (SqlCommand cmd = new SqlCommand(delete, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    conexao.Open();

                    cmd.ExecuteNonQuery();
                }

                return "Usuário Deletado";
            }
        }

        public string Atualizar(int id, UsuarioDomain usuario)
        {
            using(SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string update = $"UPDATE Usuario SET Nome = @Nome, Email = @Email, Senha = @Senha, IdTipoUsuario = @IdTipoUsuario WHERE IdUsuario = @Id";

                using (SqlCommand cmd = new SqlCommand(update, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", usuario.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }

                return "Usuário Atualizado";
            }
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Retorna um usuário validado</returns>
        public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            // Define a conexão passando a string
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Define a query a ser executada no banco
                string querySelect = "SELECT* FROM Usuario WHERE(Email = @Email) AND(Senha = @Senha)";

                SqlDataReader rdr;

                // Define o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define o valor dos parâmetros
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    // Abre a conexão com o banco
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto usuario 
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"])
                            ,
                            Email = rdr["Email"].ToString()
                            ,
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"])
                            ,
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                Titulo = rdr["Titulo"].ToString()
                            }
                        };

                        // Retorna o usuario buscado
                        return usuario;
                    }
                }

                // Caso não encontre um email e senha correspondente, retorna null
                return null;
            }
        }
    }
}
