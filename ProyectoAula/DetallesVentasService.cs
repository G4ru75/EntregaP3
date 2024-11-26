using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula
{
    public class DetallesVentasService
    {
        DetalleVentasRepository DetallesVRepo;

        public DetallesVentasService()
        {
            DetallesVRepo = new DetalleVentasRepository();
        }

        public List<DetallesVentas> ObtenerDetallesVentas()
        {
            return DetallesVRepo.ObtenerDetallesVentas();
        }

    }
}
