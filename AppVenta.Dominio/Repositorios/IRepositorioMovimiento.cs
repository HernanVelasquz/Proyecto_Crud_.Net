using AppVenta.Dominio.Repositorios.Interfaces;

namespace AppVenta.Dominio.Repositorios
{
    public interface IRepositorioMovimiento<TEntidad, TEntidadID>
         : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID>, ITransaccion
    {
        void Anular(TEntidadID ententidadID);
    }
}
