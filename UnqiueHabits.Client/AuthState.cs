using Blazored.LocalStorage;
using UniqueHabits.Contracts.Models;

namespace UnqiueHabits.Client
{
    public class AuthState
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly ISyncLocalStorageService _syncLocalStorageService;

        public AuthState(ILocalStorageService localStorageService, ISyncLocalStorageService syncLocalStorageService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
        }

        public AuthUserModel? CurrentUser
        {
            get
            {
                if (IsAuthenticated())
                {
                    return _syncLocalStorageService.GetItem<AuthUserModel>("CurrentUser");
                }
                return null;
            }
        }

        public async Task SetAsync(AuthUserModel model)
        {
            await _localStorageService.SetItemAsync("CurrentUser", model);
            await _localStorageService.SetItemAsStringAsync("Token", model.Token);
        }

        public async Task ClearAsync()
        {
            await _localStorageService.RemoveItemsAsync(new[] {"CurrentUser", "Token"});
        }

        public string? GetToken()
        {
            return _syncLocalStorageService.GetItemAsString("Token");
        }

        public bool IsAuthenticated()
        {
            var token = GetToken();
            return !string.IsNullOrEmpty(token);
        }
    }
}
