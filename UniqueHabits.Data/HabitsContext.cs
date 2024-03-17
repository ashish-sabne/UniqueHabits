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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Habit>().OwnsMany(h => h.Implementations).Property(h => h.CustomizationCategory)
                .HasConversion(new EnumToStringConverter<CustomizationCategory>());
            modelBuilder.Entity<Habit>().OwnsMany(h => h.Implementations).OwnsMany(i => i.Steps);

            modelBuilder.Entity<Habit>().Property(h => h.Category)
                .HasConversion(new EnumToStringConverter<HabitCategory>());

            /*modelBuilder.Entity<Implementation>().Property(h => h.CustomizationCategory)
                .HasConversion(new EnumToStringConverter<CustomizationCategory>());*/

            modelBuilder.Entity<Habit>().Seed();
            
            modelBuilder.Entity<Habit>().OwnsMany(h => h.Implementations).Seed();

            modelBuilder.Entity<Habit>().OwnsMany(h => h.Implementations).OwnsMany(i => i.Steps).Seed();
        }
    }
}