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
            TraerDatos();


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            Padre.Show(); 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            TraerDatos();
        }
        public void TraerDatos()
        {
            Empleado nEmpl = new Empleado();
            if (txtBuscar.Text != "" &&  rbtDni.Checked)
            {
                gridEmpleados.DataSource = nEmpl.BuscarxDNI(int.Parse(txtBuscar.Text));
            }
            else if (txtBuscar.Text != "" && rbtLegajo.Checked)
            {
                gridEmpleados.DataSource = nEmpl.BuscarxLegajo(txtBuscar.Text);
            }
            else if (txtBuscar.Text.Equals(""))
            {
                gridEmpleados.DataSource = nEmpl.Listar();
            }
        }

        private void rbtLegajo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtLegajo.Checked)
            {
                rbtDni.Checked = false; 
            }
        }

        private void rbtDni_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtDni.Checked)
            {
                rbtLegajo.Checked = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Empleado Emp = new Empleado();
            var row = gridEmpleados.CurrentRow;
            Emp.IdEmpleado = int.Parse(row.Cells["IdEmpleado"].Value.ToString());
            Emp.Usuario = (Usuario)row.Cells[1].Value;
            Emp.Legajo = row.Cells["Legajo"].Value.ToString();
            Emp.Nombre = row.Cells["Nombre"].Value.ToString();
            Emp.Apellido = row.Cells["Apellido"].Value.ToString();
            Emp.DNI = int.Parse(row.Cells["DNI"].Value.ToString());
            Emp.FechaNacimiento = DateTime.Parse(row.Cells["FechaNacimiento"].Value.ToString());
            Emp.Direccion = row.Cells["Direccion"].Value.ToString();
            Emp.Telefono = int.Parse(row.Cells["Telefono"].Value.ToString());
            Emp.Estado = int.Parse(row.Cells["Estado"].Value.ToString());
            Emp.Sueldo = decimal.Parse(row.Cells["Sueldo"].Value.ToString());

            frmEmpleado frmEmp = new frmEmpleado(this, "M", Emp);
 
            frmEmp.ShowDialog();
            TraerDatos();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Empleado Empl = new Empleado();
            int resultado = 0;
            Empl.IdEmpleado  = int.Parse(gridEmpleados.CurrentRow.Cells["IdEmpleado"].Value.ToString());
            Empl.Usuario = (Usuario)gridEmpleados.CurrentRow.Cells[1].Value;
            Empl.Legajo  = gridEmpleados.CurrentRow.Cells["Legajo"].Value.ToString();

            try
            {
                resultado = Empl.Eliminar();
            }
            catch (Exception)
            {
                
                MessageBox.Show("Ocurrio un error al realizar la la operacion ");
            }
            

        }

    }
}
