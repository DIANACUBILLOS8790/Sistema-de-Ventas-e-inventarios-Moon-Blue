using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidad
{
    public class Compras
    {
        public int IdCompras {  get; set; }
        public Usuario oUsuario { get; set; }
        public Proveedores oProveedores { get; set; }
        public string soporte {  get; set; }
        public string Numero_soporte { get; set; }
        public decimal Precio_TotalC {  get; set; }
        public List<Resumen_Compras> oResumen_Compras { get; set; } 
        public string Fecha { get; set; }
    }
}
