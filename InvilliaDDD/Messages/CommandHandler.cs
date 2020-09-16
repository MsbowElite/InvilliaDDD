using FluentValidation.Results;
using InvilliaDDD.Core.Communication.Mediator;
using InvilliaDDD.Core.Data;
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

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork unitOfWork)
        {
            if (!await unitOfWork?.Commit())
            {
                AdicionarErro("An error persisting the data occurred");
            }

            return ValidationResult;
        }
    }
}
