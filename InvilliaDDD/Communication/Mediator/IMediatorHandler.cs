using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvilliaDDD.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento)
            where T : EventMessage;

        Task<ValidationResult> EnviarComando<T>(T comando)
            where T : Command;

        Task PublicarNotificacao<T>(T notificacao)
            where T : DomainNotification;

        Task PublicarEventoDeDominio<T>(T evento)
            where T : DomainEvent;
    }
}
