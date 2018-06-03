using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportMaxController.Clases
{
    public class TipoUsuario
    {
        #region Propiedades Privadas
        private int _idTipoUsuario;
        private string _descripcion;
        private string _codUsuario;

        #endregion  

        #region Propiedades Publicas

        public int IdTipoUsuario
        {
            get { return _idTipoUsuario; }
            set { _idTipoUsuario = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public string CodUsuario
        {
            get { return _codUsuario; }
            set { _codUsuario = value; }
        }

        #endregion

        #region Metodos
        #endregion

    }
}
