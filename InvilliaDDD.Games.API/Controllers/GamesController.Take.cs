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
        /// <summary>
        /// Take game back from any friend
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="friendId"></param>
        /// <returns></returns>
        [HttpDelete("{gameId}/Friends")]
        [Authorize(Roles = StaticRoles.Admin)]
        public async Task<IActionResult> Take([FromRoute]Guid gameId)
        {
            return CustomResponse(await _gameAppService.Take(gameId));
        }
    }
}
