namespace C_Entidad
{
    public class Permiso
    {
        public int IdPermiso { get; set; }
        public Rol oRol { get; set; }
        public string Nombre_Menu { get; set; }
        public string Fecha { get; set; }
    }
}
