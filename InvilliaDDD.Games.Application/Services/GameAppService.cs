using AutoMapper;
using FluentValidation.Results;
using InvilliaDDD.Core.Communication.Mediator;
using InvilliaDDD.GameManager.Application.Interfaces;
using InvilliaDDD.GameManager.Application.ViewModels;
using InvilliaDDD.GameManager.Domain.Commands.Games;
using InvilliaDDD.GameManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvilliaDDD.GameManager.Application.Services
{
    public class GameAppService : IGameAppService
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly IMediatorHandler _mediator;

        public GameAppService(IMapper mapper,
                          IGameRepository gameRepository,
                          IMediatorHandler mediator)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<GameViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<GameViewModel>>(await _gameRepository.GetAllActive());
        }


        public async Task<GameViewModel> GetById(Guid id)
        {
            return _mapper.Map<GameViewModel>(await _gameRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(GameViewModel gameViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewGameCommand>(gameViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(GameViewModel gameViewModel)
        {
            var updateCommand = _mapper.Map<UpdateGameCommand>(gameViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            var deleteCommand = new DeleteGameCommand(id);
            return await _mediator.SendCommand(deleteCommand);
        }

        public async Task<ValidationResult> Lend(Guid gameId, Guid userId)
        {
            var registerCommand = _mapper.Map<RegisterNewGameCommand>(gameViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
