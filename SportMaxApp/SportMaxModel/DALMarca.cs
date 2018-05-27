using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SportMaxModel
{
    public class DALMarca
    {
        Conexion objConexion = new Conexion();

        public int AgregarMarca(int iIdMarca, string sDescripcion)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = objConexion.crearParametro("@IdMarca", iIdMarca);
            param[1] = objConexion.crearParametro("@Descripcion", sDescripcion);

            try
            {
                return objConexion.EscribirPorStoreProcedure("Marca_Insertar", param);
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
                tabla = objConexion.LeerPorStoreProcedure("Marca_Listar");
            }
            catch (Exception)
            {
                
                throw;
            }

            return tabla;
        }
    }
}
