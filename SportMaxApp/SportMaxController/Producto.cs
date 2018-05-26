using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportMaxModel;
using System.Data;


namespace SportMaxController
{
   public class Producto
   {
       #region Variables Privadas
       private int _codigo;
       private string _descripcion;
       private TipoProducto _tipo;
       private float _precio;
       private int _cantidad;
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

       #endregion

       #region Metodos
       public void Agregar()
       {

           DALProducto dalProducto = new DALProducto();

           try
           {
               dalProducto.AgregarProducto(this.Codigo,this.TipoProducto.CodigoTipo, this.Descripcion,this.Precio,this.Cantidad);
           }
           catch (Exception)
           {

               throw;
           }

       }

       public List<Producto> Listar()
       {
           DALProducto dalProducto = new DALProducto();
           DataTable tabla = dalProducto.Listar();
           List<Producto> lista = new List<Producto>();
           Producto pivot;

           foreach (DataRow fila in tabla.Rows)
           {
               pivot = new Producto();

               pivot.Codigo = int.Parse(fila["idProducto"].ToString());
               pivot.TipoProducto.CodigoTipo = int.Parse(fila["IdTipoProducto"].ToString());
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

           foreach (DataRow fila in tabla.Rows)
           {
               pivot = new Producto();

               pivot.Codigo = int.Parse(fila["idProducto"].ToString());
               pivot.TipoProducto.CodigoTipo = int.Parse(fila["IdTipoProducto"].ToString());
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

           foreach (DataRow fila in tabla.Rows)
           {
               pivot = new Producto();

               pivot.Codigo = int.Parse(fila["idProducto"].ToString());
               pivot.TipoProducto.CodigoTipo = int.Parse(fila["IdTipoProducto"].ToString());
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
