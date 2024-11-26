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
    public class CompraRepository : ConexionBD
    {
        public List<Compra> ObtenerCompras()
        {
            List<Compra> Compras = new List<Compra>();

            string Sentencia = "SELECT * FROM Compras ORDER BY IDCompra";
            AbrirConexion();
            OracleCommand Comando = new OracleCommand(Sentencia, Conexion());
            OracleDataReader reader = Comando.ExecuteReader();

            while (reader.Read())
            {
                Compra compra = new Compra(
                         Convert.ToInt32(reader["IDCOMPRA"]),
                         new Proveedor() { IDProveedor = Convert.ToInt32(reader["IDPROVEEDOR"]) },
                         new Productos() { IDProducto = reader["IDPRODUCTO"].ToString() },
                         Convert.ToInt32(reader["CANTIDADCAJAS"]),
                         Convert.ToDecimal(reader["PRECIOCAJA"]),
                         Convert.ToDecimal(reader["TOTALCOMPRA"]),
                         Convert.ToDateTime(reader["FECHACOMPRA"]),
                         new MetodoPagos() { IDPago = reader["PAGOID"].ToString()}
                         );
                Compras.Add(compra);
            }
            CerrarConexion();
            return Compras;
        }

        public bool InsertarCompra(Compra compra)
        {
            try
            {
                AbrirConexion();

                using (OracleCommand Comando = new OracleCommand("pkg_gestioncompras.insertarcompra", Conexion()))
                {
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.Parameters.Add("p_id_proveedor", OracleDbType.Int32).Value = compra.IDProveedor;
                    Comando.Parameters.Add("p_id_producto", OracleDbType.Varchar2).Value = compra.IDProducto.ToString();
                    Comando.Parameters.Add("p_cantidad_cajas", OracleDbType.Int32).Value = compra.CantidadCajas;
                    Comando.Parameters.Add("p_precio_caja", OracleDbType.Decimal).Value = compra.PrecioCaja;
                    Comando.Parameters.Add("p_fecha_compra", OracleDbType.Date).Value = compra.FechaCompra;
                    Comando.Parameters.Add("p_pago_id", OracleDbType.Varchar2).Value = compra.Pagoid.ToString();

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
