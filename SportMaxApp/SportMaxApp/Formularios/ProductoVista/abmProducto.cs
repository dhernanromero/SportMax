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
            frmProducto frmProd = new frmProducto(this, "A",null);
            //this.Hide();

            frmProd.ShowDialog();
            TraerDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //int idProd = int.Parse(gridProductos.CurrentCell.Value.ToString());
            Producto Prod = new Producto();
            var row = gridProductos.CurrentRow;

            Prod.Codigo = int.Parse(row.Cells[0].Value.ToString());
            Prod.Descripcion = row.Cells[1].Value.ToString();
            Prod.TipoProducto = (TipoProducto)row.Cells[2].Value;
            Prod.Precio = float.Parse(row.Cells[3].Value.ToString());
            Prod.Cantidad = int.Parse(row.Cells[4].Value.ToString());
            Prod.Marca = (Marca)row.Cells[5].Value;
            Prod.Estado = int.Parse(row.Cells[6].Value.ToString());
            Prod.Talle = row.Cells[7].Value.ToString();

            frmProducto frmProd = new frmProducto(this, "M", Prod);
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
