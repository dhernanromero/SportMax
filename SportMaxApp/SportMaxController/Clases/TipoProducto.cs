using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SportMaxModel;

namespace SportMaxController.Clases
{
   public class TipoProducto
   {

       #region Variables Privadas

       private int _idTipoProducto;
       private string _descripcion;

       #endregion 

       #region Variables Publicas

       public int IdTipoProducto
       {
           get { return _idTipoProducto; }
           set { _idTipoProducto = value; }
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
       public void AgregarTipoProducto()
       {
            DALTipoProducto dalTProducto = new DALTipoProducto();
            
           try 
	        {	        
	            dalTProducto.AgregarTipoProducto(this.IdTipoProducto, this.Descripcion);	
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }

       }

       public List<TipoProducto> ListarProducto()
       {
           DALTipoProducto dalTProducto = new DALTipoProducto();
           DataTable tabla = dalTProducto.Listar();
           List<TipoProducto> lista = new List<TipoProducto>();
          
           TipoProducto pivot = new TipoProducto();
           pivot.IdTipoProducto = 0;
           pivot.Descripcion = "";
           lista.Add(pivot);

           foreach (DataRow  fila in tabla.Rows)
           {
               pivot = new TipoProducto();
               
               pivot.IdTipoProducto = int.Parse(fila["idTipoProducto"].ToString());
               pivot.Descripcion = fila["Descripcion"].ToString();

               lista.Add(pivot);
           }

           return lista;
       
       }

       #endregion

   }
}
