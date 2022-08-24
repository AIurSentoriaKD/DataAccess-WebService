using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
// namespace acceso sql server
using System.Data.SqlClient;    //  sql server
using System.Data;              // datos generales
using System.Configuration;     // archivos de conf
namespace DataAccess
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        // Entorno no conectado para acceder a la tabla escuela
        // Acceder a la cadena de conexión
        private static string cadenaconexion = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static SqlConnection conexion = new SqlConnection(cadenaconexion);
        [WebMethod(Description ="Listar la tabla Alumnos")]
        public DataSet ListarAlumnos()
        {
            string consulta = "exec spListarAlumno";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }
        [WebMethod(Description = "Listar la tabla Escuela")]
        public DataSet ListarEscuela()
        {
            // lectura de datos
            string consulta = "exec spListarEscuela";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }
        [WebMethod(Description = "Agregar un alumno")]
        public bool AgregarAlumno(string CodAlumno, string Apellidos, string Nombres, string LugarNac, string FechaNac, string CodEscuela)
        {
            try
            {
                string consulta = "exec spAgregarAlumno @CodAlumno='" + CodAlumno + "', @Apellidos='" + Apellidos + "', @Nombres='" + Nombres + "', @LugarNac='" + LugarNac + "', @FechaNac='" + FechaNac + "', @CodEscuela='" + CodEscuela + "'";
                SqlCommand command = new SqlCommand(consulta, conexion);

                conexion.Open();
                byte i = Convert.ToByte(command.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }
        [WebMethod(Description = "Agregar una Escuela")]
        public bool AgregarEscuela(string CodEscuela, string Escuela, string Facultad)
        {
            // Entorno conectado para insertar a la tabla escuela
            // procesos criticos, modificacion de datos
            try
            {
                string consulta = "exec spAgregarEscuela @CodEscuela = '" + CodEscuela + "', @Escuela = '" + Escuela + "', @Facultad = '" + Facultad + "'";

                SqlCommand command = new SqlCommand(consulta, conexion);
                conexion.Open();
                // ejecutar consulta
                byte i = Convert.ToByte(command.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;

            }
            catch (Exception)
            {
                conexion.Close();
                return false;
            }
        }
        [WebMethod(Description = "Eliminar un alumno")]
        public DataSet EliminarAlumno(string CodAlumno)
        {
            try
            {
                string consulta = "exec spEliminarAlumno @CodAlumno='"+CodAlumno+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }
        [WebMethod(Description = "Eliminar una escuela")]
        public bool EliminarEscuela(string codEscuela)
        {

            try
            {
                string consulta = "exec spEliminarEscuela @CodEscuela";
                SqlCommand command = new SqlCommand(consulta, conexion);
                command.Parameters.AddWithValue("@CodEscuela", codEscuela);
                conexion.Open();
                byte i = Convert.ToByte(command.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        [WebMethod(Description ="Actualizar alumno")]
        public DataSet ActualizarAlumno(string codAlumno, string Apellidos = "", string Nombres = "", string LugarNac = "", string FechaNac = "", string CodEscuela = "")
        {
            try
            {
                string[] atribnames = { "Apellidos", "Nombres", "LugarNac", "FechaNac", "CodEscuela" };
                string[] atributos = { Apellidos, Nombres, LugarNac, FechaNac, CodEscuela };
                string cadena = "exec spActualizarAlumno @CodAlumno ='" + codAlumno + "'";
                for (int i = 0; i < atributos.Length; i++)
                {
                    if (!atributos[i].Equals(""))
                    {
                        cadena += ", @" + atribnames[i] + "='" + atributos[i] + "'";
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cadena, conexion);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }
        [WebMethod(Description = "Actualizar Escuela")]
        public bool ActualizarEscuela(string codEscuela, string escuela = "", string facultad = "")
        {
            try
            {
                
                string consulta = "exec spActualizarEscuela @CodEscuela, @Escuela, @Facultad";
                SqlCommand command = new SqlCommand(consulta, conexion);
                command.Parameters.AddWithValue("@CodEscuela", codEscuela);
                command.Parameters.AddWithValue("@Escuela", escuela);
                command.Parameters.AddWithValue("@Facultad", facultad);
                conexion.Open();
                byte i = Convert.ToByte(command.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
        [WebMethod(Description ="Busqueda de alumno")]
        public DataSet BuscarAlumno(string stringtofind)
        {
            string consulta = "exec spBuscarAlumno @stringfind ='" + stringtofind + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
            
        }
        [WebMethod(Description ="Busqueda Escuela")]
        public DataSet BuscarEscuela(string stringtofind)
        {
            string consulta = "exec spBuscarEscuela @stringfind = '"+stringtofind+"'";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }
    }
}
