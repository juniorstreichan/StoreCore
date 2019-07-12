using System.Collections.Generic;
using Store.Domain.Models;

namespace Store.Domain.Interfaces.Services
{
    public interface IProductService : IService<Product, int>
    {
        IEnumerable<Product> GetProdctsByDescription(string description);
    }
}