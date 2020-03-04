using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudiosRepository : IEstudiosRepository
    {
         private string StringConexao = "Data Source= DEV11\\SQLEXPRESS; initial catalog=InLock_Manha; user Id=sa; pwd=sa@132;";

          public void CadastrarEstudio(EstudiosDomain novoEstudio)
        {        
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO Estudios(NomeEstudio) VALUES (@NomeEstudios)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@NomeEstudios", novoEstudio.NomeEstudio);
                    

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}