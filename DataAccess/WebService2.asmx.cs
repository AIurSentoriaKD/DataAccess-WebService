using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;    //  sql server
using System.Data;              // datos generales
using System.Configuration;     // archivos de conf
namespace DataAccess
{
    /// <summary>
    /// Descripción breve de WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {
        private static string cadenaconexion = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        
        [WebMethod(Description ="Listar Escuela con Procedure :: Metodo CT.SP")]
        public DataSet Listar()
        {
            using (SqlConnection conn = new SqlConnection(cadenaconexion))
            {
                SqlCommand comando = new SqlCommand("spListarEscuela", conn);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data;
            }
        }
        /*
        // Metodo con dataset
        [WebMethod(Description = "Agregar Escuela con Procedure :: Metodo CT.SP")]
        public DataSet AgregarEscuela(string CodEscuela, string Escuela, string Facultad)
        {
            
            using (SqlConnection conn = new SqlConnection(cadenaconexion))
            {
                SqlCommand comando = new SqlCommand("spAgregarEscuela", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodEscuela", CodEscuela);
                comando.Parameters.AddWithValue("@Escuela", Escuela);
                comando.Parameters.AddWithValue("@Facultad", Facultad);
                
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data;
            }
        }
        */
        [WebMethod(Description = "Agregar Escuela con Procedure :: Metodo CT.SP")]
        public string[] AgregarEscuela(string CodEscuela, string Escuela, string Facultad)
        {
            using (SqlConnection conn = new SqlConnection(cadenaconexion))
            {
                SqlCommand comando = new SqlCommand("spAgregarEscuela", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodEscuela", CodEscuela);
                comando.Parameters.AddWithValue("@Escuela", Escuela);
                comando.Parameters.AddWithValue("@Facultad", Facultad);

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return new string[] { data.Tables[0].Rows[0]["CodError"].ToString(), data.Tables[0].Rows[0]["Mensaje"].ToString() };
            }
        }
        [WebMethod(Description = "Actualizar Escuela :: Metodo CT.SP")]
        public String[] ActualizarEscuela(string CodEscuela, string escuela = "", string facultad = "")
        {
            using (SqlConnection conn = new SqlConnection(cadenaconexion))
            {
                SqlCommand comando = new SqlCommand("spActualizarEscuela", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodEscuela", CodEscuela);
                if (!escuela.Equals(""))
                    comando.Parameters.AddWithValue("@Escuela", escuela);
                if (!facultad.Equals(""))
                    comando.Parameters.AddWithValue("@Facultad", facultad);

                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return new string[] { data.Tables[0].Rows[0]["CodError"].ToString(), data.Tables[0].Rows[0]["Mensaje"].ToString() };
            }
        }
        [WebMethod(Description = "Buscar una escuela :: Metodo CT.SP")]
        public DataSet BuscarEscuela(string paramsearch)
        {
            using (SqlConnection conn = new SqlConnection(cadenaconexion))
            {
                SqlCommand comando = new SqlCommand("spBuscarEscuela", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@stringfind", paramsearch);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return data;
            }
        }
        [WebMethod(Description = "Eliminar Escuela :: Metodo CT.SP")]
        public string[] EliminarEscuela(string CodEscuela)
        {
            using (SqlConnection conn = new SqlConnection(cadenaconexion))
            {
                SqlCommand comando = new SqlCommand("spEliminarEscuela", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CodEscuela", CodEscuela);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataSet data = new DataSet();
                adapter.Fill(data);
                return new string[] { data.Tables[0].Rows[0]["CodError"].ToString(), data.Tables[0].Rows[0]["Mensaje"].ToString() };
            }
        }
    }
}
