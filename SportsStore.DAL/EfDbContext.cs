using System.Data.Entity;

namespace SportsStore.DAL
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
