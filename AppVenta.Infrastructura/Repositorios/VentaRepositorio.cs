using AppVenta.Dominio.Entidades;
using AppVenta.Dominio.Repositorios;
using AppVenta.Infrastructura.Datos.Contexto;

namespace AppVenta.Infrastructura.Datos.Repositorios
{
    public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid>
    {
        private VentaContexto db;

        public VentaRepositorio(VentaContexto _db)
        {
            db = _db;
        }

        public Venta Agregar(Venta entidad)
        {
            entidad.VentaId = Guid.NewGuid();
            db.Ventas.Add(entidad);
            return entidad;
        }

        public void Anular(Guid ententidadID)
        {
            var ventaSeleccionada = db.Ventas
                                      .Where(c => c.VentaId == ententidadID)
                                      .FirstOrDefault();
            if (ventaSeleccionada == null)
                throw new NullReferenceException("Esta intentando anular una venta que no existe");

            ventaSeleccionada.anulado = true;
            db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Venta> Listar()
        {
            return db.Ventas.ToList();
        }

        public Venta SelectionarPorID(Guid entidadID)
        {
            var ventaSelecionada = db.Ventas
                                     .Where(c => c.VentaId == entidadID)
                                     .FirstOrDefault();
            return ventaSelecionada;
        }
    }
}
