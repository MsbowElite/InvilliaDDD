using InvilliaDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.Core.Data.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
