using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula
{
    public class CompraService
    {
        CompraRepository compraRepo;
        public CompraService()
        {
            compraRepo = new CompraRepository();

        }

        public List<Compra> ObtenerCompras()
        {
            return compraRepo.ObtenerCompras();
        }

        public bool InsertarCompra(Compra compra)
        {
            return compraRepo.InsertarCompra(compra);
        }
    }
}
