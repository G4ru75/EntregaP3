using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Productos
    {

        public Productos() { }

        public Productos(string idproducto, Categoria idcategoria, string nombreproducto, decimal precioventa, int cantidad)
        {
            IDProducto = idproducto;
            IDCategoria = idcategoria;
            NombreProducto = nombreproducto;
            PrecioVenta = precioventa;
            Cantidad = cantidad;
        }

        public string IDProducto { get; set; }
        public Categoria IDCategoria { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Cantidad { get; set; }

        public string CategoriaID => IDCategoria?.IDCategoria ?? string.Empty;
    }
}
