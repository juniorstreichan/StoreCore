using Microsoft.EntityFrameworkCore;
using Store.Domain.Models;

namespace Store.Infra.Context
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
    }
}