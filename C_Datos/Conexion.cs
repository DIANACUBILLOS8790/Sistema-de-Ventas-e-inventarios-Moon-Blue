using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace C_Datos
{
    public class Conexion
    {
        public static string Cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();              
    }
}
