using UniqueHabits.Contracts;

namespace UniqueHabits.Api
{
    public class HabitState
    {
        public static Habit CurrentHabit { get; set; } = new Habit();

        public static void Clear()
        {
            CurrentHabit = new Habit();
        }
    }
}