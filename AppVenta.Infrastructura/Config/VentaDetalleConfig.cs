using AppVenta.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppVenta.Infrastructura.Datos.Config
{
    public class VentaDetalleConfig : IEntityTypeConfiguration<VentaDetalle>
    {
        public void Configure(EntityTypeBuilder<VentaDetalle> builder)
        {
            builder.ToTable("VentaDetalleDB");
            builder.HasKey(c => new { c.productId, c.VentaId });
            builder
                .HasOne(detalle => detalle.Producto)
                .WithMany(producto => producto.VentasDetalle);

            builder
                .HasOne(detalle => detalle.Venta)
                .WithMany(venta => venta.VentasDetalle);
        }
    }
}
