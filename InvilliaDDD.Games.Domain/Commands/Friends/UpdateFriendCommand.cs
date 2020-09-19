using InvilliaDDD.GameManager.Domain.Commands.Friends.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Friends
{
    public class UpdateFriendCommand : FriendCommand
    {
        public UpdateFriendCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFriendCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
