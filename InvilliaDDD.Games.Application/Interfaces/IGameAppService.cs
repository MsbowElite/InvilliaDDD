﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using InvilliaDDD.GameManager.Application.ViewModels;

namespace InvilliaDDD.GameManager.Application.Interfaces
{
    public interface IGameAppService : IDisposable
    {
        Task<IEnumerable<GameViewModel>> GetAll();
        Task<GameViewModel> GetById(Guid id);

        Task<ValidationResult> Register(GameViewModel gameViewModel);
        Task<ValidationResult> Update(GameViewModel gameViewModel);
        Task<ValidationResult> Delete(Guid id);
    }
}