using AppVenta.Dominio.Repositorios.Interfaces;

namespace AppVenta.Application.Interfaces
{
    public interface IServicioMovimiento<TEntidad, TEntidadID>
          : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>
    {
        void Anular(TEntidadID entidadId);
    }
}
