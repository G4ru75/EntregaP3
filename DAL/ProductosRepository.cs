using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductosRepository : ConexionBD
    {
        public List<Productos> ObtenerProductos()
        {
            List<Productos> Productos = new List<Productos>();

            string Sentencia = "SELECT * FROM Productos";
            AbrirConexion();
            OracleCommand Comando = new OracleCommand(Sentencia, Conexion());
            OracleDataReader reader = Comando.ExecuteReader();

            while (reader.Read())
            {
                Productos.Add(new Productos
                {
                    IDProducto = reader.GetString(0),
                    IDCategoria = new Categoria(reader.GetString(1), ""),
                    NombreProducto = reader.GetString(2),
                    PrecioVenta = reader.GetDecimal(3),
                    Cantidad = reader.GetDecimal(4),
                   
                }
                );
            }
            CerrarConexion();
            return Productos;
        }

        public bool GuardarProducto(Productos producto)
        {
            try
            {
                AbrirConexion();

                using (OracleCommand Comando = new OracleCommand("PKG_GestionProductos.InsertarProducto", Conexion()))
                {
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.Parameters.Add("p_id_producto", OracleDbType.Varchar2).Value = producto.IDProducto;
                    Comando.Parameters.Add("p_id_categoria", OracleDbType.Varchar2).Value = producto.IDCategoria.IDCategoria;
                    Comando.Parameters.Add("p_nombre_producto", OracleDbType.Varchar2).Value = producto.NombreProducto;

                    Comando.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool ProductoExiste(string idproducto)
        {
            try
            {
                AbrirConexion();
                using (OracleCommand comando = new OracleCommand("SELECT COUNT(*) FROM Productos WHERE IDProducto = :p_id_producto", Conexion()))
                {
                    comando.Parameters.Add(":p_id_producto", OracleDbType.Varchar2).Value = idproducto;
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool ModificarProducto(Productos producto)
        {
            try
            {
                AbrirConexion();
                using (OracleCommand comando = new OracleCommand("PKG_GestionProductos.modificarproducto", Conexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("p_id_producto", OracleDbType.Varchar2).Value = producto.IDProducto;
                    comando.Parameters.Add("p_id_categoria", OracleDbType.Varchar2).Value = producto.IDCategoria.IDCategoria;
                    comando.Parameters.Add("p_nombre_producto", OracleDbType.Varchar2).Value = producto.NombreProducto;
                    comando.Parameters.Add("p_precio_venta", OracleDbType.Decimal).Value = producto.PrecioVenta;
                    comando.Parameters.Add("p_cantidad", OracleDbType.Decimal).Value = producto.Cantidad;

                    comando.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool EliminarProducto(string idproducto)
        {
            try
            {
                AbrirConexion();
                using (OracleCommand comando = new OracleCommand("pkg_gestionproductos.eliminarproducto", Conexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("p_id_producto", OracleDbType.Varchar2).Value = idproducto;

                    comando.ExecuteNonQuery();

                    return true;
                }


            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }
    }
}
 