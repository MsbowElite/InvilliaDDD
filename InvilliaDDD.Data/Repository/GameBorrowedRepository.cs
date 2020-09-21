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
    public class GameBorrowedRepository : RepositoryBase<GameBorrowed>, IGameBorrowedRepository
    {
        public GameBorrowedRepository(GameManagerContext applicationDbContext)
    : base(applicationDbContext)
        {
        }

        public async Task<IEnumerable<GameBorrowed>> GetAllActive()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<GameBorrowed> GetById(Guid id)
        {
            return await FindByCondition(f => f.GameId == id).SingleOrDefaultAsync();
        }

        public void Add(GameBorrowed gameBorrowed)
        {
            BaseAdd(gameBorrowed);
        }

        public void Remove(GameBorrowed gameBorrowed)
        {
            BaseRemove(gameBorrowed);
        }
    }
}
