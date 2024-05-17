using System.Net.Http.Json;
using UniqueHabits.Contracts.Api;
using UniqueHabits.Contracts.Models;
using UnqiueHabits.Client;
using UnqiueHabits.Client.Helpers;

namespace UniqueHabits.Client.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthState _authState;

        public AuthService(HttpClient httpClient, AuthState authState)
        {
            _httpClient = httpClient;
            _authState = authState;
        }

        public async Task<ApiResult> Register(RegisterModel model)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("api/register", model);

                if (result != null)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return ApiResult.Success();
                    }
                    else
                    {
                        var contents = await result.Content.ReadAsStringAsync();
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
        
        

        public async Task<ApiResult<AuthUserModel>> Login(LoginModel model)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("api/login", model);

                if (result != null)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var authData = await result.Content.ReadFromJsonAsync<AuthUserModel>();
                        if (authData != null)
                        {
                            await _authState.SetAsync(authData);
                            return ApiResult<AuthUserModel>.Success(authData);
                        }
                    }
                    else
                    {
                        var contents = await result.Content.ReadAsStringAsync();
                        return ApiResult<AuthUserModel>.Failure("Invalid email and/or password");
                    }
                }
                return ApiResult<AuthUserModel>.Failure("Unknown error occurred! Please try again!");
            }
            catch (Exception ex)
            {
                return ApiResult<AuthUserModel>.Failure(ex.Message);
            }
        }
        
        public async Task<ApiResult> UpdatePreferences(AuthUserModel model)
        {
            try
            {
                var result = await _httpClient.PutWithTokenAsync("api/user", model, _authState.GetToken());

                if (result != null)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        await _authState.ClearAsync();
                        await _authState.SetAsync(model);
                        return ApiResult.Success();
                    }
                    else
                    {
                        var contents = await result.Content.ReadAsStringAsync();
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
