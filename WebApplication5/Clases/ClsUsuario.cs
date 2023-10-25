using System.Data.SqlClient;
using System.Data;
using APIBomberos.Clases.Conexión;
using System.Collections.Generic;
using APIBomberos.Respuestas;
using static APIBomberos.Respuestas.ClsRespuesta;
using System;

namespace APIBomberos.Clases
{
    public class ClsUsuario
    {

        public string tipoperacion { get; set; }
        public int idusu { get; set; }
        public int tipousu { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string dpi { get; set; }



        public ClsUsuario() { }

        public ClsRespuesta AgregarUsuario()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[USP_SET_USUARIO]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "C");
                    da.SelectCommand.Parameters.AddWithValue("@Idusuario", null);
                    da.SelectCommand.Parameters.AddWithValue("@IdTipoUsuario ", tipousu);
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
                    da.SelectCommand.Parameters.AddWithValue("@Apellido", apellido);
                    da.SelectCommand.Parameters.AddWithValue("@Correo ", correo);
                    da.SelectCommand.Parameters.AddWithValue("@DPI", dpi);
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

        public ClsRespuesta ActualizarUsuario()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[USP_SET_USUARIO]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "U");
                    da.SelectCommand.Parameters.AddWithValue("@Idusuario", idusu);
                    da.SelectCommand.Parameters.AddWithValue("@IdTipoUsuario ", null);
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", nombre);
                    da.SelectCommand.Parameters.AddWithValue("@Apellido", apellido);
                    da.SelectCommand.Parameters.AddWithValue("@Correo ", correo);
                    da.SelectCommand.Parameters.AddWithValue("@DPI", dpi);
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


        public ClsRespuesta EstadoUsuario()
        {
            ClsRespuesta respuesta = new ClsRespuesta();
            try
            {
                using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    conn.Open();
                    da.SelectCommand = new SqlCommand("[USP_SET_USUARIO]", conn);
                    da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "D");
                    da.SelectCommand.Parameters.AddWithValue("@Idusuario", idusu);
                    da.SelectCommand.Parameters.AddWithValue("@IdTipoUsuario ", null);
                    da.SelectCommand.Parameters.AddWithValue("@Nombre", null);
                    da.SelectCommand.Parameters.AddWithValue("@Apellido", null);
                    da.SelectCommand.Parameters.AddWithValue("@Correo ", null);
                    da.SelectCommand.Parameters.AddWithValue("@DPI", null);
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


        public string listaUsuariocurso()
        {
            string Result = "";
            using (SqlConnection conn = new SqlConnection(ClsConexion.Conexion))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = new SqlCommand("[USP_GET_CURSO]", conn);
                da.SelectCommand.CommandTimeout = 0;
                da.SelectCommand.Parameters.AddWithValue("@TipoOperacion", "U");

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
























