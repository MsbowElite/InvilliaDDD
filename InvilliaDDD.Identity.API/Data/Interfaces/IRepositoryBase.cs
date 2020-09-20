using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InvilliaDDD.Identity.API.Data.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> ListAll();
        IQueryable<T> ListByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<bool> CheckAnyByConditionAsync(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
