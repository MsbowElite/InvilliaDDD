using InvilliaDDD.Identity.API.Data.Interfaces;
using InvilliaDDD.Identity.API.Entities.Repository;
using InvilliaDDD.Identity.API.Entities.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly IdentityManagerContext _identityManagerContext;
        private IUserRepository _usersRepository;

        public IUserRepository User => _usersRepository ?? (_usersRepository = new UserRepository(_identityManagerContext));


        public RepositoryWrapper(IdentityManagerContext identityManagerContext)
        {
            _identityManagerContext = identityManagerContext;
        }

        public async Task SaveChanges()
        {
            await _identityManagerContext.SaveChangesAsync();
        }
    }
}
