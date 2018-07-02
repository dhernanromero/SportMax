using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 

namespace SportMaxModel
{
    public class DALVenta
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
            catch (Exception )
            {
                throw;
            }

            return -1;
        }

        public int RegistrarVenta(int iIdVenta, int iIdVendedor, int iIdCliente, int iIdFormaPago, DateTime dtFechaVenta, decimal dMontoTotal)
        {
            SqlParameter[] param = new SqlParameter[6];

            param[0] = objConexion.crearParametro("@iIdVenta", iIdVenta);
            param[1] = objConexion.crearParametro("@iIdVendedor", iIdVendedor);
            param[2] = objConexion.crearParametro("@iIdCliente", iIdCliente);
            param[3] = objConexion.crearParametro("@iIdFormaPago", iIdFormaPago);
            param[4] = objConexion.crearParametro("@dFechaVenta", dtFechaVenta);
            param[5] = objConexion.crearParametro("@dMontoTotal", dMontoTotal);

            try
            {
                return objConexion.EscribirPorStoreProcedure("Venta_Insertar",param); 
            }
            catch (Exception)
            {
                
                throw;
            }
 

        }
    }
}
