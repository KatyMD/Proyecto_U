using APIBomberos.Clases.Conexión;
using APIBomberos.Respuestas;
using System.Data.SqlClient;
using System.Data;

namespace APIBomberos.Clases
{
    public class Clstemas
    {

        public Clstemas() { }


        public string listatemas()
        {
            string Result = "";
            using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = new SqlCommand("[USP_GET_TEMA_UNIDAD]", conn);
                da.SelectCommand.CommandTimeout = 0;
                da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "T");
                da.SelectCommand.Parameters.AddWithValue("@idusario", null);
                da.SelectCommand.Parameters.AddWithValue("@idtema", null);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                Result = Clsjsontablcs.toJson(dt);
                conn.Dispose();
                conn.Close();
            }
            return Result;
        }

        public string listaCursotemas(string idusuario)
        {
            string Result = "";
            using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = new SqlCommand("[USP_GET_TEMA_UNIDAD]", conn);
                da.SelectCommand.CommandTimeout = 0;
                da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "U");
                da.SelectCommand.Parameters.AddWithValue("@idusario", idusuario);
                da.SelectCommand.Parameters.AddWithValue("@idtema", null);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                Result = Clsjsontablcs.toJson(dt);
                conn.Dispose();
                conn.Close();
            }
            return Result;
        }

        public string listatems(string idusuario, string idtema)
        {
            string Result = "";
            using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = new SqlCommand("[USP_GET_TEMA_UNIDAD]", conn);
                da.SelectCommand.CommandTimeout = 0;
                da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "S");
                da.SelectCommand.Parameters.AddWithValue("@idusario", idusuario);
                da.SelectCommand.Parameters.AddWithValue("@idtema", idtema);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
                Result = Clsjsontablcs.toJson(dt);
                conn.Dispose();
                conn.Close();
            }
            return Result;
        }



        public string listausuariotemas(string idusuario)
        {
            string Result = "";
            using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = new SqlCommand("[USP_GET_TEMA_UNIDAD]", conn);
                da.SelectCommand.CommandTimeout = 0;
                da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "C");
                da.SelectCommand.Parameters.AddWithValue("@idusario", idusuario);
                da.SelectCommand.Parameters.AddWithValue("@idtema", null);
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
