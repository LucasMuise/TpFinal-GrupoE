using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerzaWeb.Dominio
{
    public class Marca
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public override string ToString()
        {
            return this.Desc;
        }
    }
}