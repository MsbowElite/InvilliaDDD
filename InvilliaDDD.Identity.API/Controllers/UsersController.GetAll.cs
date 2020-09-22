using InvilliaDDD.Core.ViewModels;
using InvilliaDDD.Identity.API.Models;
using InvilliaDDD.WebApi.Core.Identity;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet]
        [Authorize(StaticRoles.Admin)]
        [ProducesResponseType(typeof(UserAuthViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            try
            {
                var users = await _rw.User.GetUsersAsync();
                var usersMap = _mapper.Map<IEnumerable<Entities.User>, IEnumerable<Models.UserModel>>(users);
                return Ok(usersMap);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
