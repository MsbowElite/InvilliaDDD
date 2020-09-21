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
        [HttpPost("{gameId}/Users/{userId}")]
        [Authorize(Roles = StaticRoles.Admin)]
        public async Task<IActionResult> Post([FromRoute]Guid gameId, [FromRoute]Guid userId)
        {
            return CustomResponse(await _gameAppService.Register(gameViewModel));
        }
    }
}
