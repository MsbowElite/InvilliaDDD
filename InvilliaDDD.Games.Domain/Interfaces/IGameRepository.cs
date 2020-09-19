using InvilliaDDD.Core.Data.Interfaces;
using InvilliaDDD.GameManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvilliaDDD.GameManager.Domain.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<IEnumerable<Game>> GetAllActive();

        Task<Game> GetById(Guid id);

        void Add(Game game);

        void Update(Game game);

        void Delete(Game game);
    }
}
