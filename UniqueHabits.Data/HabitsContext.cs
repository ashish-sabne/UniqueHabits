using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniqueHabits.Data.Seed;
using UniqueHabits.Domain.Aggregates;
using UniqueHabits.Shared.Enums;

namespace UniqueHabits.Data
{
    public class HabitsContext : DbContext
    {
        public HabitsContext(DbContextOptions<HabitsContext> options) : base(options)
        {
        }

        public DbSet<Habit> Habits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Habit>().OwnsOne(h => h.ImplementationDetails).WithOwner();

            modelBuilder.Entity<Habit>().Property(h => h.Category)
                .HasConversion(new EnumToStringConverter<HabitCategory>());

            modelBuilder.Entity<Habit>().Seed();
            modelBuilder.Entity<Habit>().OwnsOne(h => h.ImplementationDetails).Seed();
        }
    }
}