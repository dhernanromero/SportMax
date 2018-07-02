using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SportMaxModel;

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
        private DetalleVenta _detalleVenta;
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

        public int Agregar()
        {
            DALVenta dalVenta = new DALVenta();
            DALDetallVenta dalDetalle = new DALDetallVenta();

            try
            {
                return dalVenta.RegistrarVenta(this.IdVenta, this.Empleado.IdEmpleado, this.Cliente.IdCliente, this.IdFormaPago, this.Fecha, this.MontoTotal);
               
            }
            catch (Exception)
            {
                throw;
            }
                

        }

        public int ObtenerId()
        {
            DALVenta vent = new DALVenta();
            try
            {
                return vent.ObtenerId();
            }
            catch (Exception )
            {
                throw; 
            }
        }

        #endregion

    }
}
