using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 

namespace SportMaxModel
{
    public class DALDetallVenta
    {
        Conexion objConexion = new Conexion();

        public int ObtenerId()
        {
            DataTable tabla = new DataTable();
            int id;
            try
            {
                tabla = objConexion.LeerPorStoreProcedure("Venta_ObtenerId");
                foreach (DataRow fila in tabla.Rows)
                {
                    return id = int.Parse(fila["idVenta"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return -1;
        }
    }
}
