using FluentValidation.Results;
using InvilliaDDD.Core.Communication;
using InvilliaDDD.Core.Communication.Mediator;
using InvilliaDDD.Core.Data;
using InvilliaDDD.Core.Data.Interfaces;
using System.Threading.Tasks;

namespace InvilliaDDD.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ResponseResult ResponseResult;

        public CommandHandler(IMediatorHandler mediatorHandler)
        {
            MediatorHandler = mediatorHandler;
            ResponseResult = new ResponseResult();
        }

        protected IMediatorHandler MediatorHandler { get; private set; }

        protected void AddError(string mensagem)
        {
            ResponseResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ResponseResult> Commit(IUnitOfWork unitOfWork)
        {
            if (!await unitOfWork?.Commit())
            {
                AddError("An error persisting the data occurred");
            }

            return ResponseResult;
        }
    }
}
