using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerzaWeb.Dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }
}