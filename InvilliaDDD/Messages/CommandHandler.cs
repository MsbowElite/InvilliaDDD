using FluentValidation.Results;
using InvilliaDDD.Core.Communication.Mediator;
using InvilliaDDD.Core.Data;
using InvilliaDDD.Core.Data.Interfaces;
using System.Threading.Tasks;

namespace InvilliaDDD.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        public CommandHandler(IMediatorHandler mediatorHandler)
        {
            MediatorHandler = mediatorHandler;
            ValidationResult = new ValidationResult();
        }

        protected IMediatorHandler MediatorHandler { get; private set; }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork unitOfWork)
        {
            if (!await unitOfWork?.Commit())
            {
                AddError("An error persisting the data occurred");
            }

            return ValidationResult;
        }
    }
}
