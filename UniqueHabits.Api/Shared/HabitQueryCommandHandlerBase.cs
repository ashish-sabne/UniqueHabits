using MediatR;
using System.Linq.Expressions;
using UniqueHabits.Domain.Aggregates;
using UniqueHabits.Shared.User;

namespace UniqueHabits.Api.Shared
{
    public abstract class HabitQueryCommandHandlerBase
    {
        private readonly IUser _user;

        protected HabitQueryCommandHandlerBase(IUser user)
        {
            _user = user;
        }

        protected Expression<Func<string, bool>> IsByCurrentUser =>
        id => id != null && id == _user.Id.GetValueOrDefault().ToString();
    }
    
    public abstract class HabitQueryHandlerBase<TRequest, TResponse> : HabitQueryCommandHandlerBase, IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected HabitQueryHandlerBase(IUser user) : base(user) {}

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        
    }
    
    public abstract class HabitCommandHandlerBase<TRequest, TResponse> : HabitQueryCommandHandlerBase, IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected HabitCommandHandlerBase(IUser user) : base(user) {}

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

        
    }
    
    public abstract class HabitCommandHandlerBase<TRequest> : HabitQueryCommandHandlerBase, IRequestHandler<TRequest>
        where TRequest : IRequest
    {
        protected HabitCommandHandlerBase(IUser user) : base(user) {}

        public abstract Task Handle(TRequest request, CancellationToken cancellationToken);
    }
}
