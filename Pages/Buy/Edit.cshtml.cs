namespace ups.delivey.portal.Pages.Buy
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
    using Newtonsoft.Json.Linq;
    using ups.delivey.portal.Models;

    public class EditModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Buy _Buy { get; set; }

        public async Task OnGet( int Id )
        {
            var Responsive = await new HttpClient().GetAsync($"http://php-api-entrega.test/listaFiltradaIdCompras.php/?Id={Id}");

            var ContentResponse = JsonConvert.DeserializeObject(await Responsive.Content.ReadAsStringAsync());

            JArray Buys = JArray.Parse(ContentResponse.ToString());

            foreach (var Buy in Buys)
            {
                _Buy = JsonConvert.DeserializeObject<Buy>(Buy.ToString());

            }

        }

        public async Task<IActionResult> OnPost()
        {
            var Responsive = await new HttpClient().PostAsJsonAsync("http://php-api-entrega.test/actualizarCompras.php", _Buy);

            if (Responsive.StatusCode == HttpStatusCode.OK)
            {
                Message = "Update";
            }

            return Redirect("/Tracking");
        }
    }
}
