using DesafioPartnerGerenciPatrimo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DesafioPartnerGerenciPatrimo.Controllers
{
    
    public class MarcaController : ApiController
    {
        
        [AcceptVerbs("GET")]
        [Route("api/marcas")]
        public List<Marca> ConsultarMarca()
        {
            List<Marca> listaMarcas = new List<Marca>();

            SqlConnection myConnection = new SqlConnection("Server=DESKTOP-EFHGPCO\\SQLEXPRESS;" +
                                                           "Trusted_Connection=true;" +
                                                           "Database=master;" +
                                                           "User Instance=true;" +
                                                           "Connection timeout=30");


            SqlCommand myCommand = new SqlCommand("SELECT MarcaId, Nome FROM Marca", myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Marca marca = new Marca();

                    marca.MarcaId = Int32.Parse(myReader["MarcaId"].ToString());
                    marca.Nome = myReader["Nome"].ToString();

                    listaMarcas.Add(marca);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            finally
            {
                myConnection.Close();
            }

            return listaMarcas;
        }

        [AcceptVerbs("GET")]
        [Route("api/marcas/{id}")]
        public Marca ConsultarMarcaPorCodigo(int id)
        {

            Marca marca = new Marca();

            SqlConnection myConnection = new SqlConnection("Server=DESKTOP-EFHGPCO\\SQLEXPRESS;" +
                                                           "Trusted_Connection=true;" +
                                                           "Database=master;" +
                                                           "User Instance=true;" +
                                                           "Connection timeout=30");


            SqlCommand myCommand = new SqlCommand("SELECT MarcaId, Nome FROM Marca WHERE MarcaId="+id, myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myReader = myCommand.ExecuteReader();

                marca.MarcaId = Int32.Parse(myReader["MarcaId"].ToString());
                marca.Nome = myReader["Nome"].ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            finally
            {
                myConnection.Close();
            }

            return marca;
        }

        [AcceptVerbs("GET")]
        [Route("api/marcas/{id}/patrimonios")]
        public List<Patrimonio> ConsultarPatrimoniosPorMarca(int id)
        {
            List<Patrimonio> listaPatrimonios = new List<Patrimonio>();

            SqlConnection myConnection = new SqlConnection("Server=DESKTOP-EFHGPCO\\SQLEXPRESS;" +
                                                           "Trusted_Connection=true;" +
                                                           "Database=master;" +
                                                           "User Instance=true;" +
                                                           "Connection timeout=30");


            SqlCommand myCommand = new SqlCommand("SELECT PatrimonioId,Nome,MarcaId,Descricao,NrTombo from Patrimonio WHERE MarcaId="+id, myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Patrimonio patrimonio = new Patrimonio();

                    patrimonio.PatrimonioId = Int32.Parse(myReader["PatrimonioId"].ToString());
                    patrimonio.Nome = myReader["Nome"].ToString();
                    patrimonio.MarcaId = Int32.Parse(myReader["MarcaId"].ToString());
                    patrimonio.Descricao = myReader["Descricao"].ToString();
                    patrimonio.NrTombo = Int32.Parse(myReader["NrTombo"].ToString());

                    listaPatrimonios.Add(patrimonio);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            finally
            {
                myConnection.Close();
            }

            return listaPatrimonios;
        }

        [AcceptVerbs("POST")]
        [Route("api/marcas")]
        public string CadastrarMarca(Marca marca)
        {

            String result = "Marca cadastrado com sucesso!";

            SqlConnection myConnection = new SqlConnection("Server=DESKTOP-EFHGPCO\\SQLEXPRESS;" +
                                                           "Trusted_Connection=true;" +
                                                           "Database=master;" +
                                                           "User Instance=true;" +
                                                           "Connection timeout=30");

            SqlCommand myCommand = new SqlCommand("INSERT INTO Marca (Nome, MarcaId) Values ('" + marca.Nome+"'," + marca.MarcaId+ ")", myConnection);
            
            try
            {
                myConnection.Open();

                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                result = e.Message.ToString();
            }
            finally
            {
                myConnection.Close();
            }        

            return result;
        }

        [AcceptVerbs("PUT")]
        [Route("api/marcas")]
        public string AlterarMarca(Marca marca)
        {

            String result = "Marca cadastrado com sucesso!";

            SqlConnection myConnection = new SqlConnection("Server=DESKTOP-EFHGPCO\\SQLEXPRESS;" +
                                                           "Trusted_Connection=true;" +
                                                           "Database=master;" +
                                                           "User Instance=true;" +
                                                           "Connection timeout=30");

            SqlCommand myCommand = new SqlCommand("UPDATE Marca SET Nome = '"+ marca .Nome+ "' WHERE MarcaId = "+ marca.MarcaId, myConnection);

            try
            {
                myConnection.Open();

                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                result = e.Message.ToString();
            }
            finally
            {
                myConnection.Close();
            }
                       
            return result;
        }

        [AcceptVerbs("DELETE")]
        [Route("api/marcas/{id}")]
        public string ExcluirMarca(int codigo)
        {

            String result = "Marca excluida com sucesso!";

            SqlConnection myConnection = new SqlConnection("Server=DESKTOP-EFHGPCO\\SQLEXPRESS;" +
                                                           "Trusted_Connection=true;" +
                                                           "Database=master;" +
                                                           "User Instance=true;" +
                                                           "Connection timeout=30");

            SqlCommand myCommand = new SqlCommand("DELETE Marca WHERE MarcaId = " + codigo, myConnection);

            try
            {
                myConnection.Open();

                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                result = e.Message.ToString();
            }
            finally
            {
                myConnection.Close();
            }
                       
            return result;
        }
    }
}
