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
    public partial class GameController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GameViewModel gameViewModel)
        {
            return CustomResponse(await _gameAppService.Register(gameViewModel));
        }
    }
}
