using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportMaxController.Clases
{
    public class Proveedor
    {
        #region Variables Privadas
        private int _idProveedor;
        private string _razonsocial;
        private string _cuil;
        private string _direccion;
        private int _telefono;
        private bool _estado;
        #endregion

        #region Variables Publicas
        public int IdProveedor
        {
            get { return _idProveedor;}
            set { _idProveedor = value; }
        }

        public string RazonSocial
        {
            get { return _razonsocial; }
            set { _razonsocial = value; }
        }

        public string Cuil
        {
            get { return _cuil; }
            set { _cuil = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public bool Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        #endregion

        #region Metodos
        #endregion
    }
}
