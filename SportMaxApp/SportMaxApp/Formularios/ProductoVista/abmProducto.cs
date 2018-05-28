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

namespace SportMaxApp.Formularios.ProductoVista
{
    public partial class abmProducto : Form
    {
        public abmProducto(Form frmPadre)
        {
            InitializeComponent(); 
            Padre = frmPadre;
        }

        private Form _padre;

        public Form Padre
        {
            set { _padre = value; }
            get { return _padre; }

        }

        private void abmProducto_Load(object sender, EventArgs e)
        {
            Producto nProd = new Producto();
            gridProductos.DataSource =  nProd.Listar();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            TraerDatos();
                       
        }

        private void rbtDescrip_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDescrip.Checked)
            {
                rbtCodigo.Checked = false;
            }
        }

        private void rbtCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtCodigo.Checked)
            {
                rbtDescrip.Checked = false; 
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmProducto frmProd = new frmProducto(this, "A",0);
            //this.Hide();

            frmProd.ShowDialog();
            TraerDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idProd = int.Parse(gridProductos.CurrentCell.Value.ToString());  
 
            frmProducto frmProd = new frmProducto(this, "M", idProd);
            //this.Hide();

            frmProd.ShowDialog();
            TraerDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Padre.Show(); 
        }

        public void TraerDatos()
        {
            Producto nProd = new Producto();
            if (txtBuscar.Text != "" && rbtCodigo.Checked)
            {
                gridProductos.DataSource = nProd.BuscarxCodigo(int.Parse(txtBuscar.Text));
            }
            else if (txtBuscar.Text != "" && rbtDescrip.Checked)
            {
                gridProductos.DataSource = nProd.BuscarxDescripcion(txtBuscar.Text);
            }
            else if (txtBuscar.Text.Equals(""))
            {
                gridProductos.DataSource = nProd.Listar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            Producto Prod = new Producto();
            int resultado = 0;
            int idProd = int.Parse(gridProductos.CurrentCell.Value.ToString());

            resultado = Prod.Eliminar(idProd);
            if(resultado.Equals(1))
            {
   
                MessageBox.Show("Producto Eliminado correctamente");
                TraerDatos();
            }
           
        }
  

    }
}
