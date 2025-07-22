using CommerzaWeb.Datos;
using CommerzaWeb.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerzaWeb.Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {

            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, Nombre From Marcas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Desc = (string)datos.Lector["Nombre"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public void agregarMarca(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearProcedimiento("storedAltaMarca");
                datos.setearParametro("@Nombre", nuevo.Desc);

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
        public void elminarMarca(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete from Marcas where id = @id");
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