using System.Collections.Generic;
using System.Threading.Tasks;
using InvilliaDDD.Server.Services;
using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Components;
using System;

namespace InvilliaDDD.Server.Pages
{
    public class GameDetailBase : ComponentBase
    {
        [Inject]
        public IGameDataService GameDataService { get; set; }

        [Parameter]
        public Guid GameId { get; set; }
       
        public GameViewModel Game { get; set; } = new GameViewModel();

        protected override async Task OnInitializedAsync()
        {
            Game = await GameDataService.GetGameDetails(GameId);
        }
    }
}
