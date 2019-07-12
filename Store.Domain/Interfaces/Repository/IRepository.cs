using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Domain.Interfaces.Repository
{
    public interface IRepository<T, PK>
    {
        T Insert(T t);
        T Update(T t);
        T ById(PK id);
        void Delete(PK id);
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> FindAll();

    }
}