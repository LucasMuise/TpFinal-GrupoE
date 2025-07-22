using CommerzaWeb.Datos;
using CommerzaWeb.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerzaWeb.Negocio
{
    public static class ImagenNegocio
    {
        public static List<Imagen> ListarImagenesDeProducto(int idProducto)
        {
            List<Imagen> imagenesDeProducto = new List<Imagen>();
            AccesoDatos db = new AccesoDatos();

            try
            {
                db.setearConsulta("SELECT Id, ProductoId, Url FROM Imagenes WHERE ProductoId = @idProducto");
                db.setearParametro("@idProducto", idProducto);
                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    imagenesDeProducto.Add(new Imagen()
                    {
                        Id = (int)db.Lector["Id"],
                        IdProducto = (int)db.Lector["ProductoId"],
                        Url = db.Lector["Url"] as string
                    });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.cerrarConexion();
            }
            return imagenesDeProducto;
        }

        public static string TraerImagenPrincipalDeProducto(int idProducto)
        {
            string urlImagenPrincipal = null;
            AccesoDatos db = new AccesoDatos();

            try
            {
                db.setearConsulta("SELECT TOP 1 Id, ProductoId, Url FROM Imagenes WHERE ProductoId = @idProducto");
                db.setearParametro("@idProducto", idProducto);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    urlImagenPrincipal = db.Lector["Url"] as string;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.cerrarConexion();
            }

            return urlImagenPrincipal;
        }
    }
}