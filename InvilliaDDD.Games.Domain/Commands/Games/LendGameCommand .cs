using InvilliaDDD.GameManager.Domain.Commands.Games.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Games
{
    public class LendGameCommand : GameCommand
    {
        public Guid FriendId { get; protected set; }

        public LendGameCommand(Guid gameId, Guid friendId)
        {
            Id = gameId;
            FriendId = friendId;
        }

        public override bool IsValid()
        {
            ValidationResult = new LendGameCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
