using AppVenta.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppVenta.Infrastructura.Datos.Config
{
    public class VentaConfig : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.ToTable("VentaDB");
            builder.HasKey(c => c.VentaId);

            builder
                .HasMany(venta => venta.VentasDetalle)
                .WithOne(detalle => detalle.Venta);
        }
    }
}
