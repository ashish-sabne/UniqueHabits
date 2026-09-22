using MediatR;
using UniqueHabits.Contracts.Models;

namespace UniqueHabits.Contracts.Commands
{
    public class AddHabitCommand : IRequest<HabitModel>
    {
        public HabitModel Habit { get; set; } = new();
    }
}
