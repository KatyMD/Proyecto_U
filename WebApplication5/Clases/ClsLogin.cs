using System.Data;
using System.Data.SqlClient;
using APIBomberos.Clases.Conexión;
using  APIBomberos .Respuestas;

namespace APIBomberos.Clases
{
    public class ClsLogin
    {
        public string Correo { get; set; }
        public string Contraseña { get; set; }


        public ClsLogin()
        {

        }

        public ClsRespuesta iniciarsesion()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
             {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[ValidarInicioSesionContrasena]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@Correo", Correo);
                    da.SelectCommand.Parameters.AddWithValue("@Contraseñausu", Contraseña);
                    da.SelectCommand.CommandTimeout = 30;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader read = da.SelectCommand.ExecuteReader();
                    while (read.Read())
                    {
                        try
                        {
                            respuesta.Estado = read.GetBoolean(0);
                            respuesta.Mensaje = read.GetString(1);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    conn.Dispose();
                    conn.Close();
                }
                return respuesta;
            }
            catch (Exception e)
            {
                respuesta.Estado = false;
                respuesta.Mensaje = e.Message;
                return respuesta;
            }

        }
    }
}
