using AutoMapper;
using UniqueHabits.Contracts;
using UniqueHabits.Domain.Aggregates;

namespace UniqueHabits.Api.AutoMapper
{
    public class HabitMappingProfile :Profile
    {
        public HabitMappingProfile()
        {
            CreateMap<Habit, HabitModel>()
                .ForMember(dest => dest.ImplementationDetails, opt => opt.MapFrom(src => src.Implementations.OrderByDescending(i => i.CreatedDate).FirstOrDefault()));
            
            CreateMap<Implementation, ImplementationDetails>()
                .ForMember(dest => dest.How, opt => opt.MapFrom(src => string.Join("\n", src.Steps.Select(s => s.Step))));

            CreateMap<Domain.Aggregates.ImplementationStep, Contracts.ImplementationStep>();
        }
    }
}
