using InvilliaDDD.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.Data
{
    public interface IRepository<T> : IDisposable
        where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
