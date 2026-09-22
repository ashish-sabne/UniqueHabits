using MediatR;
using UniqueHabits.Contracts.Models;

namespace UniqueHabits.Contracts.Queries
{
    public class HabitDetailsQuery : IRequest<HabitModel>
    {
        public Guid HabitId { get; set; }
    }
}
