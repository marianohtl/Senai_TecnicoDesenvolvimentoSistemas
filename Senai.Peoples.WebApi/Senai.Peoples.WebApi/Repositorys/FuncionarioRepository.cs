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

        //private string stringConexao = "Data Source= DEV11\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132;";
        private string stringConexao = "Data Source= LAPTOP-N0M1J6M8\\SQLSERVER; initial catalog=M_Peoples; integrated security=true";
        
        public List<FuncionarioDomain> ListarFuncionarios()
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                List<FuncionarioDomain> lista = new List<FuncionarioDomain>();

                string queryBuscar = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";
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
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
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
                string queryBuscar = "SELECT IdFuncionario, Nome,Sobrenome,DataNascimento FROM Funcionarios Where IdFuncionario = @ID";


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
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])

                        };
                        return funcionario;
                    }
                    return null;

                }

            }
        }
        public FuncionarioDomain BuscarFuncionarioPorNome(string name)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscar = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios Where Nome = @name";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])

                        };
                        return funcionario;
                    }
                    return null;
                }
            }
        }

        public void CadastrarFuncionario(FuncionarioDomain funcionarios)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string sqlInsert = "INSERT INTO Funcionarios(Nome, Sobrenome, DataNascimento) VALUES(@Nome,@Sobrenome,@Nascimento) ";
                using (SqlCommand cmd = new SqlCommand(sqlInsert, con))
                {

                    cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);
                    cmd.Parameters.AddWithValue("@Nascimento", funcionarios.DataNascimento);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void AtualizarFuncionario(int id,FuncionarioDomain FuncionarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string sqlAlter = "UPDATE Funcionarios SET Nome=@nome, Sobrenome=@sobrenome, DataNascimento=@Nascimento WHERE IdFuncionario=@ID";
                using (SqlCommand cmd = new SqlCommand(sqlAlter, con))
                {

                    cmd.Parameters.AddWithValue("@nome",FuncionarioAtualizado.Nome);
                    cmd.Parameters.AddWithValue("@sobrenome", FuncionarioAtualizado.Sobrenome);
                    cmd.Parameters.AddWithValue("@Nascimento", FuncionarioAtualizado.DataNascimento);
                    cmd.Parameters.AddWithValue("@ID", id);
                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Deleta um funcionário através do seu ID
        /// </summary>
        /// <param name="id">ID do funcionário que será deletado</param>
        public void DeletarFuncionario(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Funcionarios WHERE IdFuncionario = @ID";
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> ListarNomeSobrenome()
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                List<FuncionarioDomain> listaNomes = new List<FuncionarioDomain>();

                string queryBuscar = "SELECT Nome, Sobrenome FROM Funcionarios";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain nomeFuncionario = new FuncionarioDomain
                        {

                            NomesCompletos = rdr["Nome"].ToString() + " " + rdr["Sobrenome"].ToString()

                        };

                        listaNomes.Add(nomeFuncionario);
                    }
                    return listaNomes;
                }
            }
        }

       
        public List<FuncionarioDomain> ListaOrdenada(string ordem)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                List<FuncionarioDomain> listaOrdenada = new List<FuncionarioDomain>();

                string queryBuscar = "SELECT Nome, Sobrenome FROM Funcionarios order by Nome "+ ordem;
                if (ordem == "asc" || ordem == "desc" || ordem == "ASC" || ordem == "DESC")
                {

                    
                    con.Open();
                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(queryBuscar, con))
                    {
                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            FuncionarioDomain funcionariosOrdenados = new FuncionarioDomain
                            {
                                Nome = rdr["Nome"].ToString(),
                                Sobrenome = rdr["Sobrenome"].ToString()

                            };
                            listaOrdenada.Add(funcionariosOrdenados);
                        }
                        return listaOrdenada;
                    }

                }
                else
                {
                    return null;
                }
            }
            }

        }
    }
  
