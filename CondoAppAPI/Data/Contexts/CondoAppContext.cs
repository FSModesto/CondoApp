using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class CondoAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-7AIGREN\\SQLEXPRESS;Database=CondoApp;Trusted_Connection=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Message>().ToTable("Messages");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");
            modelBuilder.Entity<Service>().ToTable("Services");
        }
    }
}
