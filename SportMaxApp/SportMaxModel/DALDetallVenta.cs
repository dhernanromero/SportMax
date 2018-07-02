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
                tabla = objConexion.LeerPorStoreProcedure("DetalleVenta_ObtenerId");
                foreach (DataRow fila in tabla.Rows)
                {
                    return id = int.Parse(fila["idDetalle"].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return -1;
        }

        public int RegistrarDetalleVenta(int iIdDetalleVenta, int iIdVenta, int iIdProducto, int iCantidad)
        {
            SqlParameter[] param = new SqlParameter[4];

            param[0] = objConexion.crearParametro("@iIdDetalle", iIdDetalleVenta);
            param[1] = objConexion.crearParametro("@iIdVenta", iIdVenta);
            param[2] = objConexion.crearParametro("@iIdProducto", iIdProducto);
            param[3] = objConexion.crearParametro("@iCantidad", iCantidad);

            try
            {
                return objConexion.EscribirPorStoreProcedure("DetalleVenta_Insertar", param); 
            }
            catch (Exception)
            {
                
                throw;
            }

        }
    }
}
