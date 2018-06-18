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
        public frmEmpleado(Form frmPadre, string pAccion, Empleado pEmp = null) 
        {
            InitializeComponent();
            Padre = frmPadre;
            Accion = pAccion;
        
            Empl = pEmp; 
        }

        private Form _padre;
        private string _accion;
        private Empleado _Empl;

        public enum EstadoUsuario
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
            Usuario nUsers = new Usuario();
            TipoUsuario nTipoUser = new TipoUsuario();

            nEmpleado.IdEmpleado = nEmpleado.ObtenerId();
            nEmpleado.Legajo = txtLegajo.Text;
            nEmpleado.Nombre = txtNombre.Text;
            nEmpleado.Apellido = txtApellido.Text;
            nEmpleado.DNI = int.Parse(txtDNI.Text);
            nEmpleado.FechaNacimiento = dtpFechaNac.Value; 
            nEmpleado.Direccion = txtDireccion.Text;
            nEmpleado.Telefono = int.Parse(txtTelefono.Text);
            nEmpleado.Estado = cboEstado.SelectedIndex;
            nEmpleado.Sueldo = decimal.Parse(txtSueldo.Text);

            nUsers.IdUsuario = nUsers.ObtenerId();
            nUsers.User = txtUsuario.Text;
            nUsers.Password = txtPass.Text;
            nTipoUser.IdTipoUsuario = cboTipoUsuario.SelectedIndex;
            nUsers.TipoUsuario = nTipoUser; 
            nEmpleado.Usuario = nUsers;


            try
            {
                if (Accion.Equals("A"))
                {
                     resUsuario = nEmpleado.Usuario.Agregar();
                     resEmpleado = nEmpleado.Agregar();
                     
                }
                else if (Accion.Equals("M"))
                {
                   
                }


                if (resEmpleado.Equals(1) && resUsuario.Equals(1))
                {
                    MessageBox.Show("Empleado agregado correctamente");
                    Limpiar();
               
                }
                else
                {
                    MessageBox.Show("Error al agregar Empleado");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }

 
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            TipoUsuario objTipoUsuario = new TipoUsuario();
            cboTipoUsuario.DataSource = objTipoUsuario.ListarTipoUsuario();
            cboTipoUsuario.DisplayMember = "Descripcion";

            cboEstado.DataSource = Enum.GetValues(typeof(EstadoUsuario));
        }

        private void Limpiar()
        {
            txtLegajo.Text = "";
            txtDNI.Text = "";
            cboEstado.SelectedIndex = 0;
            txtNombre.Text = "";
            txtApellido.Text = "";
            dtpFechaNac.Value = DateTime.Now;
            txtUsuario.Text = "";
            txtPass.Text = "";
            txtSueldo.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            cboEstado.SelectedIndex = 0;

            txtLegajo.Focus();
        }

    }
}
