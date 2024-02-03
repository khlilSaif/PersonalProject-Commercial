using dbProject.Models;
using Microsoft.EntityFrameworkCore;
using commercial.Secyrity;

namespace commercial
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Panel> Panels { get; set; }
        public DbSet<AuthenticationToken> AuthenticationTokens { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        // Parameterless constructor or a constructor with a default DbContextOptions
        public DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            // Define any additional configurations or relationships here
        }
    }
}
