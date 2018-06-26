using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportMaxController.Clases
{
    public class Cliente : Persona 
    {
        #region Propiedades Privadas
        private int _IdCliente;
        private int _Tarjeta;
        #endregion

        #region Propiedad Publica
        public int IdCliente
        {
            get { return _IdCliente; }
            set { _IdCliente = value; }
        }

        public int Tarjeta
        {
            get { return _Tarjeta; }
            set { _Tarjeta = value; }
        }
        #endregion

        #region Metodos
        #endregion
    }
}
