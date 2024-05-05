using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidad
{
    public  class Productos
    {
        public int IdProductos { get; set; }
        public string Codigo_Producto { get; set; } 
        public string Nombre {  get; set; }
        public string Descripcion_Producto { get; set; }
        public Tipo_Producto oTipo_Producto { get; set; }
        public int Stock {  get; set; }
        public decimal Precio_Compra { get; set;}
        public decimal Precio_Venta { get; set; }
        public bool Estado { get; set; }
        public string Fecha { get; set; }
    }
}
