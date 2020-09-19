using AutoMapper;
using FluentValidation.Results;
using InvilliaDDD.Core.Communication.Mediator;
using InvilliaDDD.GameManager.Application.Interfaces;
using InvilliaDDD.GameManager.Application.ViewModels;
using InvilliaDDD.GameManager.Domain.Commands.Friends;
using InvilliaDDD.GameManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvilliaDDD.GameManager.Application.Services
{
    public class FriendAppService : IFriendAppService
    {
        private readonly IMapper _mapper;
        private readonly IFriendRepository _friendRepository;
        private readonly IMediatorHandler _mediator;

        public FriendAppService(IMapper mapper,
                          IFriendRepository friendRepository,
                          IMediatorHandler mediator)
        {
            _mapper = mapper;
            _friendRepository = friendRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<FriendViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<FriendViewModel>>(await _friendRepository.GetAllActive());
        }


        public async Task<FriendViewModel> GetById(Guid id)
        {
            return _mapper.Map<FriendViewModel>(await _friendRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(FriendViewModel friendViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewFriendCommand>(friendViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(FriendViewModel friendViewModel)
        {
            var updateCommand = _mapper.Map<UpdateFriendCommand>(friendViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            var deleteCommand = new DeleteFriendCommand(id);
            return await _mediator.SendCommand(deleteCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
