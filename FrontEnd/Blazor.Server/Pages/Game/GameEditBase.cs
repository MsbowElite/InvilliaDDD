using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Server.Services;
using Blazor.Shared;
using Blazor.Shared.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace Blazor.Server.Pages
{
    public class GameEditBase : ComponentBase
    {
        [Inject]
        public IGameDataService GameDataService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string GameId { get; set; }

        public GameDTO Game { get; set; } = new GameDTO();

        //needed to bind to select to value
        protected string CountryId = string.Empty;
        protected string JobCategoryId = string.Empty;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        private IValidator validator;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            Guid.TryParse(GameId, out var gameId);

            if (gameId != Guid.Empty) //new Game is being created
            {
                Game = await GameDataService.GetGameDetails(gameId);
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (Game.Id == Guid.Empty) //new
            {
                var addedGame = await GameDataService.AddGame(Game);
                if (addedGame != Guid.Empty)
                {
                    StatusClass = "alert-success";
                    Message = "New Game added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new Game. Please try again.";
                    Saved = false;
                }
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
