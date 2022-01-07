namespace ups.delivey.portal.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Buy
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string IdentificacionCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; } = 1;
        public string Estado { get; set; } = "Recibido";
    }
}
