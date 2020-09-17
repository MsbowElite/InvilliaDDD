using InvilliaDDD.Core.Data.Interfaces;
using InvilliaDDD.GameManager.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvilliaDDD.Core.Data
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly GameManagerContext _applicationDbContext;
        private bool _disposedValue;

        protected RepositoryBase(GameManagerContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IQueryable<T> ListAll()
        {
            return _applicationDbContext.Set<T>();
        }

        public IQueryable<T> ListByCondition(Expression<Func<T, bool>> expression)
        {
            return _applicationDbContext.Set<T>().Where(expression);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _applicationDbContext.Set<T>().Where(expression);
        }

        public async Task<bool> CheckAnyByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _applicationDbContext.Set<T>().AnyAsync(expression);
        }

        public void BaseAdd(T entity)
        {
            _applicationDbContext.Set<T>().Add(entity);
        }

        public void BaseUpdate(T entity)
        {
            this._applicationDbContext.Set<T>().Update(entity);
        }

        public void BaseRemove(T entity)
        {
            this._applicationDbContext.Set<T>().Remove(entity);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _applicationDbContext?.Dispose();
                _disposedValue = true;
            }
        }
    }
}
