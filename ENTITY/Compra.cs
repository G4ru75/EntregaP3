using System;

namespace ENTITY
{
    public class Compra
    {

        public Compra() { }

        public Compra(int idcompra, Proveedor proveedor, Productos productos, int cantidadcajas, decimal preciocaja, decimal totalcompra, DateTime fechacompra, MetodoPagos pagoid)
        {
            IDCompra = idcompra;
            Proveedor = proveedor;
            Productos = productos;
            CantidadCajas = cantidadcajas;
            PrecioCaja = preciocaja;
            TotalCompra = totalcompra;
            FechaCompra = fechacompra;
            PagoID = pagoid; 
        }

        public int IDCompra { get; set; }
        public Proveedor Proveedor { get; set; }
        public Productos Productos { get; set; }
        public int CantidadCajas{ get; set; }
        public decimal PrecioCaja { get; set; }
        public decimal TotalCompra { get; set; }
        public DateTime FechaCompra { get; set; }
        public MetodoPagos PagoID {  get; set; }

        public int IDProveedor => Proveedor?.IDProveedor ?? 0;  // Devuelve 0 si Proveedor es null
        public string IDProducto => Productos?.IDProducto ?? string.Empty;  // Devuelve string vacío si Productos es null
        public string Pagoid => PagoID?.IDPago ?? string.Empty;

    }
}
