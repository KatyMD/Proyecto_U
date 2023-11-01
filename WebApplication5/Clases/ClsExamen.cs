using APIBomberos.Clases.Conexión;
using APIBomberos.Respuestas;
using System.Data.SqlClient;
using System.Data;

namespace APIBomberos.Clases
{
    public class ClsExamen
    {

        public int Id_usuario { get; set; }
        public int Id_examen { get; set; }
        public int Id_pregunta { get; set; }
        public decimal Punteo_pregunta { get; set; }
        public int Id_respuesta { get; set; }
        public bool Resultado_res { get; set; }
        public ClsExamen() { }

        public string MostrarExamen(string usuario, string idtema)
        {
            string Result = "";
            using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = new SqlCommand("[USP_GET_Examen]", conn);
                da.SelectCommand.CommandTimeout = 0;
                da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "S");
                da.SelectCommand.Parameters.AddWithValue("@idusario", usuario);
                da.SelectCommand.Parameters.AddWithValue("@idtema ", idtema);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                Result = Clsjsontablcs.toJson(dt);
                conn.Dispose();
                conn.Close();
            }
            return Result;
        }


        public ClsRespuesta ingresarexamen()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[USP_SET_InsertarExamenYRespuestas]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@Id_usuario", Id_usuario);
                    da.SelectCommand.Parameters.AddWithValue("@Id_examen", Id_examen);
                    da.SelectCommand.Parameters.AddWithValue("@Id_pregunta", Id_pregunta);
                    da.SelectCommand.Parameters.AddWithValue("@Punteo_pregunta", Punteo_pregunta);
                    da.SelectCommand.Parameters.AddWithValue("@Id_respuesta", Id_respuesta);
                    da.SelectCommand.Parameters.AddWithValue("@Resultado_res", Resultado_res);
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
