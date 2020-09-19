using InvilliaDDD.GameManager.Domain.Commands.Friends.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Friends
{
    public class DeleteFriendCommand : FriendCommand
    {
        public DeleteFriendCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteFriendCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
