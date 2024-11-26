using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula
{
    public class VentasService
    {
        VentasRepository ventasRepo; 

        public VentasService()
        {
            ventasRepo = new VentasRepository();
        }

        public List<Venta> ObtenerVentas()
        {
            return ventasRepo.ObtenerVentas();
        }

        public bool Vender(Venta venta, decimal monto, string metodo)
        {
            return ventasRepo.Vender(venta, monto, metodo);
        }
    }
}
