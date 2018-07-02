using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SportMaxModel
{
    public class DALEmpleado
    {
        Conexion objConexion = new Conexion();

        public int AgregarEmpleado(int iIdEmpleado, int iIdUsuario, string sLegajo, string sNombre, string sApellido, int iDni, DateTime dFechaNacimiento, string sDireccion, int iTelefono, int bEstado, decimal dSueldo)
        {
            SqlParameter[] param = new SqlParameter[11];

            param[0] = objConexion.crearParametro("@IdEmpleado", iIdEmpleado);
            param[1] = objConexion.crearParametro("@IdUsuario", iIdUsuario);
            param[2] = objConexion.crearParametro("@Legajo", sLegajo);
            param[3] = objConexion.crearParametro("@Nombre", sNombre);
            param[4] = objConexion.crearParametro("@Apellido", sApellido);
            param[5] = objConexion.crearParametro("@DNI", iDni);
            param[6] = objConexion.crearParametro("@FechaNacimiento", dFechaNacimiento);
            param[7] = objConexion.crearParametro("@Direccion", sDireccion);
            param[8] = objConexion.crearParametro("@Telefono", iTelefono);
            param[9] = objConexion.crearParametro("@Estado", bEstado);
            param[10] = objConexion.crearParametro("@Sueldo", dSueldo);
            //param[11] = objConexion.crearParametro("@Usuario", sUsuario);

            try
            {
                return objConexion.EscribirPorStoreProcedure("Empleado_Insertar", param); 
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
                tabla = objConexion.LeerPorStoreProcedure("Empleado_Listar");
            }
            catch (Exception)
            {
                
                throw;
            }

            return tabla;
        }

        public int ObtenerId()
        {
            DataTable tabla = new DataTable();
            int id;
            try
            {
                tabla = objConexion.LeerPorStoreProcedure("Empleado_ObtenerId");
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

        public DataTable BuscarxLegajo(string pLegajo)
        {
            DataTable tabla = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = objConexion.crearParametro("@sLegajo", pLegajo);
            try
            {
                tabla = objConexion.LeerPorStoreProcedure("Empleado_BuscarxLegajo", param);
            }
            catch (Exception)
            {

                throw;
            }

            return tabla;
        }

        public DataTable BuscarxDNI(int pDNI)
        {
            DataTable tabla = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = objConexion.crearParametro("@iDNI", pDNI);
            try
            {
                tabla = objConexion.LeerPorStoreProcedure("Empleado_BuscarxDNI", param);
            }
            catch (Exception)
            {

                throw;
            }

            return tabla;
        }

        public DataTable BuscarxIdUsuario(int pIdUsuario)
        {
            DataTable tabla = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = objConexion.crearParametro("@iIdUsuario", pIdUsuario);
            try
            {
                tabla = objConexion.LeerPorStoreProcedure("Empleado_BuscarxIdUsuario", param);
            }
            catch (Exception)
            {

                throw;
            }

            return tabla;
        }

        public int ModificarEmpleado(int iIdEmpleado, int iIdUsuario, string sLegajo, string sNombre, string sApellido, int iDni, DateTime dFechaNacimiento, string sDireccion, int iTelefono, int bEstado, decimal dSueldo)
        {
            SqlParameter[] param = new SqlParameter[11];

            param[0] = objConexion.crearParametro("@IdEmpleado", iIdEmpleado);
            param[1] = objConexion.crearParametro("@IdUsuario", iIdUsuario);
            param[2] = objConexion.crearParametro("@Legajo", sLegajo);
            param[3] = objConexion.crearParametro("@Nombre", sNombre);
            param[4] = objConexion.crearParametro("@Apellido", sApellido);
            param[5] = objConexion.crearParametro("@DNI", iDni);
            param[6] = objConexion.crearParametro("@FechaNacimiento", dFechaNacimiento);
            param[7] = objConexion.crearParametro("@Direccion", sDireccion);
            param[8] = objConexion.crearParametro("@Telefono", iTelefono);
            param[9] = objConexion.crearParametro("@Estado", bEstado);
            param[10] = objConexion.crearParametro("@Sueldo", dSueldo);
            //param[11] = objConexion.crearParametro("@Usuario", sUsuario);

            try
            {
                return objConexion.EscribirPorStoreProcedure("Empleado_Modificar", param);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int EliminarEmpleado(int iIdEmpleado, int iIdUsuario, string sLegajo)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = objConexion.crearParametro("@IdEmpleado", iIdEmpleado);
            param[1] = objConexion.crearParametro("@IdUsuario", iIdUsuario);
            param[2] = objConexion.crearParametro("@Legajo", sLegajo);

            try
            {
                return objConexion.EscribirPorStoreProcedure("Empleado_Eliminar", param); 
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
