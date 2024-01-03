using UniqueHabits.Contracts;

namespace UnqiueHabits.Client.Services
{
    public class HabitService
    {
        private List<HabitModel> habits;

        public void AddHabit(HabitModel habit)
        {
            habits.Add(habit);
        }

        public List<HabitModel> GetHabits()
        {
            if (habits == null)
                habits = new();
            return habits;
        }
    }
}
