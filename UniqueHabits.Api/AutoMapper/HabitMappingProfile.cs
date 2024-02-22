using AutoMapper;
using UniqueHabits.Contracts.Models;
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
                .ForMember(dest => dest.Steps, opt => opt.MapFrom(src => src.Steps.OrderBy(s => s.Sequence)));

            CreateMap<Domain.Aggregates.ImplementationStep, Contracts.Models.ImplementationStep>();

            CreateMap<Habit, HabitReviewModel>()
                .ForMember(dest => dest.LastImplementationDate, opt => opt.MapFrom(src => src.Implementations.OrderByDescending(i => i.CreatedDate).FirstOrDefault().CreatedDate));
        }
    }
}
