using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SportMaxController.Clases
{
    public class Usuario
    {
        #region Propiedades Privadas
        private int _idUsuario;
        private string _usuario;
       //private string _password;
        private TipoUsuario _tipoUsuario;
        private static readonly Random random = new Random();
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

        //public string Password
        //{
        //    get { return _password; }
        //    set { _password = value; }
        //}

        public TipoUsuario TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }

        #endregion

        #region Metodos
        public string IniciarSesion(string sUser, string sPass)
        {
            return "";
        }

     

        #endregion
    }
}
