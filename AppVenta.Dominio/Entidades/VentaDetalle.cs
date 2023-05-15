using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Dominio.Entidades
{
    public class VentaDetalle
    {
        public Guid productId { get; set; }
        public Guid VentaId { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal CantidadVendida { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public Producto Producto { get; set; }
        public Venta Venta { get; set; }
    }
}
