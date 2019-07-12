using System;
using System.Linq;
using System.Linq.Expressions;

namespace Store.Domain.Interfaces.Repository
{
    interface IRepository<T, PK> : IDisposable where T : class
    {
        T Insert(T t);
        T Update(T t);
        T ById(PK id);
        void Delete(PK id);
        IQueryable<T> Find(Expression<Func<T, bool>> expression);

    }
}