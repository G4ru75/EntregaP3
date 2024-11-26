using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Venta
    {
        public Venta() { }

        public Venta(int idventa, Productos idproductos, decimal cantidad, decimal preciolibra, string nombrecliente, string apellidocliente, Factura idfactura) 
        {
            IDVenta = idventa;
            IDProductos = idproductos;
            Cantidad = cantidad;
            PrecioLibra = preciolibra;
            NombreCliente = nombrecliente;
            ApellidoCliente = apellidocliente;
            IDFactura = idfactura;
        }

        public int IDVenta { get; set; }
        public Productos IDProductos { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioLibra { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public Factura IDFactura { get; set; }

        public int IDFacturaNumero => IDFactura?.IDFactura ?? 0;
        public string IDProducto => IDProductos?.IDProducto ?? string.Empty;

    }
}
