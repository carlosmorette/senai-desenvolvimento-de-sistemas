using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string StringConexao = "Data Source=N-1S-DEV-10\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";
        
        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> lista = new List<TipoUsuarioDomain>();

            using(SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string select = "SELECT * FROM TipoUsuario";

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(select, conexao))
                {
                    conexao.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuario = new TipoUsuarioDomain
                        {

                            IdTipoUsuario = Convert.ToInt32(rdr[0]),
 
                            Titulo = rdr["Titulo"].ToString()
                        };

                        lista.Add(tipoUsuario);
                    }

                }
            }
            return lista;
        }


        public string Inserir(TipoUsuarioDomain nome)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string insert = "INSERT INTO TipoUsuario(Titulo) VALUES(@Titulo)";

                using (SqlCommand cmd = new SqlCommand(insert, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@Titulo", nome.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }      
                return "Tipo Usuário Cadastrado!";
        }

        public string Atualizar(int id,TipoUsuarioDomain tipoUsu)
        {
            using(SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string update = "UPDATE TipoUsuario SET Titulo = @Value WHERE IdTipoUsuario = @Id";

                using(SqlCommand cmd = new SqlCommand(update, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@Value", tipoUsu.Titulo);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }

            return "Tipo Usuário Atualizado!";
        }

        public string Deletar(int id)
        {
            using(SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string delete = "DELETE FROM TipoUsuario WHERE IdTipoUsuario = @Id";

                using(SqlCommand cmd = new SqlCommand(delete, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
                return "Tipo Usuário Deletado!";

            }
        }

    }
}
