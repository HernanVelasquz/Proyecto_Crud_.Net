namespace AppVenta.Dominio.Entidades
{
    public class Producto
    {
        public Guid ProductoId { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Costo { get; set; }

        public decimal precio { get; set; }

        public decimal cantidadEnStock { get; set; }

        public List<VentaDetalle>? VentasDetalle { get; set; }
    }
}
