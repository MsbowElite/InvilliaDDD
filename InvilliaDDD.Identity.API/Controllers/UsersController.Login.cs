using InvilliaDDD.Core.ViewModels;
using InvilliaDDD.Identity.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Controllers
{
    public partial class UsersController
    {
        [HttpPost("Login")]
        [ProducesResponseType(typeof(UserAuthViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] UserModel userParam)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var user = await _userService.Login(userParam.Username, userParam.Password);

                if (user == null)
                    return Unauthorized(new { message = "Username or password is incorrect" });

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
