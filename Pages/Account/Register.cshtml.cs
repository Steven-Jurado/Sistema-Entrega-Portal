using System;
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

namespace ups.delivey.portal.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public User User { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var Responsive = await new HttpClient().PostAsJsonAsync("http://php-api-entrega.test/insertarUsuario.php", User);

                var ContentResponse = JsonConvert.DeserializeObject(await Responsive.Content.ReadAsStringAsync());

                Message = "Succes, Account";

                return Redirect("/Account/Index");
            }
            catch (Exception)
            {
                Message = "Error";
                return Page();
            }
            

        }
    }
}
