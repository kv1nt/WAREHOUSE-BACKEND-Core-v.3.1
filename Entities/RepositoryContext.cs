using Entities.Models;
using Entities.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Lacation> Locations { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<NavLink> NavLinks { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
