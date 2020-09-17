using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity()
        {
        }
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
