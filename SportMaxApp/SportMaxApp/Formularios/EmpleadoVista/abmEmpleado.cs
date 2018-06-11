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

namespace SportMaxApp.Formularios.EmpleadoVista
{
    public partial class abmEmpleado : Form
    {
        public abmEmpleado(Form frmPadre)
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
        private void abmEmpleado_Load(object sender, EventArgs e)
        {
            Empleado nEmpleado = new Empleado();

            gridEmpleados.DataSource = nEmpleado.Listar();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmEmpleado frmEnp = new frmEmpleado(this, "A",null);

            frmEnp.ShowDialog();


        }
    }
}
