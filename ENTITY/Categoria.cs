using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Categoria
    {
        public Categoria() { }

        public Categoria(string idcategoria, string nombrecategoria)
        {
            IDCategoria = idcategoria;
            NombreCategoria = nombrecategoria; 
        }

        public string IDCategoria { get; set; }
        public string NombreCategoria { get; set; }
    }
}
