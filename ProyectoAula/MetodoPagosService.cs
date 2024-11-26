using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula
{
    public class MetodoPagosService
    {
        private MetodoPagosRepository PagosRepo;

        public MetodoPagosService()
        {
            PagosRepo = new MetodoPagosRepository();
        }

        public List<MetodoPagos> ObtenerPagos()
        {
            return PagosRepo.ObtenerPagos();
        }

        public bool GuardarMetodos(MetodoPagos metodos)
        {
            if (PagosRepo.MetodoExiste(metodos.IDPago))
            {
                throw new ArgumentException("El Metodo ya existe en la base de datos.");
            }
            return PagosRepo.GuardarMetodo(metodos); 
        }

        public bool ModificarMetodo(MetodoPagos metodos)
        {
            return PagosRepo.ModificarMetodo(metodos);
        }

        public bool EliminarMetodo(string idmetodo)
        {
            return PagosRepo.Eliminar(idmetodo);
        }
        
    }
}
