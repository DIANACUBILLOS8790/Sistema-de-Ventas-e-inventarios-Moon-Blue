using System.Collections.Generic;

namespace C_Entidad
{
    public class Ventas
    {

        public int IdVentas { get; set; }
        public Usuario oUsuario { get; set; }
        public string Soporte { get; set; }
        public string Numero_Soporte { get; set; }
        public string Identificacion_Cliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public decimal Efectivo { get; set; }
        public decimal Cambio { get; set; }
        public decimal Precio_TotalV { get; set; }
        public List<Detalle_Ventas> oResumen_Ventas { get; set; }
        public string Fecha { get; set; }
    }
}
