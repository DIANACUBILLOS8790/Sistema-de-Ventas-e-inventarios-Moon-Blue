using C_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace C_Datos
{
    public class CD_Tipo_Producto
    {
        public List<Tipo_Producto> Listar()
        {
            List<Tipo_Producto> lista = new List<Tipo_Producto>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("Select IdTipo, Descripcion, Estado from Tipo_Producto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Tipo_Producto()
                            {

                                IdTipo = Convert.ToInt32(dr["IdTipo"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Tipo_Producto>();
                }
            }
            return lista;
        }



        //Registrar tipo de producto


        public int Registrar(Tipo_Producto obj, out string Mensaje)
        {
            int IdTipo_Generado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Registrar_Producto", oConexion);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    IdTipo_Generado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                IdTipo_Generado = 0;
                Mensaje = ex.Message;
            }

            return IdTipo_Generado;

        }



        //Editar tipo de producto


        public bool Editar(Tipo_Producto obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_editar_Producto", oConexion);
                    cmd.Parameters.AddWithValue("IdTipo", obj.IdTipo);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }
            return Respuesta;
        }



        //Eliminar tipo de producto


        public bool Eliminar(Tipo_Producto obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Eliminar_Producto", oConexion);
                    cmd.Parameters.AddWithValue("IdTipo", obj.IdTipo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }

            return Respuesta;

        }
    }
}
