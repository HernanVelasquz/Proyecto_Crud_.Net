using AppVenta.Dominio.Repositorios.Interfaces;

namespace AppVenta.Application.Interfaces
{
    public interface IServicioBase<TEntidad, TEntidadID>
         : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
    {
    }
}
