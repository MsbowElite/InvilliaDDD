using System;
using System.Threading.Tasks;
using InvilliaDDD.Server.Services;
using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InvilliaDDD.Server.Components
{
    public class AddGameDialogBase : ComponentBase
    {
        public bool ShowDialog { get; set; }

        public GameViewModel Game { get; set; } = new GameViewModel { Name = "Name" };

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Inject] 
        public IGameDataService GameDataService { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Game = new GameViewModel { Name = "Name" };
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            await GameDataService.AddGame(Game);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
