using AppVenta.Dominio.Repositorios.Interfaces;

namespace AppVenta.Dominio.Repositorios
{
    public interface IRepositorioDetalle<TEntidad, TMovimientoID>
         : IAgregar<TEntidad>, ITransaccion
    {
    }
}
