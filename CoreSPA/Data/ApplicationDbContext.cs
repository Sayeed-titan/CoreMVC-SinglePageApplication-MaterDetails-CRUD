using CoreSPA.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreSPA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                               .HasMany(c => c.Products)
                               .WithOne(p => p.Category)
                               .HasForeignKey(p => p.CategoryId)
                               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                               .HasMany(p => p.Features)
                               .WithOne(f => f.Product)
                               .HasForeignKey(p => p.ProductId)
                               .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}
