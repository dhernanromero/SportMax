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
            Usuario Usuario = new Usuario();
            Usuario nUsuario = new Usuario();
            nUsuario.User = txtUsuario.Text;
            nUsuario.Password  = txtContraseña.Text;

          
           
            
            //switch (pass)
            //{
            //    case "ve111": tipoUsuario = "Vendedor"; break;
            //    case "pro222": tipoUsuario = "Administrador de Stock"; break;
            //    case "admin": tipoUsuario = "Administrador"; break;
            //    default: tipoUsuario = "Usuario Inexistente"; break;
            //}
           try
           {
               if (nUsuario.User.Equals("Admin") || nUsuario.User.Equals("admin") && nUsuario.Password.Equals("Admin") || nUsuario.Password.Equals("admin"))
               {
                   frmPrincipal Principal = new frmPrincipal(this, null,"ADMIN");

                   this.Hide();
                   this.Limpiar();
                   Principal.Show();

                   //this.Show(); 

               }
               else if(nUsuario.TipoUsuario.IdTipoUsuario > 0)
               {
                    frmPrincipal Principal = new frmPrincipal(this, nUsuario,null);

                   this.Hide();
                   this.Limpiar();
                   Principal.Show();

                   //this.Show(); 
               }
               else
               {
                   MessageBox.Show("Usuario inexistente");

               }
           }
           catch(NullReferenceException )
           {
               MessageBox.Show("Usuario inexistente");
           }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Limpiar()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";
        }
    }
}
