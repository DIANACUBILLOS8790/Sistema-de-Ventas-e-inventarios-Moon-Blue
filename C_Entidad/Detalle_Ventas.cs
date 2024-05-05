namespace C_Entidad
{
    public class Detalle_Ventas
    {
        public int IdRV { get; set; }
        public Productos oProductos { get; set; }
        public decimal Precio_venta { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public string Fecha { get; set; }
    }
}
