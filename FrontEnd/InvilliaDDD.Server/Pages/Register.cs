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
    public class RegisterBase : ComponentBase
    {
        [Inject]
        public IUserDataService UserDataService { get; set; }

        [Inject] 
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid UserId { get; set; }

        public InputText UsernameInputText { get; set; }

        public UserRegisterViewModel User { get; set; } = new UserRegisterViewModel();

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async Task HandleValidSubmit()
        {
            if (User.Id == Guid.Empty) //new
            {
                var addedUser = await UserDataService.Register(User);
                if (addedUser != null)
                {
                    StatusClass = "alert-success";
                    Message = "User registered successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new user. Please try again.";
                    Saved = false;
                }
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
