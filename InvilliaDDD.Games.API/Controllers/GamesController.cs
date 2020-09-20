using InvilliaDDD.GameManager.Application.Interfaces;
using InvilliaDDD.GameManager.Application.ViewModels;
using InvilliaDDD.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.GameManager.API.Controllers
{
    [Authorize]
    public partial class GamesController : BaseController
    {
        private readonly IGameAppService _gameAppService;

        public GamesController(IGameAppService gameAppService)
        {
            _gameAppService = gameAppService;
        }
    }
}
