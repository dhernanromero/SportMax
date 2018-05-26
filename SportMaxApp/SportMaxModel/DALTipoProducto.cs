using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SportMaxModel
{
    public class DALTipoProducto
    {
        Conexion objConexion = new Conexion();

        public int AgregarTipoProducto(int iIdTipoProducto, string sDescripcion)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = objConexion.crearParametro("@IdTipoProducto", iIdTipoProducto);
            param[1] = objConexion.crearParametro("@Descripcion", sDescripcion);

            try
            {
                return objConexion.EscribirPorStoreProcedure("TipoProducto_Insertar", param);
            
            }
            catch (Exception)
            {
                
                throw;
            }
         
                
        }

        public DataTable Listar()
        {
            DataTable tabla = new DataTable();

            try
            {
                tabla = objConexion.LeerPorStoreProcedure("TipoProducto_Listar");
            }
            catch (Exception)
            {
                
                throw;
            }
            return tabla;
        }
    }
}
