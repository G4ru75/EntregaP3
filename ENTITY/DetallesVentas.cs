using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class DetallesVentas
    {
        public DetallesVentas() { }

        public DetallesVentas(int iDVenta, string nombreProducto, int cantidadLibras, decimal precioLibra, decimal totalVenta, decimal monto, decimal vueltos, string nombreCliente, string apellidoCliente, DateTime fechaFactura, string metodoDePago, int iDFactura)
        {
            IDVenta = iDVenta;
            NombreProducto = nombreProducto;
            CantidadLibras = cantidadLibras;
            PrecioLibra = precioLibra;
            TotalVenta = totalVenta;
            Monto = monto;
            Vueltos = vueltos;
            NombreCliente = nombreCliente;
            ApellidoCliente = apellidoCliente;
            FechaFactura = fechaFactura;
            MetodoDePago = metodoDePago;
            IDFactura = iDFactura;
        }

        public int IDVenta { get; set; }
        public string NombreProducto { get; set; }
        public int CantidadLibras { get; set; }
        public decimal PrecioLibra { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal Monto { get; set; }
        public decimal Vueltos { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public DateTime FechaFactura { get; set; }
        public string MetodoDePago { get; set; }
        public int IDFactura { get; set; }

    }
}
