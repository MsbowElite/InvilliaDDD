using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvilliaDDD.Server.Services;
using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace InvilliaDDD.Server.Pages
{
    public class GameEditBase : ComponentBase
    {
        [Inject]
        public IGameDataService GameDataService { get; set; }

        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid GameId { get; set; }

        public InputText NameInputText { get; set; }

        public GameViewModel Game { get; set; } = new GameViewModel();

        //needed to bind to select to value
        protected string CountryId = string.Empty;
        protected string JobCategoryId = string.Empty;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            if (GameId == Guid.Empty)
            {
                //add some defaults
                Game = new GameViewModel { Name = "Zezinho" };
            }
            else
            {
                Game = await GameDataService.GetGameDetails(GameId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (Game.Id == Guid.Empty) //new
            {
                var addedGame = await GameDataService.AddGame(Game);
                if (addedGame != null)
                {
                    StatusClass = "alert-success";
                    Message = "New game added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new game. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await GameDataService.UpdateGame(Game);
                StatusClass = "alert-success";
                Message = "Game updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteGame()
        {
            await GameDataService.DeleteGame(Game.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/gameoverview");
        }
    }
}
