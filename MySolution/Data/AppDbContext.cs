using Microsoft.EntityFrameworkCore;
using MySolution.Models;

namespace MySolution.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Queue> Queues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sqlite-database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships and constraints based on your schema
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Offices)
                .WithOne(o => o.Employee)
                .IsRequired();

            modelBuilder.Entity<Office>()
                .HasMany(o => o.Positions)
                .WithOne(p => p.Office)
                .IsRequired();

            modelBuilder.Entity<Service>()
                .HasMany(s => s.Appointments)
                .WithOne(a => a.Service)
                .IsRequired();

            modelBuilder.Entity<Position>()
                .HasMany(p => p.Queues)
                .WithOne(q => q.PositionEntity)
                .IsRequired();
        }
    }
}
