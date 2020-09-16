using FluentValidation.Results;
using InvilliaDDD.Communication.Mediator;
using InvilliaDDD.Data;
using System.Threading.Tasks;

namespace InvilliaDDD.Messages
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
