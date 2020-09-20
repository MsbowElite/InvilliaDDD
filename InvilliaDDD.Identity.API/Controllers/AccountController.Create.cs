using InvilliaDDD.Identity.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Controllers
{
    public partial class AccountController
    {
        [HttpPost]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // TODO: [raphael] obter id da adesão da autenticação.
            var user = new ApplicationUser
            {
                UserName = userRegister.Login,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
                //return CustomResponse(await GerarJwt(usuarioRegistro.Login));
                return CustomResponse();
            }

            foreach (var error in result.Errors)
            {
                AddError(error.Description);
            }

            return CustomResponse();
        }
    }
}
