using InvilliaDDD.Core.Data;
using InvilliaDDD.Core.Data.Interfaces;
using InvilliaDDD.GameManager.Domain.Entities;
using InvilliaDDD.GameManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.GameManager.Data.Repository
{
    public class FriendRepository : RepositoryBase<Friend>, IFriendRepository
    {
        public FriendRepository(GameManagerContext applicationDbContext)
    : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<Friend>> GetAllActive()
        {
            return await GetAll().Where(g => !g.DeletedAt.HasValue).OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<Friend> GetById(Guid id)
        {
            return await FindByCondition(f => f.Id == id).SingleOrDefaultAsync();
        }

        public void Add(Friend friend)
        {
            friend.CreatedAt = DateTime.UtcNow;
            BaseAdd(friend);
        }

        public void Update(Friend friend)
        {
            friend.UpdatedAt = DateTime.UtcNow;
            BaseUpdate(friend);
        }

        public void Delete(Friend friend)
        {
            friend.DeletedAt = DateTime.UtcNow;
            BaseUpdate(friend);
        }
    }
}
