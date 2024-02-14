using System.Net.Http.Json;
using UniqueHabits.Contracts.Api;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Shared.Helpers;

namespace UniqueHabits.Contracts.Services
{
    public class HabitService
    {
        private readonly HttpClient _httpClient;

        public HabitService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResult<List<HabitModel>>> GetHabits()
        {
            try
            {
                var habits = await _httpClient.GetFromJsonAsync<List<HabitModel>>("api/Habits");
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
                var habit = await _httpClient.GetFromJsonAsync<HabitModel>($"api/Habits/{habitId}");

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
                var result = await _httpClient.PostAsJsonAsync("api/habits", habit);

                if (result != null)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return ApiResult.Success();
                    }
                    else
                    {
                        return ApiResult.Failure($"Error adding habit: {result.ReasonPhrase}");
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
