using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SportMaxApp.Formularios.ProductoVista;
using SportMaxApp.Formularios.VentaVista;
using SportMaxApp.Formularios.EmpleadoVista;
using SportMaxController.Clases;

namespace SportMaxApp
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal(Form frmPadre, Usuario user = null, string masterPass = null)
        {
            InitializeComponent();
            Padre = frmPadre;
            Usuario = user;
            Master = masterPass;

        }

        private Form _padre;
        private Usuario _usuario;
        private string _masterPass;

        public Form Padre
        {
            set { _padre = value; }
            get { return _padre; }

        }
        public Usuario Usuario
        {
            set { _usuario = value; }
            get { return _usuario; }
        }

        private string Master
        {
            set { _masterPass = value; }
            get { return _masterPass; }
        }

        //public frmPrincipal()
        //{
        //    InitializeComponent();

        //    switch (Usuario.TipoUsuario.CodUsuario)
        //    {
        //        case "ADMIN": btnVentas.Visible = true; btnProducto.Visible = true; btnEmpleado.Visible = true; break;
        //        case "GEREN": btnProducto.Visible = true; break;
        //        case "VENDE": btnVentas.Visible = true; break;
        //        case "STOCK": btnProducto.Visible = true; break;
        //        case "SISTE": btnProducto.Visible = true; btnVentas.Visible = true; break;
        //    }
        //}

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Padre.Close();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (Master == null)
            {
                switch (Usuario.TipoUsuario.CodUsuario)
                {
                    case "ADMIN": btnVentas.Visible = true; btnProducto.Visible = true; btnEmpleado.Visible = true; btnPerfil.Visible = true; break;
                    case "GEREN": btnProducto.Visible = true; break;
                    case "VENDE": btnVentas.Visible = true; btnPerfil.Visible = true; break;
                    case "STOCK": btnProducto.Visible = true; btnPerfil.Visible = true; break;
                    case "SISTE": btnProducto.Visible = true; btnVentas.Visible = true; btnPerfil.Visible = true; break;
                }
            }
            else
            {
                btnVentas.Visible = true; btnProducto.Visible = true; btnEmpleado.Visible = true; 
            }
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            //frmProducto abmProd = new frmProducto();
            abmProducto abmProd = new abmProducto(this);
            this.Hide();
            abmProd.ShowDialog();
            //abmProd.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            abmEmpleado abmEmpleado = new abmEmpleado(this);
            this.Hide();
            abmEmpleado.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            
            Padre.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Empleado Empl = new Empleado();
            Empleado nEmpleado = new Empleado();

            nEmpleado = Empl.BuscarxIdUsuario(Usuario.IdUsuario);

            frmVenta frmVenta = new frmVenta(this, nEmpleado);
            this.Hide();
            frmVenta.ShowDialog(); 
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            if (Usuario.IdUsuario.Equals(null))
            {
                MessageBox.Show("Usuario ADMI"); 
            
            }
            else
            {
                Empleado Empl = new Empleado();
                Empleado nEmpleado = new Empleado();

                nEmpleado = Empl.BuscarxIdUsuario(Usuario.IdUsuario);
                frmEmpleado frmEmpl = new frmEmpleado(this, "P", nEmpleado);
                this.Hide();
                frmEmpl.ShowDialog();
            }
            

        }
    }
}
