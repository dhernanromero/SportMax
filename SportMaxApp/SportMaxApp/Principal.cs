using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportMaxApp
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        public frmPrincipal(string tipoUsuario)
        {
            InitializeComponent();

            switch (tipoUsuario)
            {
                case "Vendedor":
                    {
                        btnVentas.Visible = true;
                        break;
                    }

                case "Administrador de Stock":
                    {
                        btnProducto.Visible = true;
                        break;
                    }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            //frmProducto abmProd = new frmProducto();
            abmProducto abmProd = new abmProducto(this);
            this.Hide();
            //abmProd.ShowDialog();
            abmProd.Show();
        }
    }
}
