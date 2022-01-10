namespace ups.delivey.portal.Pages.Tracking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using ups.delivey.portal.Models;

    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        public IEnumerable<Buy> ListBuys { get; set; }

        public async Task OnGet()
        {
            List<Buy> _Buy = new();

            var Responsive = await new HttpClient().GetAsync("http://php-api-entrega.test/listarCompras.php");

            var ContentResponse = JsonConvert.DeserializeObject(await Responsive.Content.ReadAsStringAsync());

            JArray Buys = JArray.Parse(ContentResponse.ToString());

            foreach (var Buy in Buys)
            {
                var ItemBuy = JsonConvert.DeserializeObject<Buy>(Buy.ToString());

                _Buy.Add(ItemBuy);
            }

            ListBuys = _Buy;
        }
    }
}
