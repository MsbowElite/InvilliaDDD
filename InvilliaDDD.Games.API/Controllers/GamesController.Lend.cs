﻿using InvilliaDDD.WebApi.Core.Identity;
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
        /// <summary>
        /// Lend the game to a friend
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="friendId"></param>
        /// <returns></returns>
        [HttpPost("{gameId}/Friends/{friendId}")]
        [Authorize(Roles = StaticRoles.Admin)]
        public async Task<IActionResult> Post([FromRoute]Guid gameId, [FromRoute]Guid friendId)
        {
            return CustomResponse(await _gameAppService.Lend(gameId, friendId));
        }
    }
}
