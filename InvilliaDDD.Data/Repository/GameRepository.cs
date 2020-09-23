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
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(GameManagerContext applicationDbContext)
    : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<Game>> GetAllActive()
        {
            return await GetAll()
                .Include(g => g.GameBorrowed)
                .Where(g => !g.DeletedAt.HasValue).OrderByDescending(o => o.CreatedAt).ToListAsync();
        }

        public async Task<Game> GetById(Guid id)
        {
            return await FindByCondition(f => f.Id == id)
                .Include(g => g.GameBorrowed)
                .Include(g => g.GameBorrowed.Friend).SingleOrDefaultAsync();
        }

        public void Add(Game game)
        {
            game.CreatedAt = DateTime.UtcNow;
            BaseAdd(game);
        }

        public void Update(Game game)
        {
            game.UpdatedAt = DateTime.UtcNow;
            BaseUpdate(game);
        }

        public void Delete(Game game)
        {
            game.DeletedAt = DateTime.UtcNow;
            BaseUpdate(game);
        }
    }
}
