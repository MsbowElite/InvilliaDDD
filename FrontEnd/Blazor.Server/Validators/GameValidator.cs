using FluentValidation;
using InvilliaDDD.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Server.Validators
{
    public class GameValidator : AbstractValidator<GameViewModel>
    {
        public GameValidator()
        {

        }
    }
}
