using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Friends.Validations
{
    public class RegisterNewFriendCommandValidation : FriendValidation<RegisterNewFriendCommand>
    {
        public RegisterNewFriendCommandValidation()
        {
            ValidateName();
        }
    }
}
