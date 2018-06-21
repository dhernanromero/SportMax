using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportMaxModel;
using System.Data;

namespace SportMaxController.Clases
{
    public class Empleado : Persona
    {

        #region Propiedades Privadas 
        private int _IdEmpleado;
        private Usuario _usuario;
        private string _legajo;
        private int _estado;
        private decimal _sueldo;
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

        public int Estado
        {
            get { return _estado; }
            set {_estado = value;}
        }

        public decimal Sueldo
        {
            get { return _sueldo; }
            set { _sueldo = value; }
        }

        #endregion  

        #region Metodos

        public int Agregar()
        {
            DALEmpleado dalEmpleado = new DALEmpleado();

            try
            {
                return dalEmpleado.AgregarEmpleado(this.IdEmpleado, this.Usuario.IdUsuario, this.Legajo, this.Nombre, this.Apellido, this.DNI,this.FechaNacimiento, this.Direccion, this.Telefono, this.Estado, this.Sueldo);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public List<Empleado> Listar()
        {
            DALEmpleado dalEmpleado = new DALEmpleado();
            DataTable tabla = dalEmpleado.Listar();
            List<Empleado> lista = new List<Empleado>();
            Empleado nEmpleado;
            Usuario nUsuario;
            TipoUsuario nTipoUsuario; 

            foreach (DataRow fila in tabla.Rows)
            {
                nEmpleado = new Empleado();
                nUsuario = new Usuario();
                nTipoUsuario = new TipoUsuario();

                nEmpleado.IdEmpleado = int.Parse(fila["IdEmpleado"].ToString());
                nUsuario.IdUsuario = int.Parse(fila["IdUsuario"].ToString());
                nUsuario.User = fila["Usuario"].ToString();
                nEmpleado.Legajo = fila["Legajo"].ToString();
                nEmpleado.Nombre = fila["Nombre"].ToString();
                nEmpleado.Apellido = fila["Apellido"].ToString();
                nEmpleado.DNI = int.Parse(fila["DNI"].ToString());
                nEmpleado.FechaNacimiento = DateTime.Parse(fila["FechaNacimiento"].ToString());
                nEmpleado.Direccion = fila["Direccion"].ToString();
                nEmpleado.Telefono = int.Parse(fila["Telefono"].ToString());
                nEmpleado.Estado = int.Parse(fila["Estado"].ToString());
                nEmpleado.Sueldo = decimal.Parse(fila["Sueldo"].ToString());
                nTipoUsuario.IdTipoUsuario = int.Parse(fila["IdTipoUsuario"].ToString());
                nTipoUsuario.Descripcion  = fila["Descripcion"].ToString();
                nUsuario.TipoUsuario = nTipoUsuario;
                nEmpleado.Usuario = nUsuario;
                
                lista.Add(nEmpleado);

            }

            return lista;
                        
        }

        public int ObtenerId()
        {
            DALEmpleado empl = new DALEmpleado();
            try
            {
                return empl.ObtenerId();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Empleado> BuscarxLegajo(string pLegajo)
        {
            DALEmpleado dalEmpleado = new DALEmpleado();
            DataTable tabla = dalEmpleado.BuscarxLegajo(pLegajo);
            List<Empleado> lista = new List<Empleado>();
            Empleado nEmpleado;
            Usuario nUsuario;
            TipoUsuario nTipoUsuario;

            foreach (DataRow fila in tabla.Rows)
            {

                nEmpleado = new Empleado();
                nUsuario = new Usuario();
                nTipoUsuario = new TipoUsuario();

                nEmpleado.IdEmpleado = int.Parse(fila["IdEmpleado"].ToString());
                nUsuario.IdUsuario = int.Parse(fila["IdUsuario"].ToString());
                nUsuario.User = fila["Usuario"].ToString();
                nEmpleado.Legajo = fila["Legajo"].ToString();
                nEmpleado.Nombre = fila["Nombre"].ToString();
                nEmpleado.Apellido = fila["Apellido"].ToString();
                nEmpleado.DNI = int.Parse(fila["DNI"].ToString());
                nEmpleado.FechaNacimiento = DateTime.Parse(fila["FechaNacimiento"].ToString());
                nEmpleado.Direccion = fila["Direccion"].ToString();
                nEmpleado.Telefono = int.Parse(fila["Telefono"].ToString());
                nEmpleado.Estado = int.Parse(fila["Estado"].ToString());
                nEmpleado.Sueldo = decimal.Parse(fila["Sueldo"].ToString());
                nTipoUsuario.IdTipoUsuario = int.Parse(fila["IdTipoUsuario"].ToString());
                nTipoUsuario.Descripcion = fila["Descripcion"].ToString();
                nUsuario.TipoUsuario = nTipoUsuario;
                nEmpleado.Usuario = nUsuario;

                lista.Add(nEmpleado);
                
            }

            return lista;
        }

        public List<Empleado> BuscarxDNI(int pDNI)
        {
            DALEmpleado dalEmpleado = new DALEmpleado();
            DataTable tabla = dalEmpleado.BuscarxDNI(pDNI);
            List<Empleado> lista = new List<Empleado>();
            Empleado nEmpleado;
            Usuario nUsuario;
            TipoUsuario nTipoUsuario;

            foreach (DataRow fila in tabla.Rows)
            {

                nEmpleado = new Empleado();
                nUsuario = new Usuario();
                nTipoUsuario = new TipoUsuario();

                nEmpleado.IdEmpleado = int.Parse(fila["IdEmpleado"].ToString());
                nUsuario.IdUsuario = int.Parse(fila["IdUsuario"].ToString());
                nUsuario.User = fila["Usuario"].ToString();
                nEmpleado.Legajo = fila["Legajo"].ToString();
                nEmpleado.Nombre = fila["Nombre"].ToString();
                nEmpleado.Apellido = fila["Apellido"].ToString();
                nEmpleado.DNI = int.Parse(fila["DNI"].ToString());
                nEmpleado.FechaNacimiento = DateTime.Parse(fila["FechaNacimiento"].ToString());
                nEmpleado.Direccion = fila["Direccion"].ToString();
                nEmpleado.Telefono = int.Parse(fila["Telefono"].ToString());
                nEmpleado.Estado = int.Parse(fila["Estado"].ToString());
                nEmpleado.Sueldo = decimal.Parse(fila["Sueldo"].ToString());
                nTipoUsuario.IdTipoUsuario = int.Parse(fila["IdTipoUsuario"].ToString());
                nTipoUsuario.Descripcion = fila["Descripcion"].ToString();
                nUsuario.TipoUsuario = nTipoUsuario;
                nEmpleado.Usuario = nUsuario;

                lista.Add(nEmpleado);

            }

            return lista;
        }

        //public int Modificar()
        //{
        //    DALEmpleado dalEmpl = new DALEmpleado();
        //    try
        //    {
        //        return dalEmpl.ModificarEmpleado(this.IdEmpleado, this.Usuario.IdUsuario, this.Legajo, this.Nombre, this.Apellido, this.DNI,this.FechaNacimiento, this.Direccion, this.Telefono, this.Estado, this.Sueldo);
        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        //}

        //public int Eliminar()
        //{
        //    DALEmpleado dalEmpl = new DALEmpleado();
        //    try
        //    {
        //        return dalEmpl.EliminarEmpleado(this.IdEmpleado, this.Usuario.IdUsuario, this.Legajo);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public int Modificar()
        {
            DALEmpleado dalEmpl = new DALEmpleado();
            try
            {
                return dalEmpl.ModificarEmpleado(this.IdEmpleado, this.Usuario.IdUsuario, this.Legajo, this.Nombre, this.Apellido, this.DNI, this.FechaNacimiento, this.Direccion, this.Telefono, this.Estado, this.Sueldo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Eliminar()
        {
            DALEmpleado dalEmpl = new DALEmpleado();
            try
            {
                return dalEmpl.EliminarEmpleado(this.IdEmpleado, this.Usuario.IdUsuario, this.Legajo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
