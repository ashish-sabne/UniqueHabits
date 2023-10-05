using UniqueHabits.Contracts;

namespace UniqueHabits.Shared
{
    public class HabitState
    {
        public static Habit CurrentHabit { get; set; } = new Habit();
    }
}