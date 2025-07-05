using CommerzaWeb.Datos;
using CommerzaWeb.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CommerzaWeb.Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listarProducto()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsuta("SELECT Id, Nombre, Descripcion, Precio, ImagenUrl, Stock FROM Productos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)datos.Lector["Id"];
                    producto.Nombre = (String)datos.Lector["Nombre"];
                    producto.Descripcion = (String)datos.Lector["Descripcion"];
                    producto.Precio = (decimal)datos.Lector["Precio"];
                    producto.Stock = (int)datos.Lector["Stock"];
                    producto.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(producto);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Producto traerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsuta("Select P.Id,P.Nombre,P.Descripcion,P.Precio,P.Stock,P.CategoriaId,  C.Nombre as Categoria,P.MarcaId, M.Nombre as Marca from Productos P INNER JOIN Marcas M ON P.MarcaId = M.Id    INNER JOIN Categorias C ON P.CategoriaId = C.Id Where P.Id = @Id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Producto producto = new Producto()
                    {

                        Nombre = (string)datos.Lector["Nombre"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        Precio = (Decimal)datos.Lector["Precio"],
                        Stock = (int)datos.Lector["Stock"],
                        Categoria = new Categoria()
                        {
                            Id = (int)datos.Lector["CategoriaId"],
                            Desc = (string)datos.Lector["Categoria"]
                        },
                        Marca = new Marca()
                        {
                            Id = (int)datos.Lector["MarcaId"],
                            Desc = (string)datos.Lector["Marca"]
                        }
                    };

                    return producto;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregarConSp(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearProcedimiento("storedAltaProducto");

             
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.setearParametro("@Stock", nuevo.Stock);
                datos.setearParametro("@CategoriaId", nuevo.Categoria.Id);
                datos.setearParametro("@MarcaId", nuevo.Marca.Id);
                

                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }
        public void modificarConSp(Producto produc)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            { 
                datos.setearProcedimiento("storedModificar");
                datos.setearParametro("@Id", produc.Id);
                datos.setearParametro("@Nombre", produc.Nombre);
                datos.setearParametro("@Descripcion", produc.Descripcion);
                datos.setearParametro("@Precio", produc.Precio);
                datos.setearParametro("@Stock", produc.Stock);
                datos.setearParametro("@CategoriaId", produc.Categoria.Id);
                datos.setearParametro("@MarcaId", produc.Marca.Id);
             
               


                datos.ejecutarLectura();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {


                datos.cerrarConexion();


            }



        }
        public List<Producto> listarConSp()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)datos.Lector["Id"];
                    producto.Nombre = (String)datos.Lector["Nombre"];
                    producto.Descripcion = (String)datos.Lector["Descripcion"];
                    producto.Precio = (decimal)datos.Lector["Precio"];
                    producto.Stock = (int)datos.Lector["Stock"];
                    producto.Categoria = new Categoria();
                    producto.Categoria.Desc = (string)datos.Lector["Categoria"];
                    producto.Marca = new Marca();
                    producto.Marca.Desc = (string)datos.Lector["Marca"];
                  
                    lista.Add(producto);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void eliminar(int id)
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsuta("delete from Productos where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}