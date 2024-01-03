using AutoMapper;
using UniqueHabits.Contracts;
using UniqueHabits.Domain.Aggregates;

namespace UniqueHabits.Api.AutoMapper
{
    public class HabitMappingProfile :Profile
    {
        public HabitMappingProfile()
        {
            CreateMap<Habit, HabitModel>();
            CreateMap<Domain.Aggregates.ImplementationDetails, Contracts.ImplementationDetails>();
        }
    }
}
