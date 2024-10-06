﻿using C_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;



namespace C_Datos
{
    public class CD_Permiso
    {
        public List<Permiso> Listar(int IdUsuario)
        {
            List<Permiso> lista = new List<Permiso>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.Cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.IdRol, p.Nombre_Menu from Permiso p");
                    query.AppendLine("inner join Rol r on r.IdRol = p.IdRol");
                    query.AppendLine("inner join Usuario u on u.IdRol = r.IdRol");
                    query.AppendLine("where u.IdUsuario = @IdUsuario");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Permiso()
                            {

                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },
                                Nombre_Menu = dr["Nombre_Menu"].ToString(),


                            });
                        }
                    }


                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }
            }

            return lista;
        }
    }
}
