using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private string stringConexao = "Data Source=N-1S-DEV-10\\SQLEXPRESS; initial catalog=InLock_Games_Manha; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Listar jogos
        /// </summary>
        /// <returns>Lista de jogos</returns>
        public List<JogoDomain> Listar()
        {
            List<JogoDomain> Jogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querylistar = "SELECT IdJogo, NomeJogo, DataLancamento, Valor, Estudio.IdEstudio, Estudio.NomeEstudio FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querylistar, con))
                {

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        JogoDomain jogo = new JogoDomain
                        {

                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                            NomeJogo = rdr["NomeJogo"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = Convert.ToDouble(rdr["Valor"]),

                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                NomeEstudio = rdr["NomeEstudio"].ToString(),
                            }

                        };

                        Jogo.Add(jogo);
                    }
                }

                return Jogo;
            }
        }

        public JogoDomain GetporId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querylistar = "SELECT IdJogo, NomeJogo, DataLancamento, Valor, Estudio.IdEstudio, Estudio.NomeEstudio FROM Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio WHERE IdJogo = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querylistar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                            NomeJogo = rdr["NomeJogo"].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                            Valor = Convert.ToDouble(rdr["Valor"]),

                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Estudio = new EstudioDomain
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                NomeEstudio = rdr["NomeEstudio"].ToString(),
                            }

                        };

                        return jogo;
                    }

                    return null;
                }
            }
        }


        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(int id, JogoDomain jogoatualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Jogo SET NomeJogo = @NomeJogo WHERE IdJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NomeJogo", jogoatualizado.NomeJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Cadastrar(JogoDomain NovoJogo)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO Jogo(NomeJogo, Descricao, DataLancamento, Valor, IdEstudio) VALUES (@NomeJogo, @Descricao, @DataLancamento, @Valor, @IdEstudio )";


                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@NomeJogo", NovoJogo.NomeJogo);

                    cmd.Parameters.AddWithValue("@Descricao", NovoJogo.Descricao);

                    cmd.Parameters.AddWithValue("@DataLancamento", NovoJogo.DataLancamento);

                    cmd.Parameters.AddWithValue("@Valor", NovoJogo.Valor);

                    cmd.Parameters.AddWithValue("@IdEstudio", NovoJogo.IdEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}