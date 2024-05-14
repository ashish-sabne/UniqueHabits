using System.Net.Http.Json;
using System.Text.Json;

namespace UnqiueHabits.Client.Helpers
{
    public static class HttpClientExtensions
    {
        public static Task<TValue?> GetWithTokenAsync<TValue>(this HttpClient client, string? requestUri, string authToken, 
            CancellationToken cancellationToken = default)
        {
            client.DefaultRequestHeaders.Authorization = new("Bearer", authToken);
            return client.GetFromJsonAsync<TValue>(requestUri, cancellationToken);
        }
        
        public static Task<HttpResponseMessage> PostWithTokenAsync<TValue>(this HttpClient client, string? requestUri, 
            TValue value, string authToken, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
        {
            client.DefaultRequestHeaders.Authorization = new("Bearer", authToken);
            return client.PostAsJsonAsync(requestUri, value, options, cancellationToken);
        }
        
        public static Task<HttpResponseMessage> PutWithTokenAsync<TValue>(this HttpClient client, string? requestUri, 
            TValue value, string authToken, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
        {
            client.DefaultRequestHeaders.Authorization = new("Bearer", authToken);
            return client.PutAsJsonAsync(requestUri, value, options, cancellationToken);
        }
    }
}
