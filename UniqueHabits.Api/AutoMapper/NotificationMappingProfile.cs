using AutoMapper;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Domain.Aggregates;

namespace UniqueHabits.Api.AutoMapper
{
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Notification, NotificationModel>();
        }
    }
}
