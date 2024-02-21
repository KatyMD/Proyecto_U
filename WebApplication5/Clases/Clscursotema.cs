using APIBomberos.Clases.Conexión;
using APIBomberos.Respuestas;
using System.Data.SqlClient;
using System.Data;

namespace APIBomberos.Clases
{
    public class Clscursotema
    {


        public string tipoperacion { get; set; }
        public int idcursotema { get; set; }
        public int idtemaunidad { get; set; }
        public string  fechaini { get; set; }
        public string fechafin { get; set; }
        public int idcurso { get; set; }


        public Clscursotema() { }




        public ClsRespuesta AgregarCursotema()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[USP_SET_CURSO_TEMA]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "C");
                    da.SelectCommand.Parameters.AddWithValue("@IdCursotema", null);
                    da.SelectCommand.Parameters.AddWithValue("@Idtemaunid", idtemaunidad);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_inicio", fechaini);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_fin", fechafin);
                    da.SelectCommand.Parameters.AddWithValue("@Id_curso", idcurso);
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


        public ClsRespuesta ActualizarCursotema()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[USP_SET_CURSO_TEMA]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "U");
                    da.SelectCommand.Parameters.AddWithValue("@IdCursotema", idcursotema);
                    da.SelectCommand.Parameters.AddWithValue("@Idtemaunid", null);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_inicio", fechaini);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_fin", fechafin);
                    da.SelectCommand.Parameters.AddWithValue("@Id_curso", null);
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



        public ClsRespuesta EstadoCursotema()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[USP_SET_CURSO_TEMA]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "D");
                    da.SelectCommand.Parameters.AddWithValue("@IdCursotema", idcursotema);
                    da.SelectCommand.Parameters.AddWithValue("@Idtemaunid", null);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_inicio", null);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_fin", null);
                    da.SelectCommand.Parameters.AddWithValue("@Id_curso", null);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.CommandTimeout = 30;
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