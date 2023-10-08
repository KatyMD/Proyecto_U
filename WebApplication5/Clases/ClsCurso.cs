using APIBomberos.Clases.Conexión;
using APIBomberos.Respuestas;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Intrinsics.Arm;

namespace APIBomberos.Clases
{
    public class ClsCurso
    {
        public string tipoperacion { get; set; }
        public int idcurso { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string fechaini { get; set; }
        public string fechafin { get; set; }

        public ClsCurso() { }




        public ClsRespuesta AgregarCurso()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[USP_SET_CURSO]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "C");
                    da.SelectCommand.Parameters.AddWithValue("@IdCurso", null);
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
                    da.SelectCommand.Parameters.AddWithValue("@Descripcion", descripcion);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_inicio", fechaini);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_fin", fechafin);
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


        public ClsRespuesta ActualizarCurso()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[USP_SET_CURSO]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "U");
                    da.SelectCommand.Parameters.AddWithValue("@IdCurso", idcurso);
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
                    da.SelectCommand.Parameters.AddWithValue("@Descripcion", descripcion);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_inicio", fechaini);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_fin", fechafin);
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


        public ClsRespuesta EstadoCurso()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[USP_SET_CURSO]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "D");
                    da.SelectCommand.Parameters.AddWithValue("@IdCurso", idcurso);
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", null);
                    da.SelectCommand.Parameters.AddWithValue("@Descripcion", null);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_inicio", null);
                    da.SelectCommand.Parameters.AddWithValue("@Fecha_fin", null);
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



        public string listaCurso()
        {
            string Result = "";
            using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = new SqlCommand("[USP_GET_CURSO]", conn);
                da.SelectCommand.CommandTimeout = 0;
                da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "C");

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                Result = Clsjsontablcs.toJson(dt);
                conn.Dispose();
                conn.Close();
            }
            return Result;
        }




    }






}
