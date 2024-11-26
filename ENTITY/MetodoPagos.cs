using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class MetodoPagos
    {
        public MetodoPagos() { }

        public MetodoPagos(string idpago, string nombremetodo)
        {
            IDPago = idpago;
            NombreMetodo = nombremetodo;
        }

        public string IDPago {  get; set; }
        public string NombreMetodo { get; set; }
    }
}
