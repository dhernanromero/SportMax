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


        public enum FormaPago
        {
            Efectivo = 0,
            Tarjeta = 1

        }

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

            cboFormaPago.DataSource = Enum.GetValues(typeof(FormaPago));
            txtTarjeta.Enabled = false;

            btnConfirmar.Enabled = false;
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto nProd = new Producto();
            if (txtCodigoProducto.Text.Equals(""))
            {
                MessageBox.Show("El campo no puede estar vacio"); 
            }
            else
            {
                nProd = nProd.BuscarxCod(int.Parse(txtCodigoProducto.Text));
                string nCantidad = "1";
                if (nProd.Codigo > 0)
                {
                    gridDetalleVenta.Rows.Add(nProd.Codigo.ToString(), nProd.Descripcion, nProd.Talle, nProd.Precio,nCantidad);

                    decimal valor = decimal.Parse(nCantidad);
                    MontoTotal = MontoTotal + nProd.Precio * valor;

                    lblMontoTotal.Text  = MontoTotal.ToString();
                    lblMontoTotal.Visible = true;
                    txtCodigoProducto.Text = ""; 

                }
                else
                {
                    MessageBox.Show("El Producto no se encuentra registrado en la base de datos");
                }
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (txtDniCliente.Equals(string.Empty))
            {
                MessageBox.Show("No se ha ingresado número de docuemto del cliente");
            }
            else
            {
                BuscarCliente();
                btnConfirmar.Enabled = true;  
            }

        }

        private void BuscarCliente()
        {

            int dDni = int.Parse(txtDniCliente.Text);
            Client = new Cliente();
            Client = Client.BuscarxDNI(dDni);

            if (Client.IdCliente > 0)
            {
               
                txtDniCliente.Enabled = false;
                if (cboFormaPago.SelectedValue.Equals(2))
                {
                    txtTarjeta.Text = Client.Tarjeta.ToString();
                    txtTarjeta.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Cliente inexistente");
                frmCliente frmClie = new frmCliente(this,null,int.Parse(txtDniCliente.Text));

                frmClie.ShowDialog();

                BuscarCliente(); 
            }
        }

        private void gridDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Venta nVenta = new Venta();
            DetalleVenta nDetVenta = new DetalleVenta();  
            Producto nProducto = new Producto();
            
            nVenta.IdVenta = nVenta.ObtenerId();
            nVenta.Empleado = Empl;
            nVenta.Cliente = Client;
            nVenta.IdFormaPago = cboFormaPago.SelectedIndex;
            nVenta.Fecha = DateTime.Now;
            nVenta.MontoTotal = MontoTotal;

            try
            {
                nVenta.Agregar();
            }
            catch (Exception)
            {

                MessageBox.Show("Error durante el proceso"); 
            }

            foreach(DataGridViewRow fila in gridDetalleVenta.Rows)
            {
                if (fila.Cells["CodProducto"].Value != null)
                {
                    nDetVenta.IdDetalle = nDetVenta.ObtenerId();
                    nDetVenta.IdProducto = int.Parse(fila.Cells["CodProducto"].Value.ToString());
                    nDetVenta.Cantidad = int.Parse(fila.Cells["Cantidad"].Value.ToString());
                    nProducto.Codigo = nDetVenta.IdProducto;
                    nProducto.ActualizarCatidad(nDetVenta.Cantidad); 

                    try
                    {

                        nDetVenta.RegistrarDetalleVenta(nVenta.IdVenta);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Error durante el proceso"); 
                    }
                }
            }
            MessageBox.Show("Venta realizada correctamente");
            Salir();

        }

        private void Salir()
        {
            this.Close();
            Padre.Show(); 
        }
    }
}
