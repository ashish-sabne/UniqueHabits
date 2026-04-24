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
    public class HabitDetailsQueryHandler : HabitQueryCommandHandlerBase<HabitDetailsQuery, HabitModel>
    {
        private readonly HabitsContext _context;
        private readonly IMapper _mapper;
        private readonly IUser _user;
        
        public HabitDetailsQueryHandler(HabitsContext context, IMapper mapper, IUser user) : base(user)
        {
            _context = context;
            _mapper = mapper;
            _user = user;
        }

        public override async Task<HabitModel> Handle(HabitDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var habit = _context.Habits.Include(h => h.Implementations).ThenInclude(i => i.Steps)
                        .Where(IsByCurrentUser).AsQueryable()
                        .FirstOrDefault(h => h.Id == request.HabitId);

                if (habit == null)
                {
                    return null;
                }
                var model = _mapper.Map<HabitModel>(habit);

                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
