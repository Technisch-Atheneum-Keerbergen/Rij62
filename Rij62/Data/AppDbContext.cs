using Microsoft.EntityFrameworkCore;
using Rij62.Models;
// **********************************
//     *** Database Context  ***
// Author: Xavier Demaerel
// Date: 02/03/2026
// **********************************
namespace Rij62.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Screen> Screens { get; set; }
    }
}