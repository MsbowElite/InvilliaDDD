using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InvilliaDDD.Server.Components;
using InvilliaDDD.Server.Services;
using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace InvilliaDDD.Server.Pages
{
    public class GameOverviewBase : ComponentBase
    {
        [CascadingParameter]
        Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public IGameDataService GameDataService { get; set; }

        public List<GameViewModel> Games { get; set; }

        protected AddGameDialog AddGameDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Games = (await GameDataService.GetAllGames()).ToList();
        }

        public async void AddGameDialog_OnDialogClose()
        {
            Games = (await GameDataService.GetAllGames()).ToList();
            StateHasChanged();
        }

        protected void QuickAddGame()
        {
            AddGameDialog.Show();
        }
    }
}
