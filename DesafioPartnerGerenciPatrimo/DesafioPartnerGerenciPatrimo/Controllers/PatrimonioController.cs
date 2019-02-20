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
    
    public class PatrimonioController : ApiController
    {
        private const string V = "User Instance=true;";

        [AcceptVerbs("GET")]
        [Route("api/patrimonios")]
        public List<Patrimonio> ConsultarPatrimonios()
        {
            List<Patrimonio> listaPatrimonios = new List<Patrimonio>();

            SqlConnection myConnection = new SqlConnection("Server=DESKTOP-EFHGPCO\\SQLEXPRESS;" +
                                                           "Trusted_Connection=true;" +
                                                           "Database=master;" +
                                                           V +
                                                           "Connection timeout=30");


            SqlCommand myCommand = new SqlCommand("SELECT PatrimonioId,Nome,MarcaId,Descricao,NrTombo from Patrimonio", myConnection);

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

        [AcceptVerbs("GET")]
        [Route("api/patrimonios/{id}")]
        public Patrimonio ConsultarPatrimoniosPorCodigo(int id)
        {

            Patrimonio patrimonio = new Patrimonio();

            SqlConnection myConnection = new SqlConnection("Server=DESKTOP-EFHGPCO\\SQLEXPRESS;" +
                                                           "Trusted_Connection=true;" +
                                                           "Database=master;" +
                                                           "User Instance=true;" +
                                                           "Connection timeout=30");


            SqlCommand myCommand = new SqlCommand("SELECT PatrimonioId,Nome,MarcaId,Descricao,NrTombo from Patrimonio WHERE PatrimonioId=" + id, myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myReader = myCommand.ExecuteReader();

                patrimonio.PatrimonioId = Int32.Parse(myReader["PatrimonioId"].ToString());
                patrimonio.Nome = myReader["Nome"].ToString();
                patrimonio.MarcaId = Int32.Parse(myReader["MarcaId"].ToString());
                patrimonio.Descricao = myReader["Descricao"].ToString();
                patrimonio.NrTombo = Int32.Parse(myReader["NrTombo"].ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            finally
            {
                myConnection.Close();
            }

            return patrimonio;
        }

        [AcceptVerbs("POST")]
        [Route("api/patrimonios")]
        public string CadastrarPatrimonio(Patrimonio patrimonio)
        {            

            String result = "Patrimonio cadastrado com sucesso!";

            SqlConnection myConnection = new SqlConnection("Server=DESKTOP-EFHGPCO\\SQLEXPRESS;" +
                                                           "Trusted_Connection=true;" +
                                                           "Database=master;" +
                                                           "User Instance=true;" +
                                                           "Connection timeout=30");

            SqlCommand myCommand = new SqlCommand("INSERT INTO Patrimonio (PatrimonioId,Nome,MarcaId,Descricao,NrTombo) Values (" 
                                                    + patrimonio.PatrimonioId 
                                                    + ",'" 
                                                    + patrimonio.Nome
                                                    + "',"
                                                    + patrimonio.MarcaId
                                                    + ",'"
                                                    + patrimonio.Descricao
                                                    + "',"
                                                    + patrimonio.NrTombo
                                                    + ")", myConnection);

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
        [Route("api/patrimonios")]
        public string AlterarPatrimonio(Patrimonio patrimonio)
        {

            String result = "Patrimonio cadastrado com sucesso!";

            SqlConnection myConnection = new SqlConnection("Server=DESKTOP-EFHGPCO\\SQLEXPRESS;" +
                                                           "Trusted_Connection=true;" +
                                                           "Database=master;" +
                                                           "User Instance=true;" +
                                                           "Connection timeout=30");

            SqlCommand myCommand = new SqlCommand("UPDATE Patrimonio SET "                                                    
                                                    + "Nome = '" + patrimonio.Nome + "',"
                                                    + "MarcaId = " + patrimonio.MarcaId + ","
                                                    + "Descricao = '" + patrimonio.Descricao + "',"
                                                    + "NrTombo = " + patrimonio.NrTombo + " "
                                                    + "WHERE PatrimonioId = " + patrimonio.PatrimonioId, myConnection);

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
        [Route("api/patrimonios/{id}")]
        public string ExcluirPatrimonio(int codigo)
        {

            String result = "Patrimonio excluido com sucesso!";

            SqlConnection myConnection = new SqlConnection("Server=DESKTOP-EFHGPCO\\SQLEXPRESS;" +
                                                           "Trusted_Connection=true;" +
                                                           "Database=master;" +
                                                           "User Instance=true;" +
                                                           "Connection timeout=30");

            SqlCommand myCommand = new SqlCommand("DELETE Patrimonio WHERE PatrimonioId = " + codigo, myConnection);

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
