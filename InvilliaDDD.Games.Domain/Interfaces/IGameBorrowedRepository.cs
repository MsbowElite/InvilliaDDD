using InvilliaDDD.Core.Data.Interfaces;
using InvilliaDDD.GameManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvilliaDDD.GameManager.Domain.Interfaces
{
    public interface IGameBorrowedRepository : IRepository<GameBorrowed>
    {
        Task<IEnumerable<GameBorrowed>> GetAllActive();

        void Add(GameBorrowed gameBorrowed);

        Task<GameBorrowed> GetById(Guid id);

        void Remove(GameBorrowed gameBorrowed);
    }
}
