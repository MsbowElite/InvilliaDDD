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
        [HttpGet("{id}")]
        public async Task<IEnumerable<GameViewModel>> Get(Guid id)
        {
            return await _gameAppService.GetAll();
        }
    }
}
