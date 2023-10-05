using UniqueHabit.Domain.Aggregates;

namespace UniqueHabits.Data
{
    public interface IHabitService
    {
        IEnumerable<Habit> GetHabits();
        void AddHabit(Habit habit);
    }
}
