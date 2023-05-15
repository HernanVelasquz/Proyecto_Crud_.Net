using AppVenta.Dominio.Entidades;
using AppVenta.Dominio.Repositorios;
using AppVenta.Infrastructura.Datos.Contexto;

namespace AppVenta.Infrastructura.Datos.Repositorios
{
    public class VentaDetalleReposiotrio : IRepositorioDetalle<VentaDetalle, Guid>
    {
        private VentaContexto db;

        public VentaDetalleReposiotrio(VentaContexto _db)
        {
            db = _db;
        }

        public VentaDetalle Agregar(VentaDetalle entidad)
        {
            db.ventaDetalles.Add(entidad);
            return entidad;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }
    }
}
