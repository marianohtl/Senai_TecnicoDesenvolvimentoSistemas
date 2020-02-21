using Senai.Peoples.WebApi.Controllers;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositorys
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private string stringConexao = "Data Source= DEV11\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132;";

        public List<FuncionarioDomain> ListarFuncionarios()
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                List<FuncionarioDomain> lista = new List<FuncionarioDomain>();

                string queryBuscar = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        lista.Add(funcionario);
                    }
                    return lista;
                }
            }
        }

        public FuncionarioDomain BuscarFuncionario(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscar = "SELECT IdFuncionario, Nome,Sobrenome FROM Funcionarios Where IdFuncionario = @ID";


                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };
                        return funcionario;
                    }
                    return null;

                }

            }



            /*
        public void AtualizarFuncionario()
        {
            throw new NotImplementedException();
        }


        public void DeletarFuncionario()
        {
            throw new NotImplementedException();
        }


            */
        }

        public void CadastrarFuncionario(FuncionarioDomain funcionarios)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string sqlInsert = "INSERT INTO Funcionarios(Nome, SOBRENOME) VALUES(@Nome,@Sobrenome) ";
                using (SqlCommand cmd = new SqlCommand(sqlInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void AtualizarFuncionario(int id,FuncionarioDomain FuncionarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string sqlAlter = "UPDATE Funcionarios SET Nome=@nome, Sobrenome=@sobrenome WHERE IdFuncionario=@ID";
                using (SqlCommand cmd = new SqlCommand(sqlAlter, con))
                {

                    cmd.Parameters.AddWithValue("@nome",FuncionarioAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@sobrenome", FuncionarioAtualizado.Sobrenome);
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}