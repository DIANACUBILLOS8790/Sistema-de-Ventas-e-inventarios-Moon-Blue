using C_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;




namespace C_Datos
{
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.IdUsuario, u.Identificacion, u.Nombre, u.Email, u.Contraseña, u.Estado, r.IdRol, r.Descripcion from Usuario u");
                    query.AppendLine("inner join Rol r on r.IdRol = u.IdRol");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Usuario()
                            {

                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Identificacion = dr["Identificacion"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Email = dr["Email"].ToString(),
                                Contraseña = dr["Contraseña"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() }
                            });
                        }
                    }


                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>();
                }
            }

            return lista;
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            int IdUsuario_Generado = 0;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Registrar_Usuario", oConexion);
                    cmd.Parameters.AddWithValue("Identificacion", obj.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Contraseña", obj.Contraseña);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
                    cmd.Parameters.AddWithValue("Estado", obj.Estado);

                    cmd.Parameters.Add("IdUsuario_Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    IdUsuario_Generado = Convert.ToInt32(cmd.Parameters["IdUsuario_Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                IdUsuario_Generado = 0;
                Mensaje = ex.Message;
            }

            return IdUsuario_Generado;

        }


        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_editar_Usuario", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("Identificacion", obj.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Contraseña", obj.Contraseña);
                    cmd.Parameters.AddWithValue("IdRol", obj.oRol.IdRol);
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


        public bool Eliminar(Usuario obj, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
                {
                    SqlCommand cmd = new SqlCommand("SP_Eliminar_Usuario", oConexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);

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
