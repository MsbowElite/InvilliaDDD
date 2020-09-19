using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazor.Server.Services;
using Blazor.Shared;
using Blazor.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace Blazor.Server.Pages
{
    public class GameOverviewBase: ComponentBase
    {
        //[Inject]
        //public IHttpClientFactory _clientFactory { get; set; }

        [Inject]
        public IGameDataService GameDataService { get; set; }

        public List<GameDTO> Games { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Games = (await GameDataService.GetAllGames()).Data;

            //AddGameDialog.OnDialogClose += AddGameDialog_OnDialogClose;
        }

        public async void AddGameDialog_OnDialogClose()
        {
            Games = (await GameDataService.GetAllGames()).Data;
            StateHasChanged();
        }
    }
}
