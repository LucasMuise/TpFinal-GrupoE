﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommerzaWeb.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}