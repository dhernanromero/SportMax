using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SportMaxModel;

namespace SportMaxController.Clases
{
   public class Producto
   {
       #region Variables Privadas
       private int _codigo;
       private string _descripcion;
       private TipoProducto _tipo;
       private float _precio;
       private int _cantidad;
       private Marca _marca;

       #endregion

       #region Variables Publicas
       public int Codigo 
       {
           get {return _codigo;}
           set { _codigo = value;}
       } 
       
       public string Descripcion
       {
           get { return _descripcion; }
           set { _descripcion = value; }
       }
       
       public TipoProducto TipoProducto
       {
           get { return _tipo; }
           set { _tipo = value; }
       }

       public float Precio
       {
           get { return _precio; }
           set { _precio = value; }
       }

       public int Cantidad
       {
           get { return _cantidad; }
           set { _cantidad = value; }
       
       }
       
       public Marca Marca
       {
           get { return _marca; }
           set { _marca = value; }
       }
       #endregion

       #region Metodos
       public void Agregar()
       {

           DALProducto dalProducto = new DALProducto();

           try
           {
               dalProducto.AgregarProducto(this.Codigo,this.TipoProducto.IdTipoProducto, this.Descripcion,this.Precio,this.Cantidad);
           }
           catch (Exception)
           {

               throw;
           }

       }
       //test
       public List<Producto> Listar()
       {
           DALProducto dalProducto = new DALProducto();
           DataTable tabla = dalProducto.Listar();
           List<Producto> lista = new List<Producto>();
           Producto pivot;
           TipoProducto pivot2;

           foreach (DataRow fila in tabla.Rows)
           {
               pivot = new Producto();
               pivot2 = new TipoProducto(); 

               pivot.Codigo = int.Parse(fila["idProducto"].ToString());
               pivot2.IdTipoProducto = int.Parse(fila["IdTipoProducto"].ToString());
               pivot2.Descripcion = fila["TipoProdDescrip"].ToString();
               pivot.TipoProducto = pivot2;  
               pivot.Descripcion = fila["Descripcion"].ToString();
               pivot.Precio = float.Parse(fila["Precio"].ToString());
               pivot.Cantidad = int.Parse(fila["Cantidad"].ToString());

               lista.Add(pivot);
           }

           return lista;

       }

       public List<Producto> BuscarxCodigo(int Codigo)
       {
           DALProducto dalProducto = new DALProducto();
           DataTable tabla = dalProducto.BuscarxCodigo(Codigo);
           List<Producto> lista = new List<Producto>();
           Producto pivot;
           TipoProducto pivot2;

           foreach (DataRow fila in tabla.Rows)
           {
               pivot = new Producto();
               pivot2 = new TipoProducto();

               pivot.Codigo = int.Parse(fila["idProducto"].ToString());
               pivot2.IdTipoProducto = int.Parse(fila["IdTipoProducto"].ToString());
               pivot2.Descripcion = fila["TipoProdDescrip"].ToString();
               pivot.TipoProducto = pivot2;  
               pivot.Descripcion = fila["Descripcion"].ToString();
               pivot.Precio = float.Parse(fila["Precio"].ToString());
               pivot.Cantidad = int.Parse(fila["Cantidad"].ToString());

               lista.Add(pivot);
           }

           return lista;
       }

       public List<Producto> BuscarxDescripcion(string Descrip)
       {
           DALProducto dalProducto = new DALProducto();
           DataTable tabla = dalProducto.BuscarxDescripcion(Descrip);
           List<Producto> lista = new List<Producto>();
           Producto pivot;
           TipoProducto pivot2;

           foreach (DataRow fila in tabla.Rows)
           {
               pivot = new Producto();
               pivot2 = new TipoProducto();

               pivot.Codigo = int.Parse(fila["idProducto"].ToString());
               pivot2.IdTipoProducto = int.Parse(fila["IdTipoProducto"].ToString());
               pivot2.Descripcion = fila["TipoProdDescrip"].ToString();
               pivot.TipoProducto = pivot2;  
               pivot.Descripcion = fila["Descripcion"].ToString();
               pivot.Precio = float.Parse(fila["Precio"].ToString());
               pivot.Cantidad = int.Parse(fila["Cantidad"].ToString());

               lista.Add(pivot);
           }

           return lista;
       }
       #endregion
   }
}
