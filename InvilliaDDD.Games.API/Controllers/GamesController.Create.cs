using InvilliaDDD.Core.ViewModels;
using InvilliaDDD.WebApi.Core.Controllers;
using InvilliaDDD.WebApi.Core.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.GameManager.API.Controllers
{
    public partial class GamesController
    {
        [HttpPost]
        [Authorize(Roles = StaticRoles.Admin)]
        public async Task<IActionResult> Post([FromBody]GameViewModel gameViewModel)
        {
            return CustomResponse(await _gameAppService.Register(gameViewModel));
        }
    }
}
