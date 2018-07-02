using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportMaxModel;

namespace SportMaxController.Clases
{
    public class DetalleVenta
    {
        #region Propiedades Privadas
        private int _idDetalle;
        private int _idProducto;
        private int _cantidad;

        #endregion

        #region Propiedades Publicas
        public int IdDetalle
        {
            get { return _idDetalle; }
            set { _idDetalle = value; }
        }

        public int IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        #endregion

        #region Metodos


        public int ObtenerId()
        {
            DALDetalleVenta detVenta = new DALDetalleVenta();
            try
            {
                return detVenta.ObtenerId();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int RegistrarDetalleVenta(int pIdVenta)
        {
            DALDetalleVenta detVenta = new DALDetalleVenta();
            try
            {
                return detVenta.RegistrarDetalleVenta(this.IdDetalle,pIdVenta,this.IdProducto,this.Cantidad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
