using UniqueHabits.Contracts;

namespace UniqueHabits.Shared
{
    public class HabitService
    {
        private List<Habit> habits;

        public void AddHabit(Habit habit)
        {
            habits.Add(habit);
        }

        public List<Habit> GetHabits()
        {
            if (habits == null)
                habits = new();
            return habits;
        }
    }
}
