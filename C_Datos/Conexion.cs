using System.Configuration;


namespace C_Datos
{
    public class Conexion
    {
        public static string Cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();
    }
}
