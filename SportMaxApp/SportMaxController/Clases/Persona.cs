using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportMaxController.Clases
{
    public class Persona
    {
        #region Propiedades Privadas
        private string _nombre;
        private string _apellido;
        private int _dni;
        private DateTime _fechanacimiento;
        private string _direccion;
        private int _telefono;
        #endregion

        #region Propiedades Publicas
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public int DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechanacimiento; }
            set { _fechanacimiento = value; }
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
        #endregion

        #region Metodos
        #endregion

    }
}
