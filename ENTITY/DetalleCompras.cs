using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class DetalleCompras
    {
        public DetalleCompras() { }

        public DetalleCompras(int numerocompra, int idproveedor, string nombreproveedor, string apellidoproveedor, string nombreproducto,int cantidad, decimal precio, decimal total, string metodopago)
        {
            NumeroCompra = numerocompra;
            IDProveedor = idproveedor;
            NombreProveedor = nombreproveedor;
            ApellidoProveedor = apellidoproveedor;
            NombreProducto = nombreproducto;
            Cantidad = cantidad; 
            Precio = precio;
            Total = total;
            MetodoPago = metodopago;
        }

        public int NumeroCompra { get; set; }
        public int IDProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string ApellidoProveedor { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }
    }
}
