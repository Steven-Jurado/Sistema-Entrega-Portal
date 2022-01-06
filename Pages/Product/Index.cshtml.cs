namespace ups.delivey.portal.Pages.Product
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using ups.delivey.portal.Models;

    public class IndexModel : PageModel
    {


        public IEnumerable<Product> ListProduct { get; set; } 

        public async Task OnGet()
        {
            List<Product> _Product = new();

            var Responsive = await new HttpClient().GetAsync("http://php-api-entrega.test/listarProductos.php");

            var ContentResponse = JsonConvert.DeserializeObject(await Responsive.Content.ReadAsStringAsync());

            JArray Products = JArray.Parse(ContentResponse.ToString());

            foreach (var Product in Products)
            {
                var ItemProduct = JsonConvert.DeserializeObject<Product>(Product.ToString());

                _Product.Add(ItemProduct);
            }

            ListProduct = _Product;
        }

    }
}
