using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    public class FilmesRepository : IFilmesRepository
    {
        private string stringConexao = "Data Source= DEV11\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132;";

        public List<FilmeDomain> ListarFilme()
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                List<FilmeDomain> lista = new List<FilmeDomain>();

                string queryBuscar = "SELECT IdFilme, Titulo, IdGenero FROM Filmes";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(rdr[2])
                        };

                        lista.Add(filme);
                    }
                    return lista;
                }
            }
        }

        public FilmeDomain BuscarFilmeId(int id)
        {

            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryBuscarUm = "select IdFilme, Titulo, IdGenero FROM Filmes WHERE IdFilme = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarUm, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(rdr[2])
                        };
                        return filme;
                    }
                    return null;
                }

            }
        }

        public void CadastrarFilme(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryCadastro = "INSERT INTO Filmes(Titulo,IdGenero) VALUES (@Titulo, @ID)";

                SqlCommand cmd = new SqlCommand(queryCadastro, con);

                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                cmd.Parameters.AddWithValue("@ID", filme.IdGenero);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void AtualizarFilme(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryAtualizar = "UPDATE Filmes SET Titulo=@Titulo WHERE IdFilme=@ID";

                using (SqlCommand cmd = new SqlCommand(queryAtualizar, con))
                {

                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void DeletarFilme(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDeletar = "DELETE FROM Filmes WHERE IdFilme = @ID";
                using (SqlCommand cmd = new SqlCommand(queryDeletar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarFilmeComGenero()
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                List<FilmeDomain> lista = new List<FilmeDomain>();

                string queryBuscar = "SELECT Filmes.Titulo, Generos.Nome FROM Filmes INNER JOIN Generos ON Filmes.IdGenero = Generos.IdGenero";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                   
                            Titulo = rdr["Titulo"].ToString(),
                            Genero = new GeneroDomain
                            { 
                                Nome = rdr[1].ToString()
                            }
                        };
                    lista.Add(filme);
                    }

                }
                return lista;
            }
        }
    }
}
