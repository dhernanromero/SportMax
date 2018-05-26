using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SportMaxController;

namespace SportMaxApp
{
    public partial class frmProducto : Form
    {
        public frmProducto(Form frmPadre, string Accion)
        {
            InitializeComponent();
            Padre = frmPadre;
        }

        private Form _padre;
        private string _accion; 

        public Form Padre
        {
            set { _padre = value; }
            get { return _padre; }
        
        }
        public string Accion
        {
            set { _accion = value; }
            get { return _accion; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Producto nProducto = new Producto();
            nProducto.Codigo = int.Parse(txtCodProducto.Text);
            nProducto.Descripcion = txtDescripcion.Text;
            nProducto.TipoProducto = (TipoProducto)cboTipo.SelectedItem;
            nProducto.Precio = float.Parse(txtPrecio.Text);
            nProducto.Cantidad = int.Parse(txtCantidad.Text);

            nProducto.Agregar();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            TipoProducto objTipoProducto = new TipoProducto();

            cboTipo.DataSource = objTipoProducto.Listar();
            cboTipo.DisplayMember= "Descripcion";

            switch(_accion)
            {
                case "A":
                    lblCodProducto.Visible = false;
                    txtCodProducto.Visible = false;
                    break;
                case "M":
                    lblCodProducto.Visible = true;
                    txtCodProducto.Visible = true;
                    txtCodProducto.Enabled = false;
                    break;
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Padre.Show();

        }



    }
}
