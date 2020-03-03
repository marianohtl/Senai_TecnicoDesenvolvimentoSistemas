using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private string StringConexao = "Data Source= DEV11\\SQLEXPRESS; initial catalog=InLock_Manha; user Id=sa; pwd=sa@132;";

        public void CadastrarJogo(JogosDomain novoJogo)
        {
        
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Jogos(NomeJogo, Descricao, DataLancamento, IdEstudio, Valor) VALUES (@Nome, @Descricao, @DataLancamento,@IdEstudio,@Valor)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao",novoJogo.Descricao );
                    cmd.Parameters.AddWithValue("@DataLancamento",novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<JogosDomain> ListarJogos()
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                List<JogosDomain> lista = new List<JogosDomain>();

                string queryBuscar = "SELECT Jogos.NomeJogo,Jogos.Valor, Estudios.NomeEstudio FROM Jogos INNER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain jogos = new JogosDomain
                        {

                            NomeJogo = rdr["NomeJogo"].ToString(),
                            Valor = Convert.ToDecimal(rdr["Valor"]),
                            
                            Estudio  = new EstudiosDomain
                            {
                                NomeEstudio = rdr["NomeEstudio"].ToString()
                       
                            }
                        };
                        lista.Add(jogos);
                    }
                    return lista;
                }
            }
        }
    }
}
