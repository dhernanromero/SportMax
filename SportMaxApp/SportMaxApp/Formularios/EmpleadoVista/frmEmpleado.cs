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
        private bool _modPass;

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

        public bool ModPass
        {
            set { _modPass = value; }
            get { return _modPass; }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int resEmpleado = 0;
            int resUsuario = 0;
            Empleado nEmpleado = new Empleado();
            Usuario nUsers = new Usuario();
            TipoUsuario nTipoUser = new TipoUsuario();

            nEmpleado.IdEmpleado = (Accion.Equals("A") ? nEmpleado.ObtenerId() : Empl.IdEmpleado); 
            nEmpleado.Legajo = txtLegajo.Text;
            nEmpleado.Nombre = txtNombre.Text;
            nEmpleado.Apellido = txtApellido.Text;
            nEmpleado.DNI = int.Parse(txtDNI.Text);
            nEmpleado.FechaNacimiento = dtpFechaNac.Value; 
            nEmpleado.Direccion = txtDireccion.Text;
            nEmpleado.Telefono = int.Parse(txtTelefono.Text);
            nEmpleado.Estado = cboEstado.SelectedIndex;
            nEmpleado.Sueldo = decimal.Parse(txtSueldo.Text);

            nUsers.IdUsuario = (Accion.Equals("A") ? nUsers.ObtenerId() : Empl.Usuario.IdUsuario); 
            nUsers.User = txtUsuario.Text;
            nUsers.Password = (Accion.Equals("A") ? txtPass.Text: Empl.Usuario.Password);
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
                    resUsuario = nEmpleado.Usuario.Modificar();
                    resEmpleado = nEmpleado.Modificar();
                }
                else if(Accion.Equals("P"))
                {
                    Salir();
                }

                if (resEmpleado.Equals(1) && resUsuario.Equals(1))
                {
                    MessageBox.Show("Accion finalizado correctamente");
                    Limpiar();
               
                }
                else
                {
                    MessageBox.Show("Error al realizar la accion");
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

 
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            TipoUsuario objTipoUsuario = new TipoUsuario();
            cboTipoUsuario.DataSource = objTipoUsuario.ListarTipoUsuario();
            cboTipoUsuario.DisplayMember = "Descripcion";

            btnModContraseña.Visible = false;
            

            cboEstado.DataSource = Enum.GetValues(typeof(EstadoUsuario));
            switch (Accion)
            {
                case "A": btnAceptar.Location = new Point(185, 200); break;
                case "M": ModEmpleado(); btnModContraseña.Visible = true; break;
                case "P": CargarPerfil();  btnModContraseña.Visible = true; break;

            }
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

        private void ModEmpleado()
        {
            txtLegajo.Text = Empl.Legajo;
            txtDNI.Text = Empl.DNI.ToString();
            cboTipoUsuario.SelectedIndex = Empl.Usuario.TipoUsuario.IdTipoUsuario;
            txtNombre.Text = Empl.Nombre;
            txtApellido.Text = Empl.Apellido;
            dtpFechaNac.Text = Empl.FechaNacimiento.ToString();
            txtUsuario.Text = Empl.Usuario.User;
            txtPass.Text = Empl.Usuario.Password;
            txtSueldo.Text = Empl.Sueldo.ToString();
            txtDireccion.Text  = Empl.Direccion;
            txtTelefono.Text = Empl.Telefono.ToString();
            cboEstado.SelectedIndex = Empl.Estado;

            txtLegajo.Enabled = false;
            txtUsuario.Enabled = false;
            txtPass.Enabled = false;
            ModPass = false; 
        }

        private void CargarPerfil()
        {
            txtLegajo.Text = Empl.Legajo;
            txtDNI.Text = Empl.DNI.ToString();
            cboTipoUsuario.SelectedIndex = Empl.Usuario.TipoUsuario.IdTipoUsuario;
            txtNombre.Text = Empl.Nombre;
            txtApellido.Text = Empl.Apellido;
            dtpFechaNac.Text = Empl.FechaNacimiento.ToString();
            txtUsuario.Text = Empl.Usuario.User;
            txtPass.Text = Empl.Usuario.Password;
            txtSueldo.Text = Empl.Sueldo.ToString();
            txtDireccion.Text = Empl.Direccion;
            txtTelefono.Text = Empl.Telefono.ToString();
            cboEstado.SelectedIndex = Empl.Estado;

            txtLegajo.Enabled = false;
            txtUsuario.Enabled = false;
            txtDNI.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtSueldo.Enabled = false;
            txtSueldo.Visible = false;
            cboTipoUsuario.Enabled = false;
            cboEstado.Enabled = false;
            cboEstado.Visible = false;
            lblSueldo.Visible = false;
            txtPass.Enabled = false;
            dtpFechaNac.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;

            ModPass = false;
            btnModContraseña.Visible = false;
            this.Text = "Mi Perfil";
        }

        private void Salir()
        {
            this.Close();
            Padre.Show();
        }

        private void btnModContraseña_Click(object sender, EventArgs e)
        {
            ModPass = true;
            btnModContraseña.Enabled = false;
            txtPass.Enabled = true;
        }
    }
}
