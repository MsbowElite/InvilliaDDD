using InvilliaDDD.Core.Data.Interfaces;
using InvilliaDDD.GameManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvilliaDDD.GameManager.Domain.Interfaces
{
    public interface IFriendRepository : IRepository<Friend>
    {
        Task<IEnumerable<Friend>> GetAllActive();

        Task<Friend> GetById(Guid id);

        void Add(Friend friend);

        void Update(Friend friend);

        void Delete(Friend friend);
    }
}
