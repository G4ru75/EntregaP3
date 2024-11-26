using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProveedorRepository : ConexionBD
    {
        public List<Proveedor> ObtenerProveedores()
        {
            List<Proveedor> Proveedores = new List<Proveedor>();
            string Sentencia = "SELECT * FROM Proveedores";
            AbrirConexion();
            OracleCommand Comando = new OracleCommand(Sentencia, Conexion());
            OracleDataReader reader = Comando.ExecuteReader();

            while (reader.Read()) 
            {
                Proveedores.Add(new Proveedor
                    {
                        IDProveedor = reader.GetInt32(0),
                        TipoID = new TipoID(reader.GetString(1),""), 
                        Nombre1 = reader.GetString(2),
                        Nombre2 = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Apellido1 = reader.GetString(4),
                        Apellido2 = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        Telefono = reader.GetDouble(6),
                        Email = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                }
                );
            }
            CerrarConexion();
            return Proveedores;
        }

        public bool GuardarProveedor(Proveedor proveedor)
        {
            try
            {
                AbrirConexion();

                using (OracleCommand Comando = new OracleCommand("PKG_GESTIONPROVEEDOR.InsertarProveedor", Conexion()))
                {
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.Parameters.Add("p_id_proveedor", OracleDbType.Int32).Value = proveedor.IDProveedor;
                    Comando.Parameters.Add("p_tipo_id", OracleDbType.Varchar2).Value = proveedor.IDTipo.ToString();
                    Comando.Parameters.Add("p_nombre1", OracleDbType.Varchar2).Value = proveedor.Nombre1;
                    Comando.Parameters.Add("p_nombre2", OracleDbType.Varchar2).Value = proveedor.Nombre2;
                    Comando.Parameters.Add("p_apellido1", OracleDbType.Varchar2).Value = proveedor.Apellido1;
                    Comando.Parameters.Add("p_apellido2", OracleDbType.Varchar2).Value = proveedor.Apellido2;
                    Comando.Parameters.Add("p_telefono", OracleDbType.Double).Value = proveedor.Telefono;
                    Comando.Parameters.Add("p_email", OracleDbType.Varchar2).Value = proveedor.Email; 

                    Comando.ExecuteNonQuery();
                }

                return true; 
            }
            catch (Exception )
            {
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public bool ProveedorExiste(int idproveedor)
        {
            try
            {
                AbrirConexion();
                using (OracleCommand comando = new OracleCommand("SELECT COUNT(*) FROM Proveedores WHERE IDProveedor = :p_id_proveedor", Conexion()))
                {
                    comando.Parameters.Add(":p_id_proveedor", OracleDbType.Int32).Value = idproveedor;
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


        public bool ModificarProveedor(Proveedor proveedor)
        {
            try
            {
                AbrirConexion(); 
                using (OracleCommand comando = new OracleCommand("PKG_GESTIONPROVEEDOR.ModificarProveedor", Conexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("p_id_proveedor", OracleDbType.Int32).Value = proveedor.IDProveedor;
                    comando.Parameters.Add("p_tipo_id", OracleDbType.Varchar2).Value = proveedor.TipoID.IDTipo;
                    comando.Parameters.Add("p_nombre1", OracleDbType.Varchar2).Value = proveedor.Nombre1;
                    comando.Parameters.Add("p_nombre2", OracleDbType.Varchar2).Value = (object)proveedor.Nombre2 ?? DBNull.Value;
                    comando.Parameters.Add("p_apellido1", OracleDbType.Varchar2).Value = proveedor.Apellido1;
                    comando.Parameters.Add("p_apellido2", OracleDbType.Varchar2).Value = (object)proveedor.Apellido2 ?? DBNull.Value;
                    comando.Parameters.Add("p_telefono", OracleDbType.Double).Value = proveedor.Telefono;
                    comando.Parameters.Add("p_email", OracleDbType.Varchar2).Value = (object)proveedor.Email ?? DBNull.Value;

                    comando.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception )
            {
                return false;
            }
            finally
            {
                CerrarConexion(); 
            }
        }

        public bool EliminarProvedor(int idproveedor)
        {
            try
            {
                AbrirConexion();
                using (OracleCommand comando = new OracleCommand("pkg_gestionproveedor.eliminarproveedor", Conexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.Add("p_id_proveedor", OracleDbType.Int32).Value = idproveedor;

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
