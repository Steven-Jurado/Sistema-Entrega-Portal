namespace ups.delivey.portal.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using ups.delivey.portal.Models;

    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        [BindProperty]
        public User User { get; set; }

        public  void OnGet()
        {
           
        }

        public async Task<IActionResult> OnGetSignOut() 
        {
            await HttpContext.SignOutAsync( CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        public async Task<IActionResult>  OnPost() 
        {
            var Responsive = await new HttpClient().PostAsJsonAsync("http://php-api-entrega.test/listarUsuarios.php", User);

            var ContentResponse = JsonConvert.DeserializeObject(await Responsive.Content.ReadAsStringAsync());

            JArray Users = JArray.Parse(ContentResponse.ToString());

            if (Users.Count>0)
            {

                foreach (var User in Users)
                {
                    var ItemUser = JsonConvert.DeserializeObject<User>(User.ToString());

                    if (ItemUser.Rol.Equals("Administrador"))
                    {
                        SecurityAdmin();
                        HttpContext.Session.SetString("Manager", "Manager");
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        SecurityClient();
                        HttpContext.Session.SetString("Manager", "Manager");
                        return Redirect("/Home/Index");
                    }

                }
            }
            else
            {
                Message = "Error, Credentials Incorrect";
            }

            return Page();

        }

        protected async void SecurityAdmin()
        {
            var ListPermiss = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Role, "Admin")
                        };

            var AdminIdentity = new ClaimsIdentity(ListPermiss, CookieAuthenticationDefaults.AuthenticationScheme);
            var AdminPrincipal = new ClaimsPrincipal(new[] { AdminIdentity });

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, AdminPrincipal);

        }
        
        protected async void SecurityClient()
        {
            var ListPermiss = new List<Claim>()
                        {

                            new Claim(ClaimTypes.Role, "Client")
                        };

            var ClientIdentity = new ClaimsIdentity(ListPermiss, CookieAuthenticationDefaults.AuthenticationScheme);
            var ClientPrincipal = new ClaimsPrincipal(new[] { ClientIdentity });

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, ClientPrincipal);

        }
    }
}
