using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Interfaces.Repository;
using Store.Infra.Context;

namespace Store.Infra.Repository
{
    public abstract class BaseRepository<T> : IRepository<T, int> where T : class
    {
        protected readonly StoreContext _context;
        protected readonly DbSet<T> _db;

        public BaseRepository(StoreContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public T ById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var t = this.ById(id);
            _db.Remove(t);
            _context.SaveChanges();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            return _db.Include(t => t).AsEnumerable();
        }

        public T Insert(T t)
        {
            _db.Add(t);
            _context.SaveChanges();
            return t;
        }

        public T Update(T t)
        {
            _db.Update(t);
            _context.SaveChanges();
            return t;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}