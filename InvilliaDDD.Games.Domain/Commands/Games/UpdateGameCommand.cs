using InvilliaDDD.Core.Communication;
using InvilliaDDD.GameManager.Domain.Commands.Games.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Games
{
    public class UpdateGameCommand : GameCommand
    {
        public UpdateGameCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool IsValid()
        {
            ResponseResult = (ResponseResult) new UpdateGameCommandValidation().Validate(this);
            return ResponseResult.IsValid;
        }
    }
}
