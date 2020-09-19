using InvilliaDDD.Core.Messages;
using MediatR;
using FluentValidation.Results;
using InvilliaDDD.GameManager.Domain.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System;
using InvilliaDDD.GameManager.Domain.Entities;
using InvilliaDDD.Core.Communication.Mediator;

namespace InvilliaDDD.GameManager.Domain.Commands.Friends
{
    public class FriendCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewFriendCommand, ValidationResult>,
        IRequestHandler<UpdateFriendCommand, ValidationResult>,
        IRequestHandler<DeleteFriendCommand, ValidationResult>
    {
        private readonly IFriendRepository _friendRepository;

        public FriendCommandHandler(IFriendRepository friendRepository, IMediatorHandler mediatorHandler)
            : base(mediatorHandler)
        {
            _friendRepository = friendRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewFriendCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var friend = new Friend(Guid.NewGuid(), request.Name);

            _friendRepository.Add(friend);

            return await Commit(_friendRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateFriendCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var friend = new Friend(request.Id, request.Name);

            _friendRepository.Update(friend);

            return await Commit(_friendRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteFriendCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var friend = await _friendRepository.GetById(request.Id);

            _friendRepository.Delete(friend);

            return await Commit(_friendRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _friendRepository.Dispose();
        }
    }
}
