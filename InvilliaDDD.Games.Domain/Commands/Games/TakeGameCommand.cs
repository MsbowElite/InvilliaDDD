using InvilliaDDD.GameManager.Domain.Commands.Games.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Games
{
    public class TakeGameCommand : GameCommand
    {
        public TakeGameCommand(Guid gameId)
        {
            Id = gameId;
        }

        public override bool IsValid()
        {
            ValidationResult = new TakeGameCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
