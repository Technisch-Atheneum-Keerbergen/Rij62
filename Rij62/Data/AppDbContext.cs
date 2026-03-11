// **********************************
//     *** Database Context  ***
// Date: 03/03/2026
// File: Data/AppDbContext.cs
// **********************************

using Microsoft.EntityFrameworkCore;
using Rij62.Models;

namespace Rij62.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<LangEntry> Language { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }

    }
}
