using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportMaxModel;
using System.Data;
using System.Data.SqlClient; 

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

        public int Agregar()
        {
            DALCliente dalClient = new DALCliente();
            
            try
            {
                return dalClient.AgregarCliente(this.IdCliente, this.Nombre, this.Apellido, this.DNI, this.FechaNacimiento, this.Direccion, this.Telefono, this.Tarjeta);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public Cliente BuscarxDNI(int pDNI)
        {
            DALCliente dalCliente = new DALCliente();
            DataTable tabla = dalCliente.BuscarxDNI(pDNI);
            List<Cliente> lista = new List<Cliente>();
            Cliente nCliente = new Cliente();

            foreach (DataRow fila in tabla.Rows)
            {
                nCliente.IdCliente = int.Parse(fila["IdCliente"].ToString());
                nCliente.Nombre = fila["Nombre"].ToString();
                nCliente.Apellido = fila["Apellido"].ToString();
                nCliente.DNI = int.Parse(fila["DNI"].ToString());
                nCliente.FechaNacimiento = DateTime.Parse(fila["FechaNAcimiento"].ToString());
                nCliente.Direccion = fila["Direccion"].ToString();
                nCliente.Telefono = int.Parse(fila["Telefono"].ToString());
                nCliente.Tarjeta = int.Parse(fila["Tarjeta"].ToString());

            }

            return nCliente;

        }

        public int ObtenerId()
        {
            DALCliente clie = new DALCliente();
            try
            {
                return clie.ObtenerId();
            }
            catch (Exception)
            {

                throw;
            }

        }


        #endregion
    }
}
