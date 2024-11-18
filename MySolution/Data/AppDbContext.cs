using Microsoft.EntityFrameworkCore;
using MySolution.Models;

namespace MySolution.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Queue> Queues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=sqlite-database.db")
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Employee -> Offices (1-to-Many)
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Offices)
                .WithOne(o => o.Employee)
                .HasForeignKey(o => o.EmployeeId)
                .IsRequired(false); // Employee might not have an office


            // Queue -> Appointment relationship (Many-to-One)
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Queue)
                .WithOne() 
                .HasForeignKey<Appointment>(a => a.QueueId)
                .IsRequired(true);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Desk) 
                .WithOne() 
                .HasForeignKey<Appointment>(a => a.DeskId)
                .IsRequired(true);

            // Queue entity constraints
            modelBuilder.Entity<Queue>()
                .Property(q => q.Status)
                .IsRequired();

            // Additional configurations (table names)
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Office>().ToTable("Offices");
            modelBuilder.Entity<Desk>().ToTable("Desks");
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<Queue>().ToTable("Queues");
        }
    }
}
