namespace C_Entidad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public Rol oRol { get; set; }
        public bool Estado { get; set; }
        public string Fecha { get; set; }
    }
}
