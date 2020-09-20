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
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status201Created)]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel user)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var userMap = _mapper.Map<UserModel, Entities.User>(user);
                await _userService.Register(userMap, user.AdminRole);
                return CreatedAtAction(nameof(Login), user);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    _logger.LogDebug(ex.InnerException.Message);
                }
                else
                {
                    _logger.LogDebug(ex.Message);
                }
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
