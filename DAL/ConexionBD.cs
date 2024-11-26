using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConexionBD
    {
        
        string cadenaConexion = "User Id=Negocio;Password=123456;Data Source=localhost:1521/xepdb1;";

        private OracleConnection _conn;
        public ConexionBD()
        {
            _conn = new OracleConnection(cadenaConexion);
        }
        public bool AbrirConexion()
        {
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
                return true;
            }
            return false;
        }
        public void CerrarConexion()
        {
            _conn.Close();
        }
        public OracleConnection Conexion()
        {
            return _conn;

        }
    }
}

