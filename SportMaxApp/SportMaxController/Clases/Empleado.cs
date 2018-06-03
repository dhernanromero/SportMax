using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportMaxController.Clases
{
    public class Empleado
    {
        #region Propiedades Privadas 
        private int _IdEmpleado;
        private Usuario _usuario;
        private string _legajo;
        private string _nombre;
        private string _apellido;
        private int _dni;
        private string _direccion;
        private int _telefono;
        private bool _estado;
        private float _sueldo;
        #endregion  

        #region Propiedades Publicas

        public int IdEmpleado
        {
            get { return _IdEmpleado; }
            set { _IdEmpleado = value; }
        }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }

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

        public int  DNI
        {
            get { return _dni; }
            set { _dni = value; }
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
            set {_estado = value;}
        }

        public float Suieldo
        {
            get { return _sueldo; }
            set { _sueldo = value; }
        }

        #endregion  

        #region Metodos


        #endregion

    }
}
