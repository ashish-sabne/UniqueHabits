using System.Net.Http;
using System.Net.Http.Json;
using UniqueHabits.Contracts;

namespace UnqiueHabits.Contracts
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
                var habits = await _httpClient.GetFromJsonAsync<List<HabitModel>>("https://localhost:7135/api/Habits");
                return habits ?? new List<HabitModel>();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }
    }
}
