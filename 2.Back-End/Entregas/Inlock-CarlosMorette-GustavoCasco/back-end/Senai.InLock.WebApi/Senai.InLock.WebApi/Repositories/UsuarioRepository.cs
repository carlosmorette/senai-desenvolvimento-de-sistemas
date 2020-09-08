using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source=N-1S-DEV-10\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> usuarios = new List<UsuarioDomain>();

            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string select = "SELECT Usuario.IdUsuario, Usuario.Email, Usuario.Senha, Usuario.IdUsuario, TipoUsuario.IdTipoUsuario ,TipoUsuario.Titulo FROM Usuario INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario ";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(select, conexao))
                {
                    conexao.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                Titulo = rdr["Titulo"].ToString(),
                            }
                        };

                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

        public string Inserir(UsuarioDomain usuario)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string insert = "INSERT INTO Usuario(Email, Senha, IdTipoUsuario) VALUES(@Email, @Senha, @Id)";

                using (SqlCommand cmd = new SqlCommand(insert, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@Id", usuario.IdTipoUsuario);

                    cmd.ExecuteNonQuery();
                }
            }

            return "Usuário Cadastrado!";
        }

        public string Atualizar(int id, UsuarioDomain usuario)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string update = "UPDATE Usuario SET Email = @Email, Senha = @Senha, IdTipoUsuario = @IdTipoUsuario WHERE IdUsuario = @Id";

                using (SqlCommand cmd = new SqlCommand(update, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@Email", usuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                    cmd.Parameters.AddWithValue("@IdTipoUsuario", usuario.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }

            return "Usuário Atualizado!";
        }

        public string Deletar(int id)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string delete = "DELETE FROM Usuario WHERE IdUsuario = @Id";

                using (SqlCommand cmd = new SqlCommand(delete, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }

            return "Usuário Deletado!";
        }

        public UsuarioDomain BuscarPorEmailSenha (string email, string senha)
        {
            using(SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string selectEmailSenha = "SELECT* FROM Usuario WHERE(Email = @Email) AND(Senha = @Senha)";

                using(SqlCommand cmd = new SqlCommand(selectEmailSenha, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                            TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                Titulo = rdr[1].ToString()
                            }
                        };
                            
                        return usuario;
                    }
                }
            return null;
            }

        }
    }
}
