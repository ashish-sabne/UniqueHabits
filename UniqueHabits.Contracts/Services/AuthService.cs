using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UniqueHabits.Contracts.Api;
using UniqueHabits.Contracts.Models;

namespace UniqueHabits.Contracts.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
    }
}
