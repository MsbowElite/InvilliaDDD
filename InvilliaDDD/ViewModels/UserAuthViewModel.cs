using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.Core.ViewModels
{
    public class UserAuthViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public IEnumerable<UserRoleViewModel> UserRoles { get; set; }
    }
}
