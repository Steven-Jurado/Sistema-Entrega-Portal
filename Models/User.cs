using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ups.delivey.portal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Rol { get; set; } = "Cliente";
    }
}
