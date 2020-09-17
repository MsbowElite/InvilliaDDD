﻿using InvilliaDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvilliaDDD.Core.Data.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> ListAll();
        IQueryable<T> ListByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<bool> CheckAnyByConditionAsync(Expression<Func<T, bool>> expression);
        void BaseAdd(T entity);
        void BaseUpdate(T entity);
        void BaseRemove(T entity);
    }
}
