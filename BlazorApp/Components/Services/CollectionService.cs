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

        public async Task<Collection> GetCollectionByIdAsync(int collectionId)
        {
            try
            {
                var collection = await _httpClient.GetFromJsonAsync<Collection>($"api/collection/{collectionId}");
                return collection ?? new Collection();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return null;
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

        public async Task<List<Mineral>> GetMineralsInCollectionAsync(int collectionId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Mineral>>($"api/collection/{collectionId}/minerals");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return new List<Mineral>();
            }
        }

        //public async Task<bool> AddMineralToCollectionAsync(int collectionId, int mineralId)
        //{
        //    try
        //    {
        //        var response = await _httpClient.PostAsJsonAsync($"api/collection/{collectionId}/items/{mineralId}", new { });
        //        return response.IsSuccessStatusCode;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Error.WriteLine($"Error: {ex.Message}");
        //        return false;
        //    }
        //}

        public async Task<List<CollectionItem>> GetCollectionItemsAsync(int collectionId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<CollectionItem>>($"api/collection/{collectionId}/items");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return new List<CollectionItem>();
            }
        }

        public async Task<bool> AddCollectionItemAsync(CollectionItem collectionItem)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/CollectionItem", collectionItem);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RemoveCollectionItemAsync(int collectionItemId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/collection/items/{collectionItemId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        //public async Task<List<Mineral>> GetMineralsAsync()
        //{
        //    try
        //    {
        //        return await _httpClient.GetFromJsonAsync<List<Mineral>>("api/mineral");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.Error.WriteLine($"Error: {ex.Message}");
        //        return new List<Mineral>();
        //    }
        //}
    }
}
