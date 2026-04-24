using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniqueHabits.Api.Queries;
using UniqueHabits.Api.Shared;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Data;
using UniqueHabits.Domain.Aggregates;
using UniqueHabits.Shared.User;

namespace UniqueHabits.Api.QueryHandlers
{
    public class HabitListQueryHandler : HabitQueryCommandHandlerBase<HabitListQuery, List<HabitModel>>
    {
        private readonly HabitsContext _context;
        private readonly IMapper _mapper;
        private readonly IUser _user;
        
        public HabitListQueryHandler(HabitsContext context, IMapper mapper, IUser user) : base(user)
        {
            _context = context;
            _mapper = mapper;
            _user = user;
        }

        public override async Task<List<HabitModel>> Handle(HabitListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var habits = _context.Habits.Include(h => h.Implementations).ThenInclude(i => i.Steps)
                                    .Where(IsByCurrentUser).AsQueryable().ToList();

                if (habits == null || !habits.Any())
                {
                    return null;
                }
                var models = _mapper.Map<List<HabitModel>>(habits);

                return models;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
