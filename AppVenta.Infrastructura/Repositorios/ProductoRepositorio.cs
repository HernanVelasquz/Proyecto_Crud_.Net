using AppVenta.Dominio.Entidades;
using AppVenta.Dominio.Repositorios;
using AppVenta.Infrastructura.Datos.Contexto;

namespace AppVenta.Infrastructura.Datos.Repositorios
{
    public class ProductoRepositorio : IRepositorioBase<Producto, Guid>
    {
        private VentaContexto db;

        public ProductoRepositorio(VentaContexto _db)
        {
            db = _db;
        }

        public Producto Agregar(Producto entidad)
        {
            entidad.ProductoId = Guid.NewGuid();
            db.Productos.Add(entidad);
            return entidad;
        }

        public void Editar(Producto entidad)
        {
            var productSeleccionado = db.Productos
                .Where(c => c.ProductoId == entidad.ProductoId)
                .FirstOrDefault();
            if (productSeleccionado != null)
            {
                productSeleccionado.Nombre = entidad.Nombre;
                productSeleccionado.Descripcion = entidad.Descripcion;
                productSeleccionado.Costo = entidad.Costo;
                productSeleccionado.precio = entidad.precio;
                productSeleccionado.cantidadEnStock = entidad.cantidadEnStock;

                db.Entry(productSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadID)
        {
            var productSeleccionado = db.Productos
                 .Where(c => c.ProductoId == entidadID)
                 .FirstOrDefault();
            if (productSeleccionado != null)
            {
                db.Productos.Remove(productSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Producto> Listar()
        {
            return db.Productos.ToList();
        }

        public Producto SelectionarPorID(Guid entidadID)
        {
            var productSeleccionado = db.Productos
                     .Where(c => c.ProductoId == entidadID)
                     .FirstOrDefault();
            return productSeleccionado;
        }
    }
}
