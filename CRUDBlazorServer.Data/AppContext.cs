using Microsoft.EntityFrameworkCore;

namespace CRUDBlazorServer.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        public DbSet<Dndbook> Dndbooks { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>()
                .HasMany(c => c.Dndbooks)
                .WithOne(e => e.Publisher);
        }
    }
}
