﻿using System;
using FluentValidation;

namespace InvilliaDDD.GameManager.Domain.Commands.Friends.Validations
{
    public abstract class FriendValidation<T> : AbstractValidator<T> where T : FriendCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
