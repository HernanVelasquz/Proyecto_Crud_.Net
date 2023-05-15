using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AppVenta.Dominio.Entidades;

namespace AppVenta.Infrastructura.Datos.Config
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("ProductoDB");
            builder.HasKey(c => c.ProductoId);

            builder.
                HasMany(producto => producto.VentasDetalle)
                .WithOne(detalle => detalle.Producto);
        }
    }
}
