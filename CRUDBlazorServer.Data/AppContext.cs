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
            modelBuilder.Entity<Dndbook>()
                .HasOne(c => c.Publisher)
                .WithMany(e => e.Dndbooks);

            modelBuilder.Entity<Publisher>().HasData(new Publisher {Id = 1, Name = "Wizards of the Coast" });
        }
    }
}
