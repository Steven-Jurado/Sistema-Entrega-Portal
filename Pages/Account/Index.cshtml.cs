using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ups.delivey.portal.Models;

namespace ups.delivey.portal.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
            HttpContext.Session.Remove("Manager");
        }

        public async Task<IActionResult>  OnPost() 
        {
            //User _User = new() { UserName = Request.Form["UserName"], Password = Request.Form["Password"] };
            //_User.Email = "admin@asd.com";
            //var Responsive = await new HttpClient().PostAsJsonAsync("https://localhost:44353/Account", _User);

            //var Content = JsonConvert.DeserializeObject( await Responsive.Content.ReadAsStringAsync());

            //if (Responsive.StatusCode == System.Net.HttpStatusCode.OK && Content != null)
            //{
            //    return Redirect("/Home/Index");
            //}
            //else
            //{
            //    if (Responsive.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            //    {
            //        Message = "Wrong, Please verify your email or password";
            //    }
            //    else
            //    {
            //        Message = $"Wrong,{Responsive.StatusCode} {Content} ";
            //    }
            //}

            //return Page();

            return Redirect("/Home/Index");

        }
    }
}
