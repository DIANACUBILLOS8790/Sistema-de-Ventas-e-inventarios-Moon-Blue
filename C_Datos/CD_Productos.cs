using C_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

namespace C_Datos
{
    public class CD_Productos
    {
        public List<Productos> Listar()
        {
            List<Productos> lista = new List<Productos>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
            {
                try
                {
     
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdProductos, Codigo_Producto, Nombre, p.Descripcion,tp.IdTipo, tp.Descripcion" +
                        "[Descripcion_Tipo_Producto],Stock, Precio_Compra, Precio_Venta FROM Productos p");
                    query.AppendLine("inner join Tipo_productos tc on tc.IdTipo = p.IdTipo");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Productos()
                            {

                                IdProductos = Convert.ToInt32(dr["IdProductos"]),
                                Codigo_Producto= dr["Codigo_Produto"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion_Producto= dr["Descripcion_Producto"].ToString(),
                                oTipo_Producto = new Tipo_Producto() { IdTipo = Convert.ToInt32(dr["IdTpo"]), Descripcion = 
                                dr["Descripcion"].ToString() },
                                Stock = Convert.ToInt32 (dr["Stock"].ToString()),
                                Precio_Compra = Convert.ToDecimal(dr["Prcio_Compra"].ToString()),
                                Precio_Venta = Convert.ToDecimal(dr["Precio_Venta"].ToString()),
                                Estado = Convert.ToBoolean(dr["Estado"].ToString()),
                            });
                        }
                    }


                }
                catch (Exception ex)
                {
                    lista = new List<Productos>();
                }
            }

            return lista;
        }

        public int Registrar(Productos obj, out string Mensaje)
        {
            int IdProductos_Generado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Registrar_Productos", oConexion);
                    cmd.Parameters.AddWithValue("Codigo_Producto", obj.Codigo_Producto);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion_Producto", obj.Descripcion_Producto);
                    cmd.Parameters.AddWithValue("IdTipo", obj.oTipo_Producto.IdTipo);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    IdProductos_Generado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                IdProductos_Generado = 0;
                Mensaje = ex.Message;
            }

            return IdProductos_Generado;

        }


        public bool Editar(Productos obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Editar_Productos", oConexion);
                    cmd.Parameters.AddWithValue("IdProductos", obj.IdProductos);
                    cmd.Parameters.AddWithValue("Codigo_Producto", obj.Codigo_Producto);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion_Producto", obj.Descripcion_Producto);
                    cmd.Parameters.AddWithValue("IdTipo", obj.oTipo_Producto.IdTipo);
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


        public bool Eliminar(Productos obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Eliminar_Producto", oConexion);
                    cmd.Parameters.AddWithValue("IdProductos", obj.IdProductos);
                    cmd.Parameters.Add("Respuesta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["Respuesta"].Value);
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
