using System.Threading.Tasks;
using Blazor.Server.Services;
using Blazor.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace Blazor.Server.Pages
{
    public class GameDetailBase : ComponentBase
    {
        [Inject]
        public IGameDataService GameDataService { get; set; }

        [Parameter]
        public string GameId { get; set; }
       
        public GameDTO Game { get; set; } = new GameDTO();

        protected override async Task OnInitializedAsync()
        {
            Game = await GameDataService.GetGameDetails(new System.Guid(GameId));
        }
    }
}
