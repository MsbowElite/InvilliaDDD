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
    public class FriendEditBase : ComponentBase
    {
        [Inject]
        public IFriendDataService FriendDataService { get; set; }

        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string FriendId { get; set; }

        public InputText NameInputText { get; set; }

        public FriendViewModel Friend { get; set; } = new FriendViewModel();

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

            if (string.IsNullOrEmpty(FriendId))
            {
                //add some defaults
                Friend = new FriendViewModel();
            }
            else
            {
                Friend = await FriendDataService.GetFriendDetails(new Guid(FriendId));
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (Friend.Id == Guid.Empty) //new
            {
                if (await FriendDataService.AddFriend(Friend))
                {
                    StatusClass = "alert-success";
                    Message = "New friend added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new friend. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await FriendDataService.UpdateFriend(Friend);
                StatusClass = "alert-success";
                Message = "Friend updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteFriend()
        {
            await FriendDataService.DeleteFriend(Friend.Id);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/friendoverview");
        }
    }
}
