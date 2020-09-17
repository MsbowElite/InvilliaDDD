using FluentValidation.Results;
using InvilliaDDD.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvilliaDDD.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : EventMessage;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}
