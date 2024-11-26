using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula
{
    public class ProveedorService
    {
        private ProveedorRepository ProveedorRepository;

        public ProveedorService() 
        { 
            ProveedorRepository = new ProveedorRepository();
        }

        public List<Proveedor> ObtenerProveedores()
        {
            return ProveedorRepository.ObtenerProveedores();
        }

        public bool GuardarProveedor(Proveedor proveedor)
        {
            if (ProveedorRepository.ProveedorExiste(proveedor.IDProveedor))
            {
                throw new ArgumentException("El proveedor ya existe en la base de datos.");
            }
            return ProveedorRepository.GuardarProveedor(proveedor);
        }

        public bool ModificarProveedor(Proveedor proveedor)
        {
            return ProveedorRepository.ModificarProveedor(proveedor); 
        }

        public bool EliminarProveedor(int idproveedor)
        {
            return ProveedorRepository.EliminarProvedor(idproveedor);
        }

    }
}
