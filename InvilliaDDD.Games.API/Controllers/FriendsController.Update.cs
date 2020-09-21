﻿using InvilliaDDD.GameManager.Application.ViewModels;
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
        [HttpPut]
        [Authorize(Roles = StaticRoles.Admin)]
        public async Task<IActionResult> Put([FromBody]FriendViewModel friendViewModel)
        {
            return CustomResponse(await _friendAppService.Register(friendViewModel));
        }
    }
}
