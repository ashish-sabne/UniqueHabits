using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using UniqueHabits.Contracts.Models;

namespace UnqiueHabits.Client.Helpers
{
    public static class HttpClientExtensions
    {
        public static Task<TValue?> GetWithTokenAsync<TValue>(this HttpClient client, string? requestUri, CancellationToken cancellationToken = default)
        {
            client.DefaultRequestHeaders.Authorization = new("Bearer", AuthState.CurrentUser?.Token);
            return client.GetFromJsonAsync<TValue>(requestUri, cancellationToken);
        }
        
        public static Task<HttpResponseMessage> PostWithTokenAsync<TValue>(this HttpClient client, string? requestUri, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
        {
            client.DefaultRequestHeaders.Authorization = new("Bearer", AuthState.CurrentUser?.Token);
            return client.PostAsJsonAsync(requestUri, value, options, cancellationToken);
        }
    }
}
