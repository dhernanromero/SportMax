using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SportMaxModel
{
    public class DALProducto
    {
        Conexion objConexion = new Conexion();

        //metodo test 
        public int AgregarProducto(int iIdProducto, int iIdTipoProducto, int iIdMarca, string sDescripcion,float mPrecio, int iCantidad)
        {


            //string comandoInsert = "insert into producto(descripcino, id_tipo) values ('" + pDescripcion + "', " + idTipoProducto + ")";
            //return objConexion.EscribirPorComando(comandoInsert);

            SqlParameter[] param = new SqlParameter[6];

            param[0] = objConexion.crearParametro("@IdProducto", iIdProducto);
            param[1] = objConexion.crearParametro("@IdTipoProducto", iIdTipoProducto);
            param[2] = objConexion.crearParametro("@IdMarca", iIdMarca);
            param[3] = objConexion.crearParametro("@Descripcion", sDescripcion);
            param[4] = objConexion.crearParametro("@Precio", mPrecio);
            param[5] = objConexion.crearParametro("@Cantidad", iCantidad);

            try
            {
                return objConexion.EscribirPorStoreProcedure("Producto_Insertar", param);
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
                tabla = objConexion.LeerPorStoreProcedure("Producto_Listar");
            }
            catch (Exception)
            {
                
                throw;
             
            }
          

            return tabla;
        }

        public DataTable BuscarxCodigo(int Codigo)
        {
            DataTable tabla = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = objConexion.crearParametro("@IdProducto", Codigo);
            try
            {
                tabla = objConexion.LeerPorStoreProcedure("Producto_BuscarxCodigo", param);
            }
            catch (Exception)
            {

                throw;
            }


            return tabla;
        }

        public DataTable BuscarxDescripcion(string Descrip)
        {
            DataTable tabla = new DataTable();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = objConexion.crearParametro("@Descripcion", Descrip);
            try
            {
                tabla = objConexion.LeerPorStoreProcedure("Producto_BuscarxDescripcion",param);
            }
            catch (Exception)
            {

                throw;
            }


            return tabla;
        }

        public int ModificarProducto(int iIdProducto, int iIdTipoProducto, int iIdMarca, string sDescripcion, float mPrecio, int iCantidad)
        {

            SqlParameter[] param = new SqlParameter[6];

            param[0] = objConexion.crearParametro("@IdProducto", iIdProducto);
            param[1] = objConexion.crearParametro("@IdTipoProducto", iIdTipoProducto);
            param[2] = objConexion.crearParametro("@IdMarca", iIdMarca);
            param[3] = objConexion.crearParametro("@Descripcion", sDescripcion);
            param[4] = objConexion.crearParametro("@Precio", mPrecio);
            param[5] = objConexion.crearParametro("@Cantidad", iCantidad);

            try
            {
                return objConexion.EscribirPorStoreProcedure("Producto_Modificar", param);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
