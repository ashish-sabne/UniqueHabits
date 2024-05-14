using AutoMapper;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Domain.Aggregates;

namespace UniqueHabits.Api.AutoMapper
{
    public class UserMappingProfile :Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AppUser, AuthUserModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));
        }
    }
}
