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
    public partial class frmProducto : Form
    {
        public frmProducto(Form frmPadre, string pAccion, int pIdProducto)
        {
            InitializeComponent();
            Padre = frmPadre;
            Accion = pAccion;
            IdProd = pIdProducto;
        }

        private Form _padre;
        private string _accion;
        private int _idProd;

        public enum EstadoProducto
        {
           Inactivo = 0,
           Activo = 1
      
        }

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
        public int IdProd
        {
            set { _idProd = value; }
            get { return _idProd; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int respuesta = 0;
            Producto nProducto = new Producto();
            nProducto.Codigo = int.Parse(txtCodProducto.Text);
            nProducto.Descripcion = txtDescripcion.Text;
            nProducto.TipoProducto = (TipoProducto)cboTipo.SelectedItem;
            nProducto.Marca = (Marca)cboMarca.SelectedItem; 
            nProducto.Precio = float.Parse(txtPrecio.Text);
            nProducto.Cantidad = int.Parse(txtCantidad.Text);
            nProducto.Talle = txtTalle.Text;
            nProducto.Estado = (bool)cboEstado.SelectedItem;
            

            if (Accion.Equals("A"))
            {
                respuesta = nProducto.Agregar();
            }
            else if (Accion.Equals("M"))
            {
                respuesta = nProducto.Modificar();
            }
            

            if (respuesta.Equals(1))
            {
                MessageBox.Show("Producto agregado correctamente");
                Limpiar();
               
            }
            else
            {
                MessageBox.Show("Error al Ingresar el Producto");
            }

        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            TipoProducto objTipoProducto = new TipoProducto();
            Marca objMarca = new Marca();

            cboTipo.DataSource = objTipoProducto.ListarProducto();
            cboTipo.DisplayMember= "Descripcion";

            cboMarca.DataSource = objMarca.ListarMarca();
            cboMarca.DisplayMember = "Descripcion";

            cboEstado.DataSource = Enum.GetValues(typeof(EstadoProducto));
            
            switch(Accion)
            {
                case "A":
                    lblCodProducto.Visible = true;
                    txtCodProducto.Visible = true;
                    break;
                case "M":
                    lblCodProducto.Visible = true;
                    txtCodProducto.Visible = true;
                    txtCodProducto.Enabled = false;
                    ModProducto();
                    break;
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Padre.Show();

        }

        public void Limpiar()
        {
            txtCodProducto.Text = "";
            txtDescripcion.Text = "";
            cboTipo.SelectedIndex  = 0;
            cboMarca.SelectedIndex = 0;
            txtPrecio.Text = "";
            txtCantidad.Text= "";
 
        }

        public void ModProducto()
        {
            Producto nProd = new Producto();
            List<Producto> lProducto = new List<Producto>();
            
            lProducto = nProd.BuscarxCodigo(IdProd);

            txtCodProducto.Text = lProducto[0].Codigo.ToString();
            txtDescripcion.Text = lProducto[0].Descripcion;
            cboTipo.SelectedIndex = lProducto[0].TipoProducto.IdTipoProducto;
            cboMarca.SelectedIndex = lProducto[0].Marca.IdMarca;
            txtPrecio.Text = lProducto[0].Precio.ToString();
            txtCantidad.Text = lProducto[0].Cantidad.ToString(); 

        }

    }
}
