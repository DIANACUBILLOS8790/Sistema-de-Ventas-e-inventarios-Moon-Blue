namespace C_Entidad
{
    public class Detalle_Compras
    {
        public int IdRC { get; set; }
        public Productos oProductos { get; set; }
        public decimal Precio_Compra { get; set; }
        public decimal Precio_Venta { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Total { get; set; }
        public string Fecha { get; set; }
    }
}
