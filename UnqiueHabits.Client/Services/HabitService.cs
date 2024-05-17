using UniqueHabits.Contracts.Api;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Shared.Constants;
using UniqueHabits.Shared.Helpers;
using UnqiueHabits.Client;
using UnqiueHabits.Client.Helpers;

namespace UniqueHabits.Client.Services
{
    public class HabitService
    {
        private readonly HttpClient _httpClient;

        private string _authToken;
        public HabitService(HttpClient httpClient, AuthState authState)
        {
            _httpClient = httpClient;
            _authToken = authState.GetToken();
        }

        public async Task<ApiResult<List<HabitModel>>> GetHabits()
        {
            try
            {
                var habits = await _httpClient.GetWithTokenAsync<List<HabitModel>>("api/habits", _authToken);
                if (habits.IsAny())
                {
                    return ApiResult<List<HabitModel>>.Success(habits);
                }
                else if (habits != null)
                {
                    return ApiResult<List<HabitModel>>.Success(new List<HabitModel>());
                }
                else
                {
                    return ApiResult<List<HabitModel>>.Failure();
                }
            }
            catch (Exception ex)
            {
                return ApiResult<List<HabitModel>>.Failure(ex.Message);
            }
        }

        public async Task<ApiResult<HabitModel>> GetHabit(Guid habitId)
        {
            try
            {
                var habit = await _httpClient.GetWithTokenAsync<HabitModel>($"api/habits/{habitId}", _authToken);

                if (habit != null)
                {
                    return ApiResult<HabitModel>.Success(habit);
                }
                else
                {
                    return ApiResult<HabitModel>.Failure("Habit not found!");
                }
            }
            catch (Exception ex)
            {
                return ApiResult<HabitModel>.Failure(ex.Message);
            }
        }

        public async Task<ApiResult> AddHabit(HabitModel habit)
        {
            try
            {
                var result = await _httpClient.PostWithTokenAsync("api/habits", habit, _authToken);

                if (result != null)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return ApiResult.Success();
                    }
                    else
                    {
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

        public async Task<ApiResult<HabitReviewModel>> ReviewHabit(Guid habitId)
        {
            try
            {
                var habit = await _httpClient.GetWithTokenAsync<HabitReviewModel>($"api/habits/{habitId}/review", _authToken);

                if (habit != null)
                {
                    var days = (DateTime.Today - habit.LastImplementationDate).Days;
                    if (days < SettingConstants.SprintLengthInDays)
                    {
                        return ApiResult<HabitReviewModel>.Failure(
                            $"Habit not ready for review until {habit.LastImplementationDate.AddDays(SettingConstants.SprintLengthInDays):MMM d, yyy}.");
                    }
                    return ApiResult<HabitReviewModel>.Success(habit);
                }
                else
                {
                    return ApiResult<HabitReviewModel>.Failure("Habit not found!");
                }
            }
            catch (Exception ex)
            {
                return ApiResult<HabitReviewModel>.Failure(ex.Message);
            }
        }

        public async Task<ApiResult> AddHabitReview(HabitReviewModel review)
        {
           try
            {
                var result = await _httpClient.PostWithTokenAsync($"api/habits/{review.Id}/review", review, _authToken);

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
