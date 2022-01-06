namespace ups.delivey.portal.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Product
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; } = 0;
        public string Categoria { get; set; }
        public decimal Valor { get; set; } = decimal.Zero;
    }
}
