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
                datos.setearConsuta("Select Id, Nombre From Marcas");
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

    }
}