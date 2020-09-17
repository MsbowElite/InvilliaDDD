using InvilliaDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace InvilliaDDD.GameManager.Domain.Entities
{
    public partial class Game : Entity, IAggregateRoot
    {
        public Game(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        protected Game() { }

        public string Name { get; set; }
    }
}
