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
        public frmCliente(Form frmPadre, Cliente pClie = null, int pDniCliente = 0)
        {
            InitializeComponent();
            Padre = frmPadre;
            Client = pClie;
            DNICliente = pDniCliente; 
        }
        
        
        private Form _padre;
        private Cliente _cliente;
        private int _dniCliente;

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

        public int DNICliente
        {
            set { _dniCliente = value; }
            get { return _dniCliente; }
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            if (DNICliente > 0)
            {
                txtDNI.Text = DNICliente.ToString();
                txtDNI.Enabled = true;

            }
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

            Client = new Cliente();
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
                if (resCliente > 0)
                {
                    MessageBox.Show("Cliente insertado correctamente");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al Insertar cliente"); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }
    }
}
