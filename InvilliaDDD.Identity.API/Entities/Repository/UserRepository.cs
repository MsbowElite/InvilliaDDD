using InvilliaDDD.Identity.API.Data;
using InvilliaDDD.Identity.API.Entities.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Entities.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IdentityManagerContext identityManagerContext)
            : base(identityManagerContext)
        {
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await ListAll().OrderByDescending(o => o.CreatedAt).ToListAsync();
            return users.OrderBy(x => x.Id);
        }

        public async Task<User> GetUserAuthenticateAsync(string username, string password)
        {
            return await ApplicationDbContext.User.Include(user => user.UserRoles)
                .SingleOrDefaultAsync(o => o.Username == username && o.Password == password);
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var user = await FindByCondition(o => o.Id.Equals(userId)).SingleOrDefaultAsync();
            return user;
        }

        public async Task<bool> CheckUserByIdAsync(Guid userId)
        {
            return await CheckAnyByConditionAsync(c => c.Id == userId);
        }

        public async Task CreateUser(User user)
        {
            user.CreatedAt = DateTime.Now;
            Create(user);
            await SaveAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            user.UpdatedAt = DateTime.Now;
            Update(user);
            await SaveAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            user.DeletedAt = DateTime.Now;
            Update(user);
            await SaveAsync();
        }
    }
}
