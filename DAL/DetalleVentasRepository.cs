using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetalleVentasRepository : ConexionBD
    {
        public List<DetallesVentas> ObtenerDetallesVentas()
        {
            List<DetallesVentas> DetallesV = new List<DetallesVentas>();
            string Sentencia = "SELECT IDVENTA, NOMBREPRODUCTO,CANTIDADLIBRAS, PRECIOLIBRA, TOTALVENTA, MONTO,VUELTOS, NOMBRECLIENTE, " +
                                "APELLIDOCLIENTE, FECHAFACTURA, METODODEPAGO, IDFACTURA " +
                                "FROM vistaventas ORDER BY 1";
            AbrirConexion();
            OracleCommand Comando = new OracleCommand(Sentencia, Conexion());
            OracleDataReader reader = Comando.ExecuteReader();

            while (reader.Read())
            {
                DetallesV.Add(new DetallesVentas
                {
                    IDVenta = reader.GetInt32(0),
                    NombreProducto = reader.GetString(1),
                    CantidadLibras = reader.GetInt32(2),
                    PrecioLibra = reader.GetDecimal(3),
                    TotalVenta = reader.GetDecimal(4),
                    Monto = reader.GetDecimal(5),
                    Vueltos = reader.GetDecimal(6),
                    NombreCliente = reader.GetString(7),
                    ApellidoCliente = reader.GetString(8),
                    FechaFactura = reader.GetDateTime(9),
                    MetodoDePago = reader.GetString(10), 
                    IDFactura = reader.GetInt32(11)
                }
                );
            }
            CerrarConexion();
            return DetallesV;
        }
    }
}
