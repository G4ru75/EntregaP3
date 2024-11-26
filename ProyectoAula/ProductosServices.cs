using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula
{
    public class ProductosServices
    {
        private ProductosRepository ProductosRepo; 

        public ProductosServices() 
        { 
            ProductosRepo = new ProductosRepository();
        }

        public List<Productos> ObtenerProductos()
        {
            return ProductosRepo.ObtenerProductos();
        }

        public bool GuardarProducto(Productos producto)
        {
            if (ProductosRepo.ProductoExiste(producto.IDProducto))
            {
                throw new ArgumentException("El producto ya existe en la base de datos.");
            }
            return ProductosRepo.GuardarProducto(producto);
        }

        public bool ModificarProducto(Productos producto)
        {
            return ProductosRepo.ModificarProducto(producto); 
        }

        public bool EliminarProducto(string idproducto)
        {
            return ProductosRepo.EliminarProducto(idproducto);
        }
    }
}
