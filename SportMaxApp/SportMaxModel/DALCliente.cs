using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 

namespace SportMaxModel
{
    public class DALCliente
    {
        Conexion objConexion = new Conexion();

        public int AgregarCliente(int iIdCliente, string sNombre, string sApellido, int iDNI, DateTime dtFechaNacimiento, string sDireccion, int iTelefono, int iTarjeta)
        {
            SqlParameter[] param = new SqlParameter[8];

            param[0] = objConexion.crearParametro("@iIdCliente", iIdCliente);
            param[1] = objConexion.crearParametro("@sNombre", sNombre);
            param[2] = objConexion.crearParametro("@sApellido", sApellido);
            param[3] = objConexion.crearParametro("@iDNI", iDNI);
            param[4] = objConexion.crearParametro("@dFecha", dtFechaNacimiento);
            param[5] = objConexion.crearParametro("@sDireccion", sDireccion);
            param[6] = objConexion.crearParametro("@iTelefono", iTelefono);
            param[7] = objConexion.crearParametro("@iTarjeta", iTarjeta);

            try
            {
                return objConexion.EscribirPorStoreProcedure("Cliente_Insertar", param); 
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public int ObtenerId()
        {
            DataTable tabla = new DataTable();
            int id;
            try
            {
                tabla = objConexion.LeerPorStoreProcedure("Cliente_ObtenerId");
                foreach (DataRow fila in tabla.Rows)
                {
                    return id = int.Parse(fila["idEmpleado"].ToString());
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return -1;
        }

        public DataTable BuscarxDNI(int pDNI)
        {
            DataTable tabla = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = objConexion.crearParametro("@iDNI", pDNI);
            try
            {
                tabla = objConexion.LeerPorStoreProcedure("Cliente_BuscarxDNI", param);
            }
            catch (Exception)
            {

                throw;
            }

            return tabla;
        }

    }
}
