using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SportMaxController.Clases;

namespace SportMaxApp.Formularios.EmpleadoVista
{
    public partial class frmEmpleado : Form
    {
        public frmEmpleado(Form frmPadre, string pAccion, Empleado pEmp)
        {
            InitializeComponent();
            Padre = frmPadre;
            Accion = pAccion;
            //IdProd = pIdProducto;
            Empl = pEmp; 
        }
        private Form _padre;
        private string _accion;
        //private int _Prod;
        private Empleado _Empl;

        public enum EstadoProducto
        {
            Inactivo = 0,
            Activo = 1

        }

        public Form Padre
        {
            set { _padre = value; }
            get { return _padre; }

        }
        public string Accion
        {
            set { _accion = value; }
            get { return _accion; }
        }
        //public int IdProd
        //{
        //    set { _idProd = value; }
        //    get { return _idProd; }
        //}
        public Empleado Empl
        {
            set { _Empl = value; }
            get { return _Empl; }
        }



        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Padre.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int resEmpleado = 0;
            int resUsuario = 0;
            Empleado nEmpleado = new Empleado();
            nEmpleado.IdEmpleado = 1;
            nEmpleado.Legajo = txtLegajo.Text;
            nEmpleado.Nombre = txtNombre.Text;
            nEmpleado.Apellido = txtApellido.Text;
            nEmpleado.DNI = int.Parse(txtDNI.Text);
            nEmpleado.Direccion = txtDireccion.Text;
            nEmpleado.Telefono = int.Parse(txtTelefono.Text);
            nEmpleado.Estado = cboEstado.SelectedIndex;
            nEmpleado.Sueldo = decimal.Parse(txtSueldo.Text);
            nEmpleado.Usuario.User = txtUsuario.Text;
            nEmpleado.Usuario.Password = txtPass.Text;
            nEmpleado.Usuario.TipoUsuario.IdTipoUsuario = cboTipoUsuario.SelectedIndex;


            try
            {
                if (Accion.Equals("A"))
                {
                     resEmpleado = nEmpleado.Agregar();
                     resUsuario = nEmpleado.Usuario.Agregar();
                }
                else if (Accion.Equals("M"))
                {
                   
                }


                if (resEmpleado.Equals(1) && resUsuario.Equals(1))
                {
                    MessageBox.Show("Empleado agregado correctamente");
                    //Limpiar();
               
                }
                else
                {
                    MessageBox.Show("Error al agregar Empleado");
                }
              
            }
            catch (Exception)
            {
                
                throw;
            }

 
        }

    }
}
