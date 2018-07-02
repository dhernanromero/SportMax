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

namespace SportMaxApp.Formularios.ClienteVista
{
    public partial class frmCliente : Form
    {
        public frmCliente(Form frmPadre, Cliente pClie = null)
        {
            InitializeComponent();
            Padre = frmPadre;
            Client = pClie;
        }
        
        
        private Form _padre;
        private Cliente _cliente;

        public Form Padre
        {
            set { _padre = value; }
            get { return _padre; }

        }

        public Cliente Client
        {
            set { _cliente = value; }
            get { return _cliente; }
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AgregarCliente();
        }

        private void AgregarCliente()
        {
            int resCliente = 0;


            Client.IdCliente = Client.ObtenerId();
            Client.Nombre = txtNombre.Text;
            Client.Apellido = txtApellido.Text;
            Client.DNI = int.Parse(txtDNI.Text);
            Client.FechaNacimiento = dtpFechaNac.Value;
            Client.Direccion = txtDireccion.Text;
            Client.Telefono = int.Parse(txtTelefono.Text); 
            Client.Tarjeta = int.Parse(txtTarjeta.Text);

            try
            {
                resCliente = Client.Agregar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }
    }
}
