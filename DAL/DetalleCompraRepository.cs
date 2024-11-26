using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DetalleCompraRepository : ConexionBD
    {
        public List<DetalleCompras> ObtenerDetalles()
        {
            List<DetalleCompras> Detalles = new List<DetalleCompras>();
            string Sentencia = "SELECT IDCompra, IDProveedor, Nombre1, Apellido1, NombreProducto, CantidadCajas, PrecioCaja, TotalCompra, " +
                                "MetodoDePago " +
                                "FROM VistaCompras ORDER BY 1";
            AbrirConexion();
            OracleCommand Comando = new OracleCommand(Sentencia, Conexion());
            OracleDataReader reader = Comando.ExecuteReader();

            while (reader.Read())
            {
                Detalles.Add(new DetalleCompras
                {
                    NumeroCompra = reader.GetInt32(0),
                    IDProveedor = reader.GetInt32(1),
                    NombreProveedor = reader.GetString(2),
                    ApellidoProveedor = reader.GetString(3),
                    NombreProducto = reader.GetString(4),
                    Cantidad = reader.GetInt32(5),
                    Precio = reader.GetDecimal(6),
                    Total = reader.GetDecimal(7),
                    MetodoPago = reader.GetString(8)
                }
                );
            }
            CerrarConexion();
            return Detalles;

        }   
    }
}
