using InvilliaDDD.Core.Messages;
using MediatR;
using FluentValidation.Results;
using InvilliaDDD.GameManager.Domain.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System;
using InvilliaDDD.GameManager.Domain.Entities;
using InvilliaDDD.Core.Communication.Mediator;

namespace InvilliaDDD.GameManager.Domain.Commands.Games
{
    public class GameCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewGameCommand, ValidationResult>,
        IRequestHandler<UpdateGameCommand, ValidationResult>,
        IRequestHandler<DeleteGameCommand, ValidationResult>,
        IRequestHandler<LendGameCommand, ValidationResult>,
        IRequestHandler<TakeGameCommand, ValidationResult>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGameBorrowedRepository _gameBorrowedRepository;

        public GameCommandHandler(IGameRepository gameRepository, IGameBorrowedRepository gameBorrowedRepository, IMediatorHandler mediatorHandler)
            : base(mediatorHandler)
        {
            _gameRepository = gameRepository;
            _gameBorrowedRepository = gameBorrowedRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewGameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var game = new Game(Guid.NewGuid(), request.Name);

            _gameRepository.Add(game);

            return await Commit(_gameRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var game = new Game(request.Id, request.Name);

            _gameRepository.Update(game);

            return await Commit(_gameRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var game = await _gameRepository.GetById(request.Id);

            _gameRepository.Delete(game);

            return await Commit(_gameRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(LendGameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var gameBorrowed = new GameBorrowed(request.Id, request.FriendId);
            _gameBorrowedRepository.Add(gameBorrowed);

            return await Commit(_gameRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(TakeGameCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            _gameBorrowedRepository.Remove(await _gameBorrowedRepository.GetById(request.Id));

            return await Commit(_gameRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _gameRepository.Dispose();
        }
    }
}
