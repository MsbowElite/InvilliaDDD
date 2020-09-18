using System;
using FluentValidation.Results;
using InvilliaDDD.Core.Communication;
using MediatR;

namespace InvilliaDDD.Core.Messages
{
    public class Command : Message, IRequest<ResponseResult>
    {
        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }

        public ResponseResult ResponseResult { get; set; }

        public virtual bool IsValid()
        {
            return true;
        }
    }
}
