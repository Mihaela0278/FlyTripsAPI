using Microsoft.EntityFrameworkCore;

namespace FlyTrips.Entities
{
    public class FlyTripsDbContext : DbContext
    {
        public DbSet<Airline> Airlines { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public FlyTripsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // make Role unique 
            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            // make Airline names unique  
            modelBuilder.Entity<Airline>()
                .HasIndex(a => a.Name)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
