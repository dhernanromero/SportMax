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
using SportMaxApp.Formularios.Venta;
using SportMaxApp.Formularios.EmpleadoVista;
using SportMaxController.Clases;

namespace SportMaxApp
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal(Form frmPadre, Usuario user)
        {
            InitializeComponent();
            Padre = frmPadre;
            Usuario = user;

        }

        private Form _padre;
        private Usuario _usuario;

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
            switch (Usuario.TipoUsuario.CodUsuario)
            {
                case "ADMIN": btnVentas.Visible = true; btnProducto.Visible = true; btnEmpleado.Visible = true; break;
                case "GEREN": btnProducto.Visible = true; break;
                case "VENDE": btnVentas.Visible = true; break;
                case "STOCK": btnProducto.Visible = true; break;
                case "SISTE": btnProducto.Visible = true; btnVentas.Visible = true; break;
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
    }
}
