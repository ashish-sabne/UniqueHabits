using System.Net.Http.Json;
using UniqueHabits.Contracts.Models;

namespace UniqueHabits.Contracts.Services
{
    public class HabitService
    {
        private readonly HttpClient _httpClient;

        public HabitService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<HabitModel>> GetHabits()
        {
            try
            {
                var habits = await _httpClient.GetFromJsonAsync<List<HabitModel>>("api/Habits");
                return habits ?? new List<HabitModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<HabitModel> GetHabit(Guid habitId)
        {
            try
            {
                var habit = await _httpClient.GetFromJsonAsync<HabitModel>($"api/Habits/{habitId}");
                return habit;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<HttpResponseMessage> AddHabit(HabitModel habit)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync("api/habits", habit);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
