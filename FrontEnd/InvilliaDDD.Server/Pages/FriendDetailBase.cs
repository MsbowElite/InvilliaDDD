using System.Collections.Generic;
using System.Threading.Tasks;
using InvilliaDDD.Server.Services;
using InvilliaDDD.Core.ViewModels;
using Microsoft.AspNetCore.Components;
using System;

namespace InvilliaDDD.Server.Pages
{
    public class FriendDetailBase : ComponentBase
    {
        [Inject]
        public IFriendDataService FriendDataService { get; set; }

        [Parameter]
        public string FriendId { get; set; }
       
        public FriendViewModel Friend { get; set; } = new FriendViewModel();

        protected override async Task OnInitializedAsync()
        {
            Friend = await FriendDataService.GetFriendDetails(new Guid(FriendId));
        }
    }
}
