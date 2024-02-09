using UniqueHabits.Shared.Enums;

namespace UniqueHabits.Domain.Aggregates
{
    public class Habit
    {
        protected Habit() { }
        private Habit(Guid id, string systemName, string measurableResult, string why, DateTime startDate, HabitCategory category, string categoryDescription)
        {
            Id = id;
            SystemName = systemName;
            MeasurableResult = measurableResult;
            Why = why;
            StartDate = startDate;
            Category = category;
            CategoryDescription = categoryDescription;
            Implementations = new();
        }

        public Guid Id { get; private set; }
        public string SystemName { get; private set; }
        public string MeasurableResult { get; private set; }
        public string Why { get; private set; }
        public DateTime StartDate { get; private set; }
        public HabitCategory Category { get; private set; }
        public string? CategoryDescription { get; private set; }

        public virtual List<Implementation> Implementations { get; private set; } = new();

        public static Habit Create(Guid id, string systemName, string measurableResult, string why, DateTime startDate, HabitCategory category, string categoryDescription)
        {
            return new Habit(id, systemName, measurableResult, why, startDate, category, categoryDescription);
        }

        public void AddImplementation(Implementation implementation)
        {
            Implementations.Add(implementation);
        }
    }
}
