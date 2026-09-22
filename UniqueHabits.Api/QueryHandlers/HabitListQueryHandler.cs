using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UniqueHabits.Api.Shared;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Contracts.Queries;
using UniqueHabits.Data;
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
                var habitsQueryable =_context.Habits.Include(h => h.Implementations).ThenInclude(i => i.Steps);

                var query = habitsQueryable.ToQueryString();

                var habits = await habitsQueryable.ToListAsync(cancellationToken);

                return _mapper.Map<List<HabitModel>>(habits);

                //return await habitsQueryable.ProjectTo<HabitModel>(_mapper.ConfigurationProvider).ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
