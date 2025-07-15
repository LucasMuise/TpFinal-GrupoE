using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommerzaWeb.Dominio;

namespace CommerzaWeb.Negocio
{
    public class CarritoNegocio
    {
        private const string KEY = "Carrito";

        
        private List<CarritoItem> Lista
        {
            get
            {
                if (HttpContext.Current.Session[KEY] == null)
                    HttpContext.Current.Session[KEY] = new List<CarritoItem>();

                return (List<CarritoItem>)HttpContext.Current.Session[KEY];
            }
            set
            {
                HttpContext.Current.Session[KEY] = value;
            }
        }

        public void Agregar(Producto producto, int cantidad = 1)
        {
            var lista = Lista;
            var item = lista.FirstOrDefault(i => i.Producto.Id == producto.Id);

            if (item == null)
                lista.Add(new CarritoItem { Producto = producto, Cantidad = cantidad });
            else
                item.Cantidad += cantidad;

            Lista = lista; // ahora esto está bien
        }

        public void Eliminar(int productoId)
        {
            var lista = Lista;
            var item = lista.FirstOrDefault(i => i.Producto.Id == productoId);
            if (item != null)
            {
                lista.Remove(item);
                Lista = lista;
            }
        }

        public List<CarritoItem> ObtenerTodo() => Lista;

        public decimal Total() => Lista.Sum(i => i.Subtotal);

        public void Vaciar() => Lista.Clear();
    }
}