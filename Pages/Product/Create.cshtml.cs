namespace ups.delivey.portal.Pages.Product
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Newtonsoft.Json;
    using ups.delivey.portal.Models;

    public class CreateModel : PageModel
    {

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            Product _Product = new() { 
                Nombre = Request.Form["Nombre"], 
                Cantidad = Convert.ToInt32(Request.Form["Cantidad"]), 
                Categoria = Request.Form["Categoria"],
                Valor = Convert.ToDecimal(Request.Form["Valor"])
            };

            var Responsive = await new HttpClient().PostAsJsonAsync("http://php-api-entrega.test/insertarProductos.php", _Product);

            var Content = JsonConvert.DeserializeObject(await Responsive.Content.ReadAsStringAsync());

            if (Responsive.StatusCode == HttpStatusCode.OK)
            {
                Message = "Success";
            }


            return Page();
        }
    }
}
