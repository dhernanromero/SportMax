using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportMaxModel;
using System.Data;
using System.Data.SqlClient; 

namespace SportMaxController.Clases
{
    public class TipoUsuario
    {
        #region Propiedades Privadas
        private int _idTipoUsuario;
        private string _descripcion;
        private string _codUsuario;

        #endregion  

        #region Propiedades Publicas

        public int IdTipoUsuario
        {
            get { return _idTipoUsuario; }
            set { _idTipoUsuario = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public string CodUsuario
        {
            get { return _codUsuario; }
            set { _codUsuario = value; }
        }

        #endregion

        #region Metodos

        public List<TipoUsuario> ListarTipoUsuario()
        {
            DALTipoUsuario dalTUsuario = new DALTipoUsuario();
            DataTable tabla = dalTUsuario.Listar();
            List<TipoUsuario> lista = new List<TipoUsuario>();

            TipoUsuario pivot = new TipoUsuario();
            pivot.IdTipoUsuario = 0;
            pivot.Descripcion = "";
            pivot.CodUsuario = "";

            lista.Add(pivot);

            foreach (DataRow fila in tabla.Rows)
            {
                pivot = new TipoUsuario();

                pivot.IdTipoUsuario = int.Parse(fila["IdTipoUsuario"].ToString());
                pivot.Descripcion = fila["Descripcion"].ToString();
                pivot.CodUsuario = fila["CodUsuario"].ToString();

                lista.Add(pivot);
            }

            return lista;
        }
        #endregion

    }
}
