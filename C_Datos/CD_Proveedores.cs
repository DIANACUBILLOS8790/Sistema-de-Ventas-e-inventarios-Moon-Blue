using C_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Datos
{
    public class CD_Proveedores
    {
        public List<Proveedores> Listar()
        {
            List<Proveedores> lista = new List<Proveedores>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdProveedores, Identificacion, Nombre_Empresa, Email, Telefono, Estado from Proveedores ");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedores()
                            {

                                IdProveedores = Convert.ToInt32(dr["IdProveedores"]),
                                Identificacion = dr["Identificacion"].ToString(),
                                Nombre_Empresa = dr["Nombre_Empresa"].ToString(),
                                Email = dr["Email"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),

                            });
                        }
                    }


                }
                catch (Exception ex)
                {
                    lista = new List<Proveedores>();
                }
            }

            return lista;
        }

        public int Registrar(Proveedores obj, out string Mensaje)
        {
            int IdProveedores_Generado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Registrar_Proveedores", oConexion);
                    cmd.Parameters.AddWithValue("Identificacion", obj.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre_Empresa", obj.Nombre_Empresa);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    IdProveedores_Generado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                IdProveedores_Generado = 0;
                Mensaje = ex.Message;
            }

            return IdProveedores_Generado;

        }


        public bool Editar(Proveedores obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Editar_Proveedores", oConexion);
                    cmd.Parameters.AddWithValue("IdProveedores", obj.IdProveedores);
                    cmd.Parameters.AddWithValue("Identificacion", obj.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre_Empresa", obj.Nombre_Empresa);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

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


        public bool Eliminar(Proveedores obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Eliminar_Proveedores", oConexion);
                    cmd.Parameters.AddWithValue("IdProveedores", obj.IdProveedores);

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
