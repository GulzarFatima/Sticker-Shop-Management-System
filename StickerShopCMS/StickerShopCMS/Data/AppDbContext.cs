using Microsoft.EntityFrameworkCore;
using StickerShopCMS.Models;
using System.Collections.Generic;

namespace StickerShopCMS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
