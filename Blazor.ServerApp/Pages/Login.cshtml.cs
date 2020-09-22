using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Server.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blazor.ServerApp
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Inject]
        public IIdentityDataService IdentityDataService { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!(Email == "kevin.dockx@gmail.com" && Password == "password"))
            //{
            //    return Page();
            //}

            var lol = await IdentityDataService.Login(Username, Password);

            //var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, "Kevin"),
            //    new Claim(ClaimTypes.Email, Email),
            //};

            //var claimsIdentity = new ClaimsIdentity(
            //    claims,
            //    CookieAuthenticationDefaults.AuthenticationScheme);

            //await HttpContext.SignInAsync(
            //  CookieAuthenticationDefaults.AuthenticationScheme,
            //  new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect(Url.Content("~/"));
        }
    }
}