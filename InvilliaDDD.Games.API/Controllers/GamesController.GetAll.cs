using InvilliaDDD.Core.ViewModels;
using InvilliaDDD.WebApi.Core.Controllers;
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
        [HttpGet]
        public async Task<IEnumerable<GameViewModel>> Get()
        {
            return await _gameAppService.GetAll();
        }
    }
}
