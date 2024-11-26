using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAula
{
    public class CategoriaService
    {
        CategoriaRepository CategoriaRepo; 

        public CategoriaService()
        {
            CategoriaRepo = new CategoriaRepository();
        }

        public List<Categoria> ObtenerCategorias()
        {
             return CategoriaRepo.ObtenerCategorias();
        }

        public bool GuardarCategoria(Categoria categoria)
        {
            if (CategoriaRepo.CategoriaExiste(categoria.IDCategoria))
            {
                throw new ArgumentException("La categoria ya existe en la base de datos.");
            }
            return CategoriaRepo.GuardarCategoria(categoria);
        }

        public bool ModificarCatgoria(Categoria categoria)
        {
            return CategoriaRepo.ModificarCategoria(categoria); 
        }

        public bool Eliminar(string idcategoria)
        {
            return CategoriaRepo.Eliminar(idcategoria);
        }
    }
}
