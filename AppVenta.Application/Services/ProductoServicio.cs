using AppVenta.Application.Interfaces;
using AppVenta.Dominio.Entidades;
using AppVenta.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Application.Services
{
    public class ProductoServicio : IServicioBase<Producto, Guid>
    {
        private readonly IRepositorioBase<Producto, Guid> repoProduto;

        public ProductoServicio(IRepositorioBase<Producto, Guid> _repoProducto)
        {
            repoProduto = _repoProducto;
        }
        public Producto Agregar(Producto entidad)
        {
            if (entidad == null)
            {
                throw new ArgumentException("El producto es requerido");
            }
            var resultProducto = repoProduto.Agregar(entidad);
            repoProduto.GuardarTodosLosCambios();
            return resultProducto;
        }

        public void Editar(Producto entidad)
        {
            if (entidad == null)
                throw new ArgumentException("El producto es requerido");

            repoProduto.Editar(entidad);
            repoProduto.GuardarTodosLosCambios();

        }

        public void Eliminar(Guid entidadID)
        {
            repoProduto.Eliminar(entidadID);
            repoProduto.GuardarTodosLosCambios();
        }

        public List<Producto> Listar()
        {
            return repoProduto.Listar();
        }

        public Producto SelectionarPorID(Guid entidadID)
        {
            return repoProduto.SelectionarPorID(entidadID);
        }
    }
}
