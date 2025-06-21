using Microsoft.EntityFrameworkCore;
using StickerShopCMS.Models;

namespace StickerShopCMS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<SaleItem> SaleItems { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("product"); 
            modelBuilder.Entity<Inventory>().ToTable("inventory");
        }
        
    }
}
