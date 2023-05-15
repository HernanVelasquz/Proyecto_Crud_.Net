using AppVenta.Dominio.Repositorios.Interfaces;

namespace AppVenta.Dominio.Repositorios
{
    public interface IRepositorioBase<TEntidad, TEntidadID>
        : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad,
            TEntidadID>, ITransaccion
    { }
}
