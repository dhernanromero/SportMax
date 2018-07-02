using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SportMaxApp.Formularios.ClienteVista; 
using SportMaxController.Clases;

namespace SportMaxApp.Formularios.VentaVista
{
    public partial class frmVenta : Form
    {
        public frmVenta(Form frmPadre, Empleado pEmp = null)
        {
            InitializeComponent();
            Padre  = frmPadre;

            Empl = pEmp;
            MontoTotal = 0;
        }

        private Form _padre;
        private Empleado _Empl;
        private Cliente _Cliente;
        private decimal _mTotal;


        public Form Padre
        {
            set { _padre = value; }
            get { return _padre; }
        }
        
        public Empleado Empl
        {
            set { _Empl = value; }
            get { return _Empl; }
        }

        public Cliente Client
        {
            set { _Cliente = value;}
            get { return _Cliente; }
        }
        private decimal MontoTotal
        {
            set { _mTotal = value; }
            get { return _mTotal; }
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            txtVendedor.Text = Empl.NombreCompleto;
            txtVendedor.Enabled = false;

           
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto nProd = new Producto();
            
            nProd = nProd.BuscarxCod(int.Parse(txtCodigoProducto.Text));
            string nCantidad = "1";
            if (nProd.Codigo > 0)
            {
                gridDetalleVenta.Rows.Add(nProd.Codigo.ToString(), nProd.Descripcion, nProd.Talle, nProd.Precio.ToString(),nCantidad);

                decimal valor = decimal.Parse(nCantidad);
                MontoTotal = MontoTotal + nProd.Precio * valor;

                lblMontoTotal.Text  = MontoTotal.ToString();
                lblMontoTotal.Visible = true; 

            }
            else
            {
                MessageBox.Show("El Producto no se encuentra registrado en la base de datos");
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Padre.Show(); 
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarCliente(); 

        }

        private void BuscarCliente()
        {

            int dDni = int.Parse(txtDniCliente.Text);
            Client = Client.BuscarxDNI(dDni);

            if (Client.IdCliente > 0)
            {

                txtDniCliente.Enabled = false;
            }
            else
            {
                MessageBox.Show("Cliente inexistente");
                frmCliente frmClie = new frmCliente(null);

                frmClie.ShowDialog();

                BuscarCliente(); 
            }
        }

        private void gridDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
