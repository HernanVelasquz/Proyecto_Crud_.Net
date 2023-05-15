using AppVenta.Application.Interfaces;
using AppVenta.Dominio.Entidades;
using AppVenta.Dominio.Repositorios;

namespace AppVenta.Application.Services
{
    public class VentaServicio : IServicioMovimiento<Venta, Guid>
    {
        IRepositorioMovimiento<Venta, Guid> repoVenta;
        IRepositorioBase<Producto, Guid> repoProducto;
        IRepositorioDetalle<VentaDetalle, Guid> repoDetalle;

        public VentaServicio(IRepositorioMovimiento<Venta, Guid> _repoVenta, IRepositorioBase<Producto, Guid> _repoProducto, IRepositorioDetalle<VentaDetalle, Guid> _repoDetalle)
        {
            repoVenta = _repoVenta;
            repoProducto = _repoProducto;
            repoDetalle = _repoDetalle;
        }

        public Venta Agregar(Venta entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La venta es requerida");

            var ventaAgregada = repoVenta.Agregar(entidad);
            entidad.VentasDetalle.ForEach(detalle =>
            {
                var productoSeleccionado = repoProducto.SelectionarPorID(detalle.productId);
                if (productoSeleccionado == null)
                    throw new ArgumentNullException("Usted Esta intendo vender un producto que no existe");

                var detalleNuevo = new VentaDetalle();
                detalleNuevo.VentaId = ventaAgregada.VentaId;
                detalleNuevo.productId = detalle.productId;
                detalleNuevo.CostoUnitario = productoSeleccionado.Costo;
                detalleNuevo.PrecioUnitario = productoSeleccionado.precio;
                detalleNuevo.CantidadVendida = detalle.CantidadVendida;
                detalle.SubTotal = detalleNuevo.PrecioUnitario * detalleNuevo.CantidadVendida;
                detalleNuevo.Impuesto = detalleNuevo.SubTotal * 15 / 100;
                detalleNuevo.Total = detalleNuevo.SubTotal + detalleNuevo.Impuesto;

                repoDetalle.Agregar(detalleNuevo);

                productoSeleccionado.cantidadEnStock -= detalleNuevo.CantidadVendida;

                repoProducto.Editar(productoSeleccionado);

                entidad.subtotal += detalleNuevo.SubTotal;
                entidad.impuesto += detalleNuevo.Impuesto;
                entidad.total += detalleNuevo.Total;
            });

            repoVenta.GuardarTodosLosCambios();
            return entidad;

        }

        public void Anular(Guid entidadId)
        {
            repoVenta.Anular(entidadId);
            repoVenta.GuardarTodosLosCambios();
        }

        public List<Venta> Listar()
        {
            return repoVenta.Listar();
        }

        public Venta SelectionarPorID(Guid entidadID)
        {
            return repoVenta.SelectionarPorID(entidadID);
        }
    }
}
