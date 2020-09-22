using InvilliaDDD.GameManager.Application.Interfaces;
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
    [Authorize(Roles = StaticRoles.User)]
    public partial class FriendsController : CommonController
    {
        private readonly IFriendAppService _friendAppService;

        public FriendsController(IFriendAppService friendAppService)
        {
            _friendAppService = friendAppService;
        }
    }
}
