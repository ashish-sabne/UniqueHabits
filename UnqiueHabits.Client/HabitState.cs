using UniqueHabits.Contracts.Models;

namespace UnqiueHabits.Client
{
    public class HabitState
    {
        public static HabitModel CurrentHabit { get; set; } = new HabitModel();

        public static void Clear()
        {
            CurrentHabit = new HabitModel();
        }
    }
}