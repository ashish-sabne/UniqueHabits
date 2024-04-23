using UniqueHabits.Contracts.Models;

namespace UnqiueHabits.Client
{
    public class AuthState
    {
        public static AuthUserModel? CurrentUser { get; set; } = null;

        public static void Clear()
        {
            CurrentUser = null;
        }
    }
}
