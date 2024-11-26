using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula
{
    public class TipoIDService
    {
        private TipoIDRepository TipoRepo;

        public TipoIDService()
        {
            TipoRepo = new TipoIDRepository();
        }

        public List<TipoID> ObtenerTiposID() 
        { 
            return TipoRepo.ObtenerTipos(); 
        }
    }
}
