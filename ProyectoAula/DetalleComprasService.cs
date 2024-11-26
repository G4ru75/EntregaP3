using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula
{
    public class DetalleComprasService
    {
        DetalleCompraRepository DetallesRepo;
        public DetalleComprasService()
        {
            DetallesRepo = new DetalleCompraRepository();
        }

        public List<DetalleCompras> ObtenerDetalles()
        {
            return DetallesRepo.ObtenerDetalles();
        }
    }
}
