using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Interfaces.Repository;
using Store.Domain.Models;
using Store.Infra.Context;

namespace Store.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        private readonly DbSet<Product> _db;
        public ProductRepository(StoreContext ctx)
        {
            _context = ctx;
            _db = ctx.Product;
        }
        public Product ById(int id)
        {
            return _db.Include("Tags").Include("Provider").FirstOrDefault(
                p => p.Id == id
            );
        }

        public void Delete(int id)
        {
            var product = this.ById(id);
            _db.Remove(product);
            _context.SaveChanges();
        }

        public IQueryable<Product> Find(Expression<Func<Product, bool>> expression)
        {
            return _db.Include("Tags").Include("Provider").Where(expression);
        }

        public IEnumerable<Product> FindAll()
        {
            return _db.Include("Tags").Include("Provider").ToList();
        }

        public Product Insert(Product p)
        {
            var newProduct = _db.Add(p);
            _context.SaveChanges();
            return newProduct.Entity;
        }

        public Product Update(Product p)
        {
            var newProduct = _db.Update(p);
            _context.SaveChanges();
            return newProduct.Entity;
        }
    }
}