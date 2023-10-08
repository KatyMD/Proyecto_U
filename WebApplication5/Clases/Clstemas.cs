using APIBomberos.Clases.Conexión;
using APIBomberos.Respuestas;
using System.Data.SqlClient;
using System.Data;

namespace APIBomberos.Clases
{
    public class Clstemas
    {

        public Clstemas() { }

        public string listatemas(string tema)
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
                da.SelectCommand.Parameters.AddWithValue("@temauni", tema);

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
