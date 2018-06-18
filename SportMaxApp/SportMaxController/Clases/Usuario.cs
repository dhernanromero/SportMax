using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportMaxModel;
using System.Data;


namespace SportMaxController.Clases
{
    public class Usuario
    {
        #region Propiedades Privadas
        private int _idUsuario;
        private string _usuario;
        private string _password;
        private TipoUsuario _tipoUsuario;
        
        #endregion

        #region Propiedades Publicas

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public string User
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public TipoUsuario TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }

        #endregion

        #region Metodos
        public Usuario IniciarSesion(string sUser, string sPass)
        {
            DALUsuario dalUser = new DALUsuario();
            DataTable tabal = dalUser.Autenticar(sUser, sPass);
            List<Usuario> lista = new List<Usuario>();
            Usuario pUser = new Usuario();
            TipoUsuario pTipoUsuario;

            foreach (DataRow fila in tabal.Rows)
            {
                pUser = new Usuario();
                pTipoUsuario = new TipoUsuario();

                pUser.IdUsuario = int.Parse(fila["idUsuario"].ToString());
                pUser.User = fila["Usuario"].ToString();
                pTipoUsuario.IdTipoUsuario = int.Parse(fila["idTipoUsuario"].ToString());
                pTipoUsuario.Descripcion = fila["Descripcion"].ToString();
                pTipoUsuario.CodUsuario = fila["CodUsuario"].ToString();
                pUser.TipoUsuario = pTipoUsuario;
                
            }

            return pUser;

         }
  
        public int Agregar()
        {
            DALUsuario user = new DALUsuario();

            try 
	        {
                return user.AgregarUsuario(this.IdUsuario, this.User, this.Password, this.TipoUsuario.IdTipoUsuario); 
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }
           
        }

        public int ObtenerId()
        {
           

        }
        #endregion
    }
}
