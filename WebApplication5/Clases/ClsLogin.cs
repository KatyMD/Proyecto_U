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
        public string tipoper { get; set; }



        public ClsLogin()
        {

        }

        public ClsRespuestalog iniciarsesionadmin()
        {
            ClsRespuestalog respuesta = new ClsRespuestalog();
            try
             {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[ValidarInicioSesionContrasena]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "A");
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

                            if (read.FieldCount > 2)
                            {
                                respuesta.IDUsuario = read.GetInt32(2);
                            }


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




        public ClsRespuestalog iniciarsesionins()
        {
            ClsRespuestalog respuesta = new ClsRespuestalog();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[ValidarInicioSesionContrasena]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "I");
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
                            if (read.FieldCount > 2)
                            {
                                respuesta.IDUsuario = read.GetInt32(2);
                            }
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

        public ClsRespuestalog iniciarsesionalum()
        {
            ClsRespuestalog respuesta = new ClsRespuestalog();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[ValidarInicioSesionContrasena]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "E");
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

                            if (read.FieldCount > 2)
                            {
                                respuesta.IDUsuario = read.GetInt32(2);
                            }
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
