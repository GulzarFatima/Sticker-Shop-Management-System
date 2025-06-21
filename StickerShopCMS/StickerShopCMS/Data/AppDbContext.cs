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
            modelBuilder.Entity<Inventory>().ToTable("inventory", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Product>().ToTable("product", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Sale>().ToTable("sale", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<SaleItem>().ToTable("sale_item", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Product>().ToTable("product"); 
            modelBuilder.Entity<Inventory>().ToTable("inventory");
        }
        
    }
}
