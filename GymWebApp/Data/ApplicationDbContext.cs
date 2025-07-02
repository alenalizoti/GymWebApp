using GymWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Training>()
                .Property(t => t.duration)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Trainer>()
                .HasMany(t => t.Trainings)
                .WithMany(t => t.Trainers)
                .UsingEntity(j => j.ToTable("Trainers_Trainings"));

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Training)
                .WithMany(r => r.Reservations)
                .HasForeignKey(r => r.TrainingId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Trainer)
                .WithMany(t => t.Reviews)
                .HasForeignKey(r => r.TrainerId);

        }
    }
}
