using System.ComponentModel.DataAnnotations.Schema;
using UniqueHabits.Shared.Enums;
using UniqueHabits.Shared.User;

namespace UniqueHabits.Domain.Aggregates
{
    public partial class Habit
    {
        protected Habit() { }
        private Habit(Guid id, string systemName, string measurableResult, string why, DateTime startDate, HabitCategory category, 
            string categoryDescription, Guid createdById)
        {
            Id = id;
            SystemName = systemName;
            MeasurableResult = measurableResult;
            Why = why;
            StartDate = startDate;
            Category = category;
            CategoryDescription = categoryDescription;
            Implementations = new();
            CreatedById = createdById.ToString();
        }

        public Guid Id { get; private set; }
        public string SystemName { get; private set; }
        public string MeasurableResult { get; private set; }
        public string? Why { get; private set; }
        public DateTime StartDate { get; private set; }
        public HabitCategory Category { get; private set; }
        public string? CategoryDescription { get; private set; }
        public string? CreatedById { get; private set; }
        [ForeignKey(nameof(CreatedById))]
        public virtual AppUser CreatedBy { get; private set; }

        public virtual List<Implementation> Implementations { get; private set; } = new();

        public static Habit Create(Guid id, string systemName, string measurableResult, string why, DateTime startDate, HabitCategory category, 
            string categoryDescription, Guid createdById)
        {
            return new Habit(id, systemName, measurableResult, why, startDate, category, categoryDescription, createdById);
        }

        public void AddImplementation(Implementation implementation)
        {
            Implementations.Add(implementation);
        }

        public bool IsByCurrentUser(string userId)
        {
            return CreatedById != null && CreatedById.ToLower() == userId.ToLower();
        }
    }
}
