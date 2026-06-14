using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class HabitListQueryHandler : HabitQueryHandlerBase<HabitListQuery, List<HabitModel>>
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
                var habits = await _context.Habits
                        .Where(h => IsByCurrentUser.Compile()(h.CreatedById)) // Built-in C# evaluation
                        .ProjectTo<HabitModel>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                return habits ?? new List<HabitModel>();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
