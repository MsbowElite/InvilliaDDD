using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Games.Validations
{
    public class TakeGameCommandValidation : GameValidation<TakeGameCommand>
    {
        public TakeGameCommandValidation()
        {
            ValidateId();
        }
    }
}
