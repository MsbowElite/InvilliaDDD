﻿using InvilliaDDD.GameManager.Domain.Commands.Games.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Games
{
    public class DeleteGameCommand : GameCommand
    {
        public DeleteGameCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteGameCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
