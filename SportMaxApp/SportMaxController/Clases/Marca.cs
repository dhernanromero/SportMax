using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SportMaxModel;

namespace SportMaxController.Clases
{
    public class Marca
    {
        #region Variables Privadas

        private int _idMarca;
        private string _descripcion;

        #endregion

        #region Variables Publicas

        public int IdMarca
        {
            get { return _idMarca; }
            set { _idMarca = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        #endregion

        #region Metodos
        //test
        public void AgregarMarca()
        {
            DALMarca dalMarca = new DALMarca();

            try
            {
                dalMarca.AgregarMarca(this.IdMarca, this.Descripcion);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Marca> Listar()
        {
            DALMarca dalTProducto = new DALMarca();
            DataTable tabla = dalTProducto.Listar();
            List<Marca> lista = new List<Marca>();

            Marca pivot;

            foreach (DataRow fila in tabla.Rows)
            {
                pivot = new Marca();

                pivot.IdMarca  = int.Parse(fila["idTipoProducto"].ToString());
                pivot.Descripcion = fila["Descripcion"].ToString();

                lista.Add(pivot);
            }

            return lista;

        }

        #endregion
    }
}
