using InvilliaDDD.Identity.API.Entities.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Data.Interfaces
{
    public interface IRepositoryWrapper
    {
        Task SaveChanges();
        IUserRepository User { get; }
    }
}
