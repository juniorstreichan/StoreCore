using Store.Domain.Models;

namespace Store.Domain.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product, int> { }
}