using System.Collections.Generic;
using System.Threading.Tasks;
using InvilliaDDD.Server.Services;
using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;

namespace InvilliaDDD.Server.Pages
{
    public class GameDetailBase : ComponentBase
    {
        [Inject]
        public IGameDataService GameDataService { get; set; }

        [Inject]
        public IFriendDataService FriendDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string GameId { get; set; }

        //needed to bind to select to value
        protected string FriendId;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        public List<FriendViewModel> Friends { get; set; } = new List<FriendViewModel>() { new FriendViewModel() { Id = Guid.Empty, Name = "Select" } };

        public GameDetailViewModel Game { get; set; } = new GameDetailViewModel();

        protected override async Task OnInitializedAsync()
        {
            Game = await GameDataService.GetGameDetails(new Guid(GameId));

            Friends.AddRange((await FriendDataService.GetAllFriends()).ToList());
        }

        protected async Task HandleLendGameSubmit()
        {
            var friendId = new Guid(FriendId);
            if (friendId != Guid.Empty)
            {
                Saved = await GameDataService.LendGame(Game.Id, friendId);
            }
        }

        protected async Task HandleTakeGameBackSubmit()
        {
            Saved = await GameDataService.TakeGame(Game.Id);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/gameoverview");
        }
    }
}
