using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.DomainObjects
{
    public interface IAggregateRoot
    {
        Guid Id { get; set; }
    }
}
