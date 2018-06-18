using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

namespace SportMaxModel
{
    public class DALUsuario
    {
        Conexion objConexion = new Conexion();

        public DataTable Autenticar(string sUsuario,string sPass)
        {
            string hash = EncodePassword(string.Concat(sUsuario,sPass));

            SqlParameter[] param = new SqlParameter[2];

            param[0] = objConexion.crearParametro("@Usuario",sUsuario);
            param[1] = objConexion.crearParametro("@Pass", hash);

            try
            {
                return objConexion.LeerPorStoreProcedure("Usuario_Autenticar",param);
            }
            catch (Exception)
            {
           
                throw;
            }

        }

        public static string EncodePassword(string originalPassword)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword);
            byte[] hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }

        public int AgregarUsuario(int iIdUsuario, string sUsuario, string sPass, int iTipoUsuario)
        {
            SqlParameter[] param = new SqlParameter[3];
            string hash = EncodePassword(string.Concat(sUsuario, sPass)); 
            //param[0] = objConexion.crearParametro("@IdUsuario", iIdUsuario);
            //param[1] = objConexion.crearParametro("@Usuario", sUsuario);
            //param[2] = objConexion.crearParametro("@Pass", hash);
            //param[3] = objConexion.crearParametro("@IdTipoUsuario", iTipoUsuario);

            param[0] = objConexion.crearParametro("@Usuario", sUsuario);
            param[1] = objConexion.crearParametro("@Pass", hash);
            param[2] = objConexion.crearParametro("@IdTipoUsuario", iTipoUsuario);

            try
            {
                return objConexion.EscribirPorStoreProcedure("Usuario_Insertar", param); 
            }
            catch (Exception ex)
            {
                return ex.HResult; 
                throw;
            }
        }

        //public int ObtenerId()
        //{
  

        //}
    }
}
