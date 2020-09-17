using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Game.Validations
{
    public class RegisterNewGameCommandValidation : GameValidation<RegisterNewGameCommand>
    {
        public RegisterNewGameCommandValidation()
        {
            ValidateName();
            ValidateId();
        }
    }
}
