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
    public class VentasRepository : ConexionBD
    {
        public List<Venta> ObtenerVentas()
        {
            List<Venta> Ventas = new List<Venta>();
            string Sentencia = "SELECT * FROM Ventas ORDER BY IDVenta";
            AbrirConexion();
            OracleCommand Comando = new OracleCommand(Sentencia, Conexion());
            OracleDataReader reader = Comando.ExecuteReader();

            while (reader.Read())
            {
                while (reader.Read())
                {
                    Venta Venta = new Venta(
                             Convert.ToInt32(reader["IDVenta"]),
                             new Productos() { IDProducto = reader["IDPRODUCTO"].ToString() },
                             Convert.ToDecimal(reader["CANTIDADLIBRAS"]),
                             Convert.ToDecimal(reader["PRECIOLIBRA"]),
                             Convert.ToString(reader["NOMBRECLIENTE"]),
                             Convert.ToString(reader["APELLIDOCLIENTE"]),
                             new Factura() { IDFactura = Convert.ToInt32(reader["IDFACTURA"])}
                             );
                    Ventas.Add(Venta);
                }
            }
            CerrarConexion();
            return Ventas;

        }

        public bool Vender(Venta ventas, decimal monto, string metodo)
        {
            try
            {
                AbrirConexion();

                using (OracleCommand Comando = new OracleCommand("pkg_gestionventas.hacerventa", Conexion()))
                {
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.Parameters.Add("p_id_producto", OracleDbType.Varchar2).Value = ventas.IDProducto.ToString();
                    Comando.Parameters.Add("p_cantidad", OracleDbType.Int32).Value = ventas.Cantidad;
                    Comando.Parameters.Add("p_nombre_cliente", OracleDbType.Varchar2).Value = ventas.NombreCliente;
                    Comando.Parameters.Add("p_apellido_cliente", OracleDbType.Varchar2).Value = ventas.ApellidoCliente;
                    Comando.Parameters.Add("p_monto", OracleDbType.Decimal).Value = monto;
                    Comando.Parameters.Add("p_id_metodo_pago", OracleDbType.Varchar2).Value = metodo; 

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
    }
}
