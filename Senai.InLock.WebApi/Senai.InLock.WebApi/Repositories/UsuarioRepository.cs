using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository  : IUsuarioRepository
    {
        private string StringConexao = "Data Source= DEV11\\SQLEXPRESS; initial catalog=InLock_Manha; user Id=sa; pwd=sa@132;";

        public UsuariosDomain BuscarPorEmailSenha(string email, string senha)
        {
            // Define a conexão passando a string
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Define a query a ser executada no banco
                string querySelect = "SELECt * FROM Usuario WHERE Usuario.Email = @Email AND Usuario.Senha = @Senha";

                // Define o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    // Define o valor dos parâmetros
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    // Abre a conexão com o banco
                    con.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto usuario 
                        UsuariosDomain usuario = new UsuariosDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"])
                            ,
                            Email = rdr["Email"].ToString()
                            ,
                            
                            IdTipo = Convert.ToInt32(rdr["IdTipo"])
                            
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
