using MediatR;
using System;

namespace InvilliaDDD.Core.Messages
{
    public abstract class EventMessage : Message, INotification
    {
        /// <summary>
        /// Inicia uma nova instância da classe <see cref="EventMessage"/>.
        /// </summary>
        protected EventMessage()
        {
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Obtém timestamp.
        /// </summary>
        public DateTime Timestamp { get; private set; }
    }
}
