using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportMaxController.Clases
{
    public class Venta
    {
        #region Propiedades Privadas
        private int _idVenta;
        private Empleado _empleado;
        private Cliente _cliente;
        private int _idFormaPago;
        private DateTime _fecha;
        private decimal _montoTotal;
        #endregion

        #region Propiedades Publicas
        public int IdVenta
        {
            get { return _idVenta; }
            set { _idVenta = value; }
        }

        public Empleado Empleado
        {
            get { return _empleado; }
            set { _empleado = value; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public int IdFormaPago
        {
            get { return _idFormaPago; }
            set { _idFormaPago = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public decimal MontoTotal
        {
            get { return _montoTotal; }
            set { _montoTotal = value; }
        }
        #endregion

        #region Metodos
        #endregion
    }
}
