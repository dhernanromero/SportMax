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
       private bool _estado;
       private string _talle;

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

       public bool Estado
       {
           get { return _estado; }
           set { _estado = value; }
       }

       public string Talle
       {
           get { return _talle; }
           set { _talle = value; }
       }
       #endregion

       #region Metodos
       public int Agregar()
       {

           DALProducto dalProducto = new DALProducto();

           try
           {
               return dalProducto.AgregarProducto(this.Codigo,this.TipoProducto.IdTipoProducto, this.Marca.IdMarca, this.Descripcion,this.Talle,this.Precio,this.Cantidad,this.Estado);
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
           Producto pProducto;
           TipoProducto pTipoProducto;
           Marca pMarca;
           
           foreach (DataRow fila in tabla.Rows)
           {
               pProducto = new Producto();
               pTipoProducto = new TipoProducto();
               pMarca = new Marca();
               
               pProducto.Codigo = int.Parse(fila["idProducto"].ToString());
               pProducto.Descripcion = fila["Descripcion"].ToString();
               pProducto.Precio = float.Parse(fila["Precio"].ToString());
               pProducto.Cantidad = int.Parse(fila["Cantidad"].ToString());
               
               pTipoProducto.IdTipoProducto = int.Parse(fila["IdTipoProducto"].ToString());
               pTipoProducto.Descripcion = fila["TipoProdDescrip"].ToString();
               pProducto.TipoProducto = pTipoProducto;
               
               pMarca.IdMarca = int.Parse(fila["IdTipoProducto"].ToString());
               pMarca.Descripcion = fila["TipoProdDescrip"].ToString();
               pProducto.Marca = pMarca;
               pProducto.Talle = fila["Talle"].ToString();
               pProducto.Estado = bool.Parse(fila["Estado"].ToString());

               lista.Add(pProducto);
           }

           return lista;

       }

       public List<Producto> BuscarxCodigo(int Codigo)
       {
           DALProducto dalProducto = new DALProducto();
           DataTable tabla = dalProducto.Listar();
           List<Producto> lista = new List<Producto>();
           Producto pProducto;
           TipoProducto pTipoProducto;
           Marca pMarca;

           foreach (DataRow fila in tabla.Rows)
           {
               pProducto = new Producto();
               pTipoProducto = new TipoProducto();
               pMarca = new Marca();

               pProducto.Codigo = int.Parse(fila["idProducto"].ToString());
               pProducto.Descripcion = fila["Descripcion"].ToString();
               pProducto.Precio = float.Parse(fila["Precio"].ToString());
               pProducto.Cantidad = int.Parse(fila["Cantidad"].ToString());

               pTipoProducto.IdTipoProducto = int.Parse(fila["IdTipoProducto"].ToString());
               pTipoProducto.Descripcion = fila["TipoProdDescrip"].ToString();
               pProducto.TipoProducto = pTipoProducto;

               pMarca.IdMarca = int.Parse(fila["IdTipoProducto"].ToString());
               pMarca.Descripcion = fila["TipoProdDescrip"].ToString();
               pProducto.Marca = pMarca;
               pProducto.Talle = fila["Talle"].ToString();
               pProducto.Estado = bool.Parse(fila["Estado"].ToString());

               lista.Add(pProducto);
           }

           return lista;
       }

       public List<Producto> BuscarxDescripcion(string Descrip)
       {
           DALProducto dalProducto = new DALProducto();
           DataTable tabla = dalProducto.Listar();
           List<Producto> lista = new List<Producto>();
           Producto pProducto;
           TipoProducto pTipoProducto;
           Marca pMarca;

           foreach (DataRow fila in tabla.Rows)
           {
               pProducto = new Producto();
               pTipoProducto = new TipoProducto();
               pMarca = new Marca();

               pProducto.Codigo = int.Parse(fila["idProducto"].ToString());
               pProducto.Descripcion = fila["Descripcion"].ToString();
               pProducto.Precio = float.Parse(fila["Precio"].ToString());
               pProducto.Cantidad = int.Parse(fila["Cantidad"].ToString());

               pTipoProducto.IdTipoProducto = int.Parse(fila["IdTipoProducto"].ToString());
               pTipoProducto.Descripcion = fila["TipoProdDescrip"].ToString();
               pProducto.TipoProducto = pTipoProducto;

               pMarca.IdMarca = int.Parse(fila["IdTipoProducto"].ToString());
               pMarca.Descripcion = fila["TipoProdDescrip"].ToString();
               pProducto.Marca = pMarca;
               pProducto.Talle = fila["Talle"].ToString();
               pProducto.Estado = bool.Parse(fila["Estado"].ToString());

               lista.Add(pProducto);
           }

           return lista;
       }

       public int Modificar()
       {
           DALProducto dalProducto = new DALProducto();
           try
           {
               return dalProducto.ModificarProducto(this.Codigo, this.TipoProducto.IdTipoProducto, this.Marca.IdMarca, this.Descripcion, this.Talle, this.Precio, this.Cantidad, this.Estado);
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public int Eliminar(int idProducto)
       {
           DALProducto dalProducto = new DALProducto();
           try
           {
               return dalProducto.EliminarProducto(idProducto);
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       #endregion

   }
}
