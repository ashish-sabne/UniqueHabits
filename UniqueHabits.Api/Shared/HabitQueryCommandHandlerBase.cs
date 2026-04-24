using MediatR;
using UniqueHabits.Domain.Aggregates;
using UniqueHabits.Shared.User;

namespace UniqueHabits.Api.Shared
{
    public abstract class HabitQueryCommandHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IUser _user;

        protected HabitQueryCommandHandlerBase(IUser user)
        {
            _user = user;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        protected bool IsByCurrentUser(Habit habit)
        {
            return habit.CreatedById != null && habit.CreatedById.ToLower() == _user.Id.GetValueOrDefault().ToString().ToLower();
        }
    }
}
