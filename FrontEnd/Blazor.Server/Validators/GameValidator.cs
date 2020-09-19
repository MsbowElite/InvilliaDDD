using Blazor.Shared.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Server.Validators
{
    public class GameValidator : AbstractValidator<GameDTO>
    {
        public GameValidator()
        {

        }
    }
}
