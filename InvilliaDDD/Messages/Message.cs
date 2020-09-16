using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.Messages
{
    public abstract class Message
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public string MessageType { get; set; }

        public Guid AggregateId { get; set; }
    }
}
