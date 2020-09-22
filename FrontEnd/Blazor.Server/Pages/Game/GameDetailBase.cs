using System.Threading.Tasks;
using Blazor.Server.Services;
using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace Blazor.Server.Pages
{
    public class GameDetailBase : ComponentBase
    {
        [Inject]
        public IGameDataService GameDataService { get; set; }

        [Parameter]
        public string GameId { get; set; }
       
        public GameViewModel Game { get; set; } = new GameViewModel();

        protected override async Task OnInitializedAsync()
        {
            Game = await GameDataService.GetGameDetails(new System.Guid(GameId));
        }
    }
}
