using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public IActionResult OnPost() 
        {
            if (Request.Form["UserName"].Equals("admin") && Request.Form["Password"].Equals("123"))
            {
                HttpContext.Session.SetString("Manager","True");
                return Redirect("/Home/Index");
            }
            else
            {
                Message = "Wrong, Please verify your email or password";
                return Page();
            }
        }
    }
}
