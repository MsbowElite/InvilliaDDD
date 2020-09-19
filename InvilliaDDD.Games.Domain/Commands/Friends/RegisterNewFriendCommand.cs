using InvilliaDDD.GameManager.Domain.Commands.Friends.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Friends
{
    public class RegisterNewFriendCommand : FriendCommand
    {
        public RegisterNewFriendCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewFriendCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
