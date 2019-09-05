using Microsoft.EntityFrameworkCore;
using Store.Domain.Models;

namespace Store.Infra.Context
{
    public class StoreContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
    }
}