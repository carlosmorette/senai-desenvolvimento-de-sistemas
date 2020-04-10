using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string StringConexao = "Data Source=N-1S-DEV-10\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132;";

        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> lista_tipousuario = new List<TipoUsuarioDomain>();

            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string select = "SELECT * FROM TipoUsuario";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(select, conexao))
                {
                    conexao.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain funcionario = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        lista_tipousuario.Add(funcionario);
                    }
                }
            }

            return lista_tipousuario;
        }

        public TipoUsuarioDomain ListarPorId(int id)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string selectById = "SELECT * FROM TipoUsuario WHERE IdTipoUsuario = @ID";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(selectById, conexao))
                {
                    conexao.Open();
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString()
                        };
                        return tipoUsuario;
                    }
                    return null;
                }
            }
        }

        public string Inserir(TipoUsuarioDomain titulo)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string inserir = "INSERT INTO TipoUsuario(Titulo) VALUES (@TITULO)";

                using (SqlCommand cmd = new SqlCommand(inserir, conexao))
                {

                    cmd.Parameters.AddWithValue("@TITULO", titulo.Titulo);

                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
                    return "Tipo Usuario Cadastrado!";
        }

        public string Atualizar(int id, TipoUsuarioDomain titulo)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string update = "UPDATE TipoUsuario SET Titulo = @Titulo WHERE IdTipoUsuario = @Id";

                using (SqlCommand cmd = new SqlCommand(update, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Titulo", titulo.Titulo);

                    conexao.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            return "Tipo Usuario Atualizado!";
        }

        public string Deletar(int id)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string delete = "DELETE FROM TipoUsuario WHERE IdTipoUsuario = @Id";

                using (SqlCommand cmd = new SqlCommand(delete, conexao))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conexao.Open();

                    cmd.ExecuteNonQuery();

                }
            }
            return "Tipo Usuario Deletado";
        }
    }
}
