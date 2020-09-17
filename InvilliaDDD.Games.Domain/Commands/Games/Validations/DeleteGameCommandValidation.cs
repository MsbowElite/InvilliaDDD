using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Games.Validations
{
    public class DeleteGameCommandValidation : GameValidation<DeleteGameCommand>
    {
        public DeleteGameCommandValidation()
        {
            ValidateId();
        }
    }
}
