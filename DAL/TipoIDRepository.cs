using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoIDRepository : ConexionBD
    {
        public List<TipoID> ObtenerTipos()
        {
            List<TipoID> Tipos = new List<TipoID>();
            string Sentencia = "SELECT IDTipo, Nombre FROM TipoID";
            AbrirConexion();
            OracleCommand Comando = new OracleCommand(Sentencia, Conexion());
            OracleDataReader reader = Comando.ExecuteReader();

            while (reader.Read())
            {
                Tipos.Add(new TipoID(reader.GetString(0), reader.GetString(1)));
            }

            CerrarConexion();
            return Tipos;
        }
    }
}
 
 

