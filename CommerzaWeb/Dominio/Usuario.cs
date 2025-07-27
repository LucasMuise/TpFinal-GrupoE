using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerzaWeb.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string Rol { get; set; } 
        public int RolId {  get; set; }
        public string Telefono { get; set; }
        public string Localidad { get; set; }
        public string Direccion { get; set; }
        public string DireccionAltura { get; set; }
    }
}