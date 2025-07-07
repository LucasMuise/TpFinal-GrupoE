using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommerzaWeb.Dominio;

namespace CommerzaWeb.Negocio
{
    public class CarritoNegocio
    {
        private const string KEY = "Carrito";

        /* Accede a la lista almacenada en sesión */
        private List<CarritoItem> Lista
        {
            get
            {
                if (HttpContext.Current.Session[KEY] == null)
                    HttpContext.Current.Session[KEY] = new List<CarritoItem>();

                return (List<CarritoItem>)HttpContext.Current.Session[KEY];
            }
        }

        /* Agrega un producto (o incrementa la cantidad) */
        public void Agregar(Producto producto, int cantidad = 1)
        {
            var item = Lista.FirstOrDefault(i => i.Producto.Id == producto.Id);
            if (item == null)
                Lista.Add(new CarritoItem { Producto = producto, Cantidad = cantidad });
            else
                item.Cantidad += cantidad;
        }

        public List<CarritoItem> ObtenerTodo() => Lista;

        public decimal Total() => Lista.Sum(i => i.Subtotal);

        public void Vaciar() => Lista.Clear();
    }
}