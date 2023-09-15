using System.Data.SqlClient;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using  APIBomberos.Clases.Conexión;
using APIBomberos.Respuestas;

namespace APIBomberos.Clases
{
    public class ClsUsuarioCurso
    {

        public string tipoperacion { get; set; }
        public int idusucurso { get; set; }
        public int idusu { get; set; }
        public int idcursotem { get; set; }

        public ClsUsuarioCurso() { }



        public ClsRespuesta AgregarUsuarioCurso()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[USP_SET_CURSO_USUARIO]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "C");
                    da.SelectCommand.Parameters.AddWithValue("@IdCurso_usuario", null);
                    da.SelectCommand.Parameters.AddWithValue("@Idusuario ", idusu);
                    da.SelectCommand.Parameters.AddWithValue("@Idcurso_tema", idcursotem);
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

    

    public ClsRespuesta EstadoUsuarioCurso()
    {
        ClsRespuesta respuesta = new ClsRespuesta();
        try
        {
            using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                conn.Open();
                da.SelectCommand = new SqlCommand("[USP_SET_CURSO_USUARIO]", conn);
                da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "D");
                da.SelectCommand.Parameters.AddWithValue("@IdCurso_usuario", idusucurso);
                da.SelectCommand.Parameters.AddWithValue("@Idusuario ", null);
                da.SelectCommand.Parameters.AddWithValue("@Idcurso_tema", null);
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
