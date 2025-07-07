using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerzaWeb.Dominio
{
    public class CarritoItem
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public decimal Subtotal => Producto.Precio * Cantidad;
    }
}