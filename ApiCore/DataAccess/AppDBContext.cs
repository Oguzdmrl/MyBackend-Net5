using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}