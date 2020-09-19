using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Friends.Validations
{
    public class DeleteFriendCommandValidation : FriendValidation<DeleteFriendCommand>
    {
        public DeleteFriendCommandValidation()
        {
            ValidateId();
        }
    }
}
