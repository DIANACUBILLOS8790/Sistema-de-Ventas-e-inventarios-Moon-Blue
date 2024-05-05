using C_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace C_Datos
{
    public class CD_Rol
    {
        public List<Rol> listar()
        {
            List<Rol> lista = new List<Rol>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdRol, Descripcion from Rol");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Rol()
                            {

                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString(),

                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Rol>();
                }
            }
            return lista;
        }
    }
}
