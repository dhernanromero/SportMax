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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string pass = txtContraseña.Text;
            string tipoUsuario;

            switch (pass)
            {
                case "ve111": tipoUsuario = "Vendedor"; break;
                case "pro222": tipoUsuario = "Administrador de Stock"; break;
                case "admin": tipoUsuario = "Administrador"; break;
                default: tipoUsuario = "Usuario Inexistente"; break;
            }

            if (tipoUsuario != "Usuario Inexistente")
            {
                frmPrincipal Principal = new frmPrincipal(tipoUsuario);

                this.Hide();
                Principal.ShowDialog();

                //this.Show(); 

            }
            else
            {
                MessageBox.Show("Usuario inexistente");
            
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtContraseña.Text = "";  
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
