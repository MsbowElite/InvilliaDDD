using InvilliaDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace InvilliaDDD.GameManager.Domain.Entities
{
    public partial class Friend : Entity, IAggregateRoot
    {
        public Friend(Guid id, string name)
        {
            Id = id;
            Name = name;

            GameBorrowed = new HashSet<GameBorrowed>();
        }

        protected Friend() 
        {
            GameBorrowed = new HashSet<GameBorrowed>();
        }

        public string Name { get; set; }

        public virtual ICollection<GameBorrowed> GameBorrowed { get; set; }
    }
}
