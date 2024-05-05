using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidad
{
    public class Resumen_Ventas
    {
        public int IdRV {  get; set; }
        public Productos oProductos { get; set; }
        public decimal Precio_venta {  get; set; }
        public int Cantidad {  get; set; }
        public decimal Subtotal { get; set; }
        public string Fecha { get; set; }
    }
}
