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
    public class HabitDetailsQueryHandler : HabitQueryHandlerBase<HabitDetailsQuery, HabitModel>
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
                return await _context.Habits
                .Where(h => h.Id == request.HabitId)
                .Where(h => IsByCurrentUser.Compile()(h.CreatedById)) // Built-in C# evaluation
                                                                             // Better yet, apply it directly to the entity if you update the expression type:
                .ProjectTo<HabitModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
