using System;
using System.Threading.Tasks;
using InvilliaDDD.Server.Services;
using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Components;

namespace InvilliaDDD.Server.Components
{
    public class AddFriendDialogBase : ComponentBase
    {
        public bool ShowDialog { get; set; }

        public FriendViewModel Friend { get; set; } = new FriendViewModel { Name = "Name" };

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        [Inject] 
        public IFriendDataService FriendDataService { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Friend = new FriendViewModel { Name = "Name" };
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            await FriendDataService.AddFriend(Friend);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
