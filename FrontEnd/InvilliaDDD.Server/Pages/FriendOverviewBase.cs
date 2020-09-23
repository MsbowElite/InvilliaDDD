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
    public class FriendOverviewBase : ComponentBase
    {
        [CascadingParameter]
        Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public IFriendDataService FriendDataService { get; set; }

        public List<FriendViewModel> Friends { get; set; }

        protected AddFriendDialog AddFriendDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Friends = (await FriendDataService.GetAllFriends()).ToList();
        }

        public async void AddFriendDialog_OnDialogClose()
        {
            Friends = (await FriendDataService.GetAllFriends()).ToList();
            StateHasChanged();
        }

        protected void QuickAddFriend()
        {
            AddFriendDialog.Show();
        }
    }
}
