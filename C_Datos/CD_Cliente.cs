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
    public class CD_Cliente
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdCliente,Identificacion,Nombre_Cliente,Email,Telefono,Estado from Cliente");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Cliente()
                            {

                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                Identificacion = dr["Identificacion"].ToString(),
                                Nombre_Cliente = dr["Nombre"].ToString(),
                                Email = dr["Email"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),

                            });
                        }
                    }


                }
                catch (Exception ex)
                {
                    lista = new List<Cliente>();
                }
            }

            return lista;
        }
        public int Registrar(Cliente obj, out string Mensaje)
        {
            int IdCliente_Generado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Registrar_Cliente", oConexion);
                    cmd.Parameters.AddWithValue("Identificacion", obj.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre_Cliente", obj.Nombre_Cliente);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    IdCliente_Generado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                IdCliente_Generado = 0;
                Mensaje = ex.Message;
            }

            return IdCliente_Generado;

        }


        public bool Editar(Cliente obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Editar_Cliente", oConexion);
                    cmd.Parameters.AddWithValue("IdCliente", obj.IdCliente);
                    cmd.Parameters.AddWithValue("Identificacion", obj.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre_Cliente", obj.Nombre_Cliente);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
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


        public bool Eliminar(Cliente obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("delete from cliente where IdCliente =@IdCliente", oConexion);
                    cmd.Parameters.AddWithValue("@IdCliente", obj.IdCliente);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    Respuesta = cmd.ExecuteNonQuery() > 0 ? true : false;

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
