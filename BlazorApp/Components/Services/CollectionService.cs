using Models;

namespace BlazorApp.Services
{
    public class CollectionService(IHttpClientFactory clientFactory)
    {
        private readonly HttpClient _httpClient = clientFactory.CreateClient("Api");

        public async Task<List<Collection>> GetCollectionsByUserIdAsync(int userId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Collection>>($"api/collection/user/{userId}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return new List<Collection>();
            }
        }

        public async Task<bool> UpdateCollectionAsync(Collection collection)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/collection/{collection.Id}", collection);
            return response.IsSuccessStatusCode;
        }

        public async Task<Collection> CreateCollectionAsync(Collection collection)
        {
            var response = await _httpClient.PostAsJsonAsync("api/collection", collection);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Collection>();
            }
            return null;
        }

        public async Task<bool> DeleteCollectionAsync(int collectionId)
        {
            var response = await _httpClient.DeleteAsync($"api/collection/{collectionId}");
            return response.IsSuccessStatusCode;
        }
    }
}
