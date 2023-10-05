namespace UniqueHabit.Domain.Aggregates
{
    public class Habit
    {
        public Habit() {}
        private Habit(Guid id, string what, string why, DateTime startDate, HabitCategory category)
        {
            Id = id;
            What = what;
            Why = why;
            StartDate = startDate;
            Category = category;
        }

        public Guid Id { get; private set; }
        public string What { get; private set; }
        public string Why { get; private set; }
        public DateTime StartDate { get; private set; }
        public HabitCategory Category { get; private set; }

        public static Habit Create(Guid id, string what, string why, DateTime startDate, HabitCategory category)
        {
            return new Habit(id, what, why, startDate, category);
        }
    }
}
