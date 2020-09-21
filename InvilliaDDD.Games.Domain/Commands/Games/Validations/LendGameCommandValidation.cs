using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Games.Validations
{
    public class LendGameCommandValidation : GameValidation<LendGameCommand>
    {
        public LendGameCommandValidation()
        {
            ValidateId();
        }
    }
}
