using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Factura
    {
        public Factura() { }

        public Factura(int idfactura, MetodoPagos idpago, DateTime fechafactura, decimal total, decimal monto, decimal vueltos) 
        {
            IDFactura = idfactura;
            IDpago = idpago;
            FechaFactura = fechafactura;
            Total = total;
            Monto = monto;
            Vueltos = vueltos;
        }

        public int IDFactura { get; set; }
        public MetodoPagos IDpago { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal Total {  get; set; }
        public decimal Monto { get; set; }
        public decimal Vueltos { get; set; }
    }
}
