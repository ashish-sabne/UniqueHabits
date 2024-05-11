using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniqueHabits.Data.Seed;
using UniqueHabits.Domain.Aggregates;
using UniqueHabits.Shared.Enums;

namespace UniqueHabits.Data
{
    public class HabitsContext : IdentityDbContext<AppUser>
    {
        public HabitsContext(DbContextOptions<HabitsContext> options) : base(options)
        {
        }

        public DbSet<Habit> Habits { get; set; }
        public DbSet<Implementation> Implementations { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Habit>().HasMany(h => h.Implementations).WithOne(i => i.Habit).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Habit>().Property(h => h.Category)
                .HasConversion(new EnumToStringConverter<HabitCategory>());

            modelBuilder.Entity<Implementation>().Property(h => h.CustomizationCategory)
                .HasConversion(new EnumToStringConverter<CustomizationCategory>());
            modelBuilder.Entity<Implementation>().HasOne(i => i.PreviousImplementation).WithOne().IsRequired(false);
            modelBuilder.Entity<Implementation>().HasMany(i => i.Steps).WithOne().OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Habit>().Seed();
            modelBuilder.Entity<Habit>().HasOne(h => h.CreatedBy).WithMany().OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Implementation>().Seed();

            modelBuilder.Entity<ImplementationStep>().Seed();

            modelBuilder.Entity<AppUser>().Seed();

            modelBuilder.Entity<Notification>().Property(n => n.NotificationType)
                .HasConversion(new EnumToStringConverter<NotificationType>());

            modelBuilder.Entity<Notification>().HasOne(n => n.Habit).WithMany();
            modelBuilder.Entity<Notification>().HasOne(n => n.CreatedBy).WithMany(au => au.Notifications);
        }
    }
}