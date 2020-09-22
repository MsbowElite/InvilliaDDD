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
    public partial class FriendsController
    {
        [HttpPost]
        [Authorize(Roles = StaticRoles.Admin)]
        public async Task<IActionResult> Post([FromBody]FriendViewModel friendViewModel)
        {
            return CustomResponse(await _friendAppService.Register(friendViewModel));
        }
    }
}
