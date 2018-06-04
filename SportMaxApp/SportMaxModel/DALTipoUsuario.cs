using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 

namespace SportMaxModel
{
    public class DALTipoUsuario
    {
        Conexion objConexion = new Conexion();

        public DataTable Listar()
        {
            DataTable tabla = new DataTable();

            try
            {
                tabla = objConexion.LeerPorStoreProcedure("TipoUsuario_Listar");
            }
            catch (Exception)
            {
                
                throw;
            }

            return tabla;
        }
    }
}
