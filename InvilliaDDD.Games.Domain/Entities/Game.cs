using InvilliaDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace InvilliaDDD.GameManager.Domain.Entities
{
    public partial class Game : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
