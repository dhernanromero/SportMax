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

        public override string ToString()
        {
            return this.Descripcion; 
 
        }

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

        public List<Marca> ListarMarca()
        {
            DALMarca dalMarca = new DALMarca();
            DataTable tabla = dalMarca.Listar();
            List<Marca> lista = new List<Marca>();

            Marca pivot = new Marca();
            pivot.IdMarca = 0;
            pivot.Descripcion = "";

            lista.Add(pivot);

            foreach (DataRow fila in tabla.Rows)
            {
                pivot = new Marca();

                pivot.IdMarca  = int.Parse(fila["idMarca"].ToString());
                pivot.Descripcion = fila["Descripcion"].ToString();

                lista.Add(pivot);
            }

            return lista;

        }

        #endregion
    }
}
