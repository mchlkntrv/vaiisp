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

        public async Task<bool> AddMineralAsync(Mineral newMineral)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/mineral", newMineral);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateMineralAsync(Mineral mineral)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/mineral/{mineral.Id}", mineral);
            return response.IsSuccessStatusCode;

        }

        public async Task<bool> DeleteMineralAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/mineral/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }
        public async Task<Mineral> GetMineralByIdAsync(int id)
        {
            try
            {
                var mineral = await _httpClient.GetFromJsonAsync<Mineral>($"api/mineral/{id}");
                return mineral ?? new Mineral();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
