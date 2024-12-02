using Models;

namespace BlazorApp.Services
{
    public class MineralService(IHttpClientFactory clientFactory)
    {
        private readonly HttpClient _httpClient = clientFactory.CreateClient("Api");

        public async Task<List<Mineral>> GetMineralsAsync()
        {
            try
            {
                var minerals = await _httpClient.GetFromJsonAsync<List<Mineral>>("api/mineral");
                return minerals ?? new List<Mineral>();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
