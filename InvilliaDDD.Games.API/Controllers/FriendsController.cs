using InvilliaDDD.GameManager.Application.Interfaces;
using InvilliaDDD.GameManager.Application.ViewModels;
using InvilliaDDD.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.GameManager.API.Controllers
{
    public partial class FriendsController : CommonController
    {
        private readonly IFriendAppService _friendAppService;

        public FriendsController(IFriendAppService friendAppService)
        {
            _friendAppService = friendAppService;
        }
    }
}
