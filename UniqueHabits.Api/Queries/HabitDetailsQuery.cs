using MediatR;
using UniqueHabits.Contracts.Models;

namespace UniqueHabits.Api.Queries
{
    public class HabitDetailsQuery : IRequest<HabitModel>
    {
        public Guid HabitId { get; set; }
    }
}
