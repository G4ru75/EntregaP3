using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Proveedor
    {
        public Proveedor()
        {
            
        }

        public Proveedor(int idproveedor, TipoID tipoid, string nombre1, string nombre2, string apellido1, string apellido2, double telefono, string email)
        {
            IDProveedor = idproveedor;
            TipoID = tipoid;
            Nombre1 = nombre1;
            Nombre2 = nombre2;
            Apellido1 = Apellido1;
            Apellido2 = Apellido2;
            Telefono = telefono;
            Email = email;
 
        }

        public int IDProveedor { get; set; }
        public TipoID TipoID { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 {get; set; }
        public string Apellido2 { get; set; }
        public double Telefono { get; set; }
        public string Email { get; set; }

        public string IDTipo => TipoID?.IDTipo ?? string.Empty;
    }
}

