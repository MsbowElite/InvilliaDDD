using InvilliaDDD.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.GameManager.Domain.Commands.Friends
{
    public class FriendCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
    }
}
