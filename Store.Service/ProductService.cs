using System.Collections.Generic;
using Store.Domain.Interfaces.Repository;
using Store.Domain.Interfaces.Services;
using Store.Domain.Models;

namespace Store.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository repo)
        {
            repository = repo;
        }
        public Product Add(Product p)
        {
            return repository.Insert(p);
        }

        public Product Change(Product p)
        {
            return repository.Update(p);
        }

        public IEnumerable<Product> GetAll()
        {
            return repository.FindAll();
        }

        public Product GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetProdctsByDescription(string description)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}