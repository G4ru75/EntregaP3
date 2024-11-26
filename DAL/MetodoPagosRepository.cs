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
    public class MetodoPagosRepository : ConexionBD
    {
        public List<MetodoPagos> ObtenerPagos()
        {
            List<MetodoPagos> Pagos = new List<MetodoPagos>();
            string Sentencia = "SELECT IDPago, NombreMetodo FROM MetodoPagos";
            AbrirConexion();
            OracleCommand Comando = new OracleCommand(Sentencia, Conexion());
            OracleDataReader reader = Comando.ExecuteReader();

            while (reader.Read())
            {
                Pagos.Add(new MetodoPagos(reader.GetString(0), reader.GetString(1)));
            }

            CerrarConexion();
            return Pagos;
        }

 
       public bool GuardarMetodo(MetodoPagos metodo)
        {
            try
            {
                AbrirConexion();

                using (OracleCommand Comando = new OracleCommand("INSERT INTO MetodoPagos(IDPago, NombreMetodo)VALUES(:IDPago, :NombreMetodo)", Conexion()))
                {
                    Comando.CommandType = CommandType.Text;
                    Comando.Parameters.Add(new OracleParameter("IDPago", OracleDbType.Varchar2)).Value = metodo.IDPago;
                    Comando.Parameters.Add(new OracleParameter("NombreMetodo", OracleDbType.Varchar2)).Value = metodo.NombreMetodo;

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

        public bool MetodoExiste(string idmetodo)
        {
            try
            {
                AbrirConexion();
                using (OracleCommand comando = new OracleCommand("SELECT COUNT(*) FROM MetodoPagos WHERE IDPago = :p_id_pago", Conexion()))
                {
                    comando.Parameters.Add(":p_id_pago", OracleDbType.Varchar2).Value = idmetodo;
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

        public bool ModificarMetodo(MetodoPagos metodo)
        {
            try
            {
                AbrirConexion();

                using (OracleCommand Comando = new OracleCommand("UPDATE MetodoPagos SET NombreMetodo = :NombreMetodo WHERE IDPago = :IDPago", Conexion()))
                {
                    Comando.Parameters.Add(new OracleParameter(":NombreMetodo", OracleDbType.Varchar2)).Value = metodo.NombreMetodo;
                    Comando.Parameters.Add(new OracleParameter(":IDPago", OracleDbType.Varchar2)).Value = metodo.IDPago;

                    int filasAfectadas = Comando.ExecuteNonQuery();
                    return filasAfectadas > 0; // Retorna si se actualizo o no una fila
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool Eliminar(string idmetodo)
        {
            try
            {
                AbrirConexion();

                using (OracleCommand Comando = new OracleCommand("DELETE FROM METODOPAGOS WHERE IDPAGO = :IDPago", Conexion()))
                {
                    Comando.Parameters.Add(new OracleParameter(":IDPago", OracleDbType.Varchar2)).Value = idmetodo;

                    Comando.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
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
