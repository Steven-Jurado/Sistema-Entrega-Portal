using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ups.delivey.portal.Models;

namespace ups.delivey.portal.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {

            if (Request.Form["Password"].Equals(Request.Form["PasswordRepeat"]))
            {
                User _User = new() { UserName = Request.Form["UserName"], Password = Request.Form["Password"], Email = Request.Form["Email"] };

                var Responsive = await new HttpClient().PostAsJsonAsync("https://localhost:44353/Register/Account", _User);

                var Content = JsonConvert.DeserializeObject(await Responsive.Content.ReadAsStringAsync());

                if (Responsive.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    Message = "Successful, Account created";
                    return Redirect("/Account/Index");
                }
            }
            else
            {
                Message = "Verify, That your password is the same";
            }

            return Page();

        }
    }
}
