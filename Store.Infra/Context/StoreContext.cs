using Microsoft.EntityFrameworkCore;
using Store.Domain.Models;

namespace Store.Infra.Context
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
    }
}