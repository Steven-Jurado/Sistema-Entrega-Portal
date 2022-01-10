namespace ups.delivey.portal.Pages.Buy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Newtonsoft.Json;
    using ups.delivey.portal.Models;

    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public Buy Buy { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var Responsive = await new HttpClient().PostAsJsonAsync("http://php-api-entrega.test/insertarCompras.php", Buy);

            if (Responsive.StatusCode == HttpStatusCode.OK)
            {
                Message = "Success";
            }

            return Page();
        }
    }
}
