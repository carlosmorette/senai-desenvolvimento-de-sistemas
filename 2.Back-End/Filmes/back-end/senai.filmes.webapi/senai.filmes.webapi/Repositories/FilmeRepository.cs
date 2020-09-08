using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository : IFilmesRepository
    {
        private string StringConexao = "Data Source=N-1S-DEV-10\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132;";

        //----------------//
        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string queryAll = "SELECT * FROM Filmes";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryAll, conexao))
                {
                    conexao.Open();

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            Titulo = rdr["Titulo"].ToString(),

                            IdGenero = Convert.ToInt32(rdr[2])
                        };

                        filmes.Add(filme);
                    }
                }
            }

            return filmes;
        }

        public string Cadastrar(FilmeDomain filme)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string insert = "INSERT INTO Filmes(Titulo, IdGenero) VALUES (@Titulo, @ID)";

                using (SqlCommand cmd = new SqlCommand(insert, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@ID", filme.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }

            return "Cadastrado - Sucess";
        }

        public string Atualizar(FilmeDomain filme, int id)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string update = "UPDATE Filmes SET Titulo = @Titulo, IdGenero = @IDGenero WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(update, conexao))
                {
                    conexao.Open();

                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IDGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();
                }
            }

            return "Atualizado - Sucess";
        }

        public string Deletar(int id)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string delete = "DELETE FROM Filmes WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(delete, conexao))
                {
                    conexao.Open();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }
            }

            return "Deletado - Sucess";
        }

        public FilmeDomain ListarPorID(int id)
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string selectById = "SELECT * FROM Filmes WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(selectById, conexao))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    conexao.Open();

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = rdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"])
                        };
                        return filme;
                    }
                    return null;
                }
            }
        }

        public FilmeDomain ListarFilmesGeneros()
        {
            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string selectInnerJoin = "SELECT Filmes.IdFilme, Filmes.Titulo, Generos.Nome FROM Filmes INNER JOIN Generos ON Filmes.IdGenero = Generos.IdGenero ";

                using (SqlCommand cmd = new SqlCommand(selectInnerJoin, conexao))
                {
                    conexao.Open();

                    SqlDataReader rdr;

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain();
                        filme.IdFilme = Convert.ToInt32(rdr["IdFilme"]);
                        filme.Titulo = rdr["Titulo"].ToString();
                        filme.Genero = new GeneroDomain()
                        {
                            Nome = rdr["Nome"].ToString()
                        };

                        return filme;
                    }

                    return null;
                    
                }
            }
            
        }

    }
}
