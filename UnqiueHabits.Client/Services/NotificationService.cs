using UniqueHabits.Contracts.Api;
using UniqueHabits.Contracts.Models;
using UnqiueHabits.Client;
using UnqiueHabits.Client.Helpers;

namespace UniqueHabits.Client.Services
{
    public class NotificationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthState _authState;

        public NotificationService(HttpClient httpClient, AuthState authState)
        {
            _httpClient = httpClient;
            _authState = authState;
        }

        public async Task<ApiResult<List<NotificationModel>>> GetMyNotifications()
        {
            try
            {
                var habits = await _httpClient.GetWithTokenAsync<List<NotificationModel>>
                                    ("api/notifications", _authState.GetToken());
                
                if (habits != null)
                {
                    return ApiResult<List<NotificationModel>>.Success(habits);
                }
                else
                {
                    return ApiResult<List<NotificationModel>>.Failure();
                }
            }
            catch (Exception ex)
            {
                return ApiResult< List<NotificationModel>>.Failure(ex.Message);
            }
        }

        public async Task<ApiResult> MarkAsRead(Guid notiticationId)
        {
            try
            {
                var result = await _httpClient.PostWithTokenAsync($"api/notifications/{notiticationId}/mark-as-read",
                    _authState.GetToken());

                if (result != null)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return ApiResult.Success();
                    }
                    else
                    {
                        var a = await result.Content.ReadAsStringAsync();
                        return ApiResult.Failure(result.ReasonPhrase);
                    }
                }
                return ApiResult.Failure();
            }
            catch (Exception ex)
            {
                return ApiResult.Failure(ex.Message);
            }
        }
    }
}
