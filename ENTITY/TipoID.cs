﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class TipoID
    {
        public TipoID()
        {
            
        }

        public TipoID(string tipoid, string nombre)
        {
            IDTipo = tipoid;
            Nombre = nombre;
        }

        public string IDTipo { get; set; }
        public string Nombre { get; set; }
    }
}
