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
    public class CategoriaRepository: ConexionBD
    {
        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> Categorias = new List<Categoria>();
            string Sentencia = "SELECT * FROM Categorias";
            AbrirConexion();
            OracleCommand Comando = new OracleCommand(Sentencia, Conexion());
            OracleDataReader reader = Comando.ExecuteReader();

            while (reader.Read())
            {
                Categorias.Add(new Categoria(reader.GetString(0), reader.GetString(1)));
            }

            CerrarConexion();
            return Categorias;
        }

        public bool GuardarCategoria(Categoria categoria)
        {
            try
            {
                AbrirConexion();

                using (OracleCommand Comando = new OracleCommand("INSERT INTO Categorias(IDCategoria, NombreCategoria)VALUES(:IDCategoria, :NombreCategoria)", Conexion()))
                {
                    Comando.CommandType = CommandType.Text;
                    Comando.Parameters.Add(new OracleParameter("IDCategoria", OracleDbType.Varchar2)).Value = categoria.IDCategoria;
                    Comando.Parameters.Add(new OracleParameter("NombreCategoria", OracleDbType.Varchar2)).Value = categoria.NombreCategoria;

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

        public bool CategoriaExiste(string idcategoria)
        {
            try
            {
                AbrirConexion();
                using (OracleCommand comando = new OracleCommand("SELECT COUNT(*) FROM Categorias WHERE IDCategoria = :p_id_categoria", Conexion()))
                {
                    comando.Parameters.Add(":p_id_categoria", OracleDbType.Varchar2).Value = idcategoria;
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

        public bool ModificarCategoria(Categoria categoria)
        {
            try
            {
                AbrirConexion();

                using (OracleCommand Comando = new OracleCommand("UPDATE Categorias SET NombreCategoria = :NombreCategoria WHERE IDCategoria = :IDCategoria", Conexion()))
                {
                    Comando.Parameters.Add(new OracleParameter(":NombreCategoria", OracleDbType.Varchar2)).Value = categoria.NombreCategoria;
                    Comando.Parameters.Add(new OracleParameter(":IDCategoria", OracleDbType.Varchar2)).Value = categoria.IDCategoria;

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

        public bool Eliminar(string idcategoria)
        {
            try
            {
                AbrirConexion();

                using (OracleCommand Comando = new OracleCommand("DELETE FROM Categorias WHERE IDCategoria = :IDCategoria", Conexion()))
                {
                    Comando.Parameters.Add(new OracleParameter(":IDCategoria", OracleDbType.Varchar2)).Value = idcategoria;

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
