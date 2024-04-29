using Microsoft.AspNetCore.Http;

namespace UniqueHabits.Shared.User
{
    public class CurrentUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public CurrentUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        private string _id => _accessor?.HttpContext?.User?.FindFirst("id")?.Value ?? "";

        public Guid? Id => string.IsNullOrEmpty(_id) ? null : Guid.Parse(_id);
        public string Name => _accessor.HttpContext.User?.Identity?.Name ?? "";
        public bool IsAuthenticated => _accessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
